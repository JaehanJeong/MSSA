using MonkeyFinder.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace MonkeyFinder.Services
{
    public class MonkeyService
    {
        HttpClient httpClient;
        List<Monkey> monkeys = new List<Monkey>();

        public MonkeyService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Monkey>> GetMonkeysAsync()
        {
            if (monkeys.Count > 0)
                return monkeys;
            var url = "https://montemagno.com/monkeys.json";
            var response = await httpClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                monkeys = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }
            return monkeys;
        }


    }
}
