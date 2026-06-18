using System.Net.Http.Json;
using System.Text.Json;
using WebApidemo;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        HttpClient moviesClient = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            moviesClient.BaseAddress = new Uri("http://localhost:5093/api/Movies");
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            var movies = await moviesClient.GetAsync(moviesClient.BaseAddress);
            if (movies.IsSuccessStatusCode)
            {
                var movielist = await movies.Content.ReadFromJsonAsync<List<Movie>>();//deserialization
                dgMovies.DataSource = movielist;
            }
            else
            {
                MessageBox.Show($"error : {movies.StatusCode}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using StringContent content = new StringContent(JsonSerializer.Serialize(
                new Movie
                {
                    Title = "Test",
                    Genre = "Test",
                    ReleaseYear = 2000
                }


                ), System.Text.Encoding.UTF8, "application/json"

                );

            var response = moviesClient.PostAsync(moviesClient.BaseAddress, content).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Movie added");
            }
            else
            {
                MessageBox.Show($"Error: {response.StatusCode}");
            }

            var deleteresult = moviesClient.DeleteAsync("http://localhost:5093/api/Movies/3").Result;
            if (deleteresult.IsSuccessStatusCode)
            {
                MessageBox.Show("Movie is deleted");
            }
            else
            {
                MessageBox.Show($"Error: {deleteresult.StatusCode}");
            }

        }

        private void btnGetWeather_Click(object sender, EventArgs e)
        {
            var weatherClient = new HttpClient();
            weatherClient.BaseAddress = new Uri("https://api.tomorrow.io/v4/weather/realtime?location=98498&US&apikey=DA0U00xKKK1WMEU66xrqAxB3gzBweYWv");
            var response = weatherClient.GetAsync(weatherClient.BaseAddress).Result;
            Root root=response.Content.ReadFromJsonAsync<Root>().Result;

            if(response.IsSuccessStatusCode)
            {
                MessageBox.Show($"The temperature in {root.location.name} is {root.data.values.temperature} with windspeed {root.data.values.windSpeed}");
            }
        }
    }
}
