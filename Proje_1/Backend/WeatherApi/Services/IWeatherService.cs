namespace WeatherApi.Services
{
    using Models;
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherAsync(string city);
    }
}
