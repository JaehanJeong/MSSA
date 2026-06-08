using System.Text.Json;
using System.Xml.Serialization;
using System.Xml.Serialization;
namespace Assignment_10._1._1
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            //Movie list
            List<Movie> movies = new List<Movie>
            {
                new Movie { MovieId = 1, Title = "Spirited Away", Rating = 9.8f },
                new Movie { MovieId = 2, Title = "Inception", Rating = 9.2f },
                new Movie { MovieId = 3, Title = "The Dark Knight", Rating = 9.5f }
            };
            // JSON Serialization
            Console.WriteLine("JSON Serialization");
            string jsonPath = @"C:\Files\movies.json";

            if (File.Exists(jsonPath)) File.Delete(jsonPath);

            using (FileStream fs = new FileStream(jsonPath, FileMode.CreateNew, FileAccess.Write))
            {
                JsonSerializer.Serialize(fs, movies);
            }
            Console.WriteLine("List serialized to JSON");

            // JSON Deserialization
            using (FileStream fs = new FileStream(jsonPath, FileMode.Open, FileAccess.Read))
            {
                var movieList = JsonSerializer.Deserialize<List<Movie>>(fs);
                foreach (var movie in movieList)
                {
                    Console.WriteLine($"Id: {movie.MovieId}, Title: {movie.Title}, Rating: {movie.Rating}");
                }
            }
            // XML Serialization
            Console.WriteLine("\nXML Serialization");
            string xmlPath = @"C:\Files\movies.xml";

            if (File.Exists(xmlPath)) File.Delete(xmlPath);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Movie>));

            using (FileStream fs = new FileStream(xmlPath, FileMode.CreateNew, FileAccess.Write))
            {
                xmlSerializer.Serialize(fs, movies);
            }
            Console.WriteLine("List serialized to XML");

            // XML Deserialization
            using (FileStream fs = new FileStream(xmlPath, FileMode.Open, FileAccess.Read))
            {
                var movieList = (List<Movie>)xmlSerializer.Deserialize(fs);
                foreach (var movie in movieList)
                {
                    Console.WriteLine($"Id: {movie.MovieId}, Title: {movie.Title}, Rating: {movie.Rating}");
                }
            }

        }
    }
}
