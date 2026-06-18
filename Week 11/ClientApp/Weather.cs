using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {
        public DateTime time { get; set; }
        public Values values { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
        public Location location { get; set; }
    }

    public class Values
    {
        public double? cloudBase { get; set; }
        public double? cloudCeiling { get; set; }
        public double? cloudCover { get; set; }
        public double? dewPoint { get; set; }
        public double? freezingRainIntensity { get; set; }
        public double? humidity { get; set; }
        public double? precipitationProbability { get; set; }
        public double? pressureSurfaceLevel { get; set; }
        public double? rainIntensity { get; set; }
        public double? sleetIntensity { get; set; }
        public double? snowIntensity { get; set; }
        public double? temperature { get; set; }
        public double? temperatureApparent { get; set; }
        public double? uvHealthConcern { get; set; }
        public double? uvIndex { get; set; }
        public double? visibility { get; set; }
        public double? weatherCode { get; set; }
        public double? windDirection { get; set; }
        public double? windGust { get; set; }
        public double? windSpeed { get; set; }
    }


}
