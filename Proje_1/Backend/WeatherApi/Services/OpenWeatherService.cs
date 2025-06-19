namespace WeatherApi.Services
{
    using Models;
    using Microsoft.Extensions.Configuration;
    using System.Net.Http.Json;

    public class OpenWeatherService : IWeatherService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public OpenWeatherService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _apiKey = config["OpenWeatherMap:ApiKey"];
            _baseUrl = config["OpenWeatherMap:BaseUrl"];
        }

        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            var url = $"{_baseUrl}/weather?q={city}&appid={_apiKey}&units=metric";
            var result = await _http.GetFromJsonAsync<WeatherResponse>(url);
            return result!;
        }
    }
}
