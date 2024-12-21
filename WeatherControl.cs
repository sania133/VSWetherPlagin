using System;
using System.Net.Http;
using System.Windows.Controls;

namespace WeatherPlugin
{
    public class WeatherControl : UserControl
    {
        private readonly TextBlock _weatherText;

        public WeatherControl()
        {
            _weatherText = new TextBlock { Text = "Loading weather..." };
            this.Content = _weatherText;
            LoadWeatherAsync();
        }

        private async void LoadWeatherAsync()
        {
            string apiKey = "b2fca70cf7c2fbc6a65249a1fb1ddc87";
            string city = "Saint Petersburg";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            try
            {
                using HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(url);
                dynamic weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject(response);

                string description = weatherData.weather[0].description;
                double temperature = weatherData.main.temp;

                _weatherText.Text = $"Weather: {description}, Temperature: {temperature}°C";
            }
            catch (Exception ex)
            {
                _weatherText.Text = $"Failed to load weather: {ex.Message}";
            }
        }
    }
}
