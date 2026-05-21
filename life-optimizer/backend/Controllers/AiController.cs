using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace LifeOptimizer.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AiController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public AiController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpPost("quest")]
        public async Task<IActionResult> GenerateQuest([FromBody] AiQuestRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Prompt))
            {
                return BadRequest(new { message = "Prompt is required." });
            }

            var apiKey = _configuration["GeminiApiKey"] ?? _configuration["GEMINI_API_KEY"];
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return StatusCode(500, new { message = "Missing GeminiApiKey in configuration or GEMINI_API_KEY environment variable on server." });
            }

            var httpClient = _httpClientFactory.CreateClient();

            var modelName = "gemini-2.5-flash";
            string url = $"https://generativelanguage.googleapis.com/v1/models/{modelName}:generateContent?key={apiKey}";

            var promptText = $"You are a witty, dry-humored quest giver in a life RPG — think less 'HERO, YOUR DESTINY AWAITS' and more deadpan narrator who takes mundane tasks seriously. " +
                             "Your job is to reframe real-life tasks as quest titles that are clever, slightly self-aware, and occasionally funny — but never try-hard. " +
                             "Avoid fantasy clichés like 'ancient', 'sacred', 'legendary power', 'destiny', 'realm', or dramatic exclamation marks. " +
                             "Keep titles concise, punchy, and grounded — the humor comes from treating ordinary things with quiet gravitas. " +
                             $"Task: \"{request.Prompt}\". " +
                             $"Pick the most fitting attribute from: [{string.Join(", ", request.Attributes ?? Array.Empty<string>())}]. " +
            "Assign a rarity from: [Common, Rare, Epic, Legendary]. " +
            "Return strictly raw JSON: { \"title\": \"Title String\", \"stat\": \"Attribute String\", \"rarity\": \"Rarity String\" }. " +
            "No markdown, no backticks, no explanation. Just the JSON.";

            // 🔧 Clean request payload - removing generationConfig altogether to eliminate the JSON 400 parsing loop
            var payload = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[] { new { text = promptText } }
                    }
                }
            };

            var response = await httpClient.PostAsJsonAsync(url, payload);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, new { message = errorContent });
            }

            using var jsonDoc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
            var root = jsonDoc.RootElement;
            if (!root.TryGetProperty("candidates", out var candidates) || candidates.GetArrayLength() == 0)
            {
                return BadRequest(new { message = "AI response did not contain any candidates." });
            }

            var text = candidates[0].GetProperty("content").GetProperty("parts")[0].GetProperty("text").GetString();
            if (string.IsNullOrWhiteSpace(text))
            {
                return BadRequest(new { message = "AI response returned empty output." });
            }

            try
            {
                // Clean up any rogue formatting strings just in case the model behaves oddly
                var cleanedJson = text.Trim();
                if (cleanedJson.StartsWith("```json")) cleanedJson = cleanedJson.Replace("```json", "");
                if (cleanedJson.StartsWith("```")) cleanedJson = cleanedJson.Replace("```", "");
                if (cleanedJson.EndsWith("```")) cleanedJson = cleanedJson.Substring(0, cleanedJson.Length - 3);
                cleanedJson = cleanedJson.Trim();

                var quest = JsonSerializer.Deserialize<AiQuestResponse>(cleanedJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (quest == null || string.IsNullOrWhiteSpace(quest.Title) || string.IsNullOrWhiteSpace(quest.Stat) || string.IsNullOrWhiteSpace(quest.Rarity))
                {
                    return BadRequest(new { message = "AI response could not be parsed into quest JSON." });
                }

                return Ok(quest);
            }
            catch (JsonException)
            {
                return BadRequest(new { message = "AI response was not valid JSON." });
            }
        }
    }

    public class AiQuestRequest
    {
        public string Prompt { get; set; } = string.Empty;
        public string[]? Attributes { get; set; }
    }

    public class AiQuestResponse
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("stat")]
        public string Stat { get; set; } = string.Empty;

        [JsonPropertyName("rarity")]
        public string Rarity { get; set; } = string.Empty;
    }
}