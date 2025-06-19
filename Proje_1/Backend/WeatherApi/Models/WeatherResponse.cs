namespace WeatherApi.Models
{
    public class WeatherResponse
    {
        public string? Name { get; set; }           // city name
        public MainInfo? Main { get; set; }         // temp, humidity
        public List<WeatherInfo>? Weather { get; set; } // weather array
        public WindInfo? Wind { get; set; }         // speed
    }

    public class MainInfo
    {
        public double Temp { get; set; }
        public int Humidity { get; set; }
    }

    public class WindInfo
    {
        public double Speed { get; set; }
    }
}
