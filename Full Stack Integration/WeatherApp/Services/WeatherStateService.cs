using WeatherApp.Models;
using System.Net.Http.Json;

namespace WeatherApp.Services
{
    public class WeatherStateService
    {
        private readonly HttpClient _http;
        public WeatherStateService(HttpClient http)
        {
            _http = http;
        }
        private CancellationTokenSource? userCts;
        private CancellationTokenSource? weatherCts;
        public event Action? OnChange;
        private void NotifyStateChange() => OnChange?.Invoke();

        public List<User>? Users { get; set; }

        public WeatherData? WeatherData { get; set; }
        public string? ErrorMessage { get; private set; }

        

        public async Task FetchUserData()
        {
            userCts?.Cancel(); //Cancel any previous requests
            userCts = new CancellationTokenSource();
        
            try
            {
                Users = await _http.GetFromJsonAsync<List<User>>("https://jsonplaceholder.typicode.com/users", userCts.Token);
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("Previous user request was canceled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user data: {ex.Message}");
                ErrorMessage = ex.Message;
            }
            finally
            {
               NotifyStateChange(); 
            }
    
        }

        public async Task FetchWeatherData()
        {
            weatherCts?.Cancel(); //Cancel any previous requests
            weatherCts = new CancellationTokenSource();
        
            try
            {
                WeatherData = await _http.GetFromJsonAsync<WeatherData>("https://api.weatherapi.com/v1/current.json?key=00b7a8f4feb041618fb132317261203&q=London", weatherCts.Token);
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("Previous weather request was canceled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching weather data: {ex.Message}");
                ErrorMessage = ex.Message;
            }
            finally
            {
               NotifyStateChange(); 
            }
    
        }

    }
}