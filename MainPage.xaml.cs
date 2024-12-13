using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private readonly WeatherService _weatherService;

        public MainPage()
        {
            InitializeComponent();
            _weatherService = new WeatherService();
        }

        // Event handler for "Get Weather" button click
        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            // Get city name from search bar
            string cityName = CitySearchBar.Text;

            if (string.IsNullOrEmpty(cityName))
            {
                await DisplayAlert("Error", "Please enter a city name.", "OK");
                return;
            }

            await GetWeatherAsync(cityName);
        }

        // Event handler for navigating to the To-Do page
        private async void OnNavigateToTodoPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TodoPage"); // Use absolute route
        }

        private async Task GetWeatherAsync(string cityName)
        {
            try
            {
                // Fetch weather data using the entered city name
                var weatherData = await _weatherService.GetWeatherByCityAsync(cityName);

                // Update UI with weather data
                TemperatureLabel.Text = $"Temperature: {weatherData.main.temp}°C";
                TempMinLabel.Text = $"Min Temperature: {weatherData.main.temp_min}°C";
                TempMaxLabel.Text = $"Max Temperature: {weatherData.main.temp_max}°C";
                ForecastLabel.Text = $"Forecast: {weatherData.weather[0].main} - {weatherData.weather[0].description}";

                if (weatherData.wind.speed > 4)
                {
                    WindAlertLabel.Text = "Wind Alert: High wind speed today!";
                    WindAlertLabel.TextColor = Colors.Red;
                }
                else
                {
                    WindAlertLabel.Text = "Wind Alert: Normal";
                    WindAlertLabel.TextColor = Colors.Green;
                }
            }
            catch (Exception ex)
            {
                // Show error message if API request fails
                await DisplayAlert("Error", $"Unable to get weather data: {ex.Message}", "OK");
            }
        }
    }
}
