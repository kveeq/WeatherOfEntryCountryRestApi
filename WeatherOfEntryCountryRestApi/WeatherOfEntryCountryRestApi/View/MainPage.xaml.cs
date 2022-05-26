using WeatherOfEntryCountryRestApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

namespace WeatherOfEntryCountryRestApi.View
{
    public partial class MainPage : ContentPage
    {
        Geocoder geocoder = new Geocoder();
        Rootobject weather;
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await DisplayAlert("Уведомление", "Подождите загрузки погоды своего города", "Ок");
            var w = await Geolocation.GetLocationAsync();
            var pos = new Position(w.Latitude, w.Longitude);
            weather = await App.TodoManager.GetTodoItemWithCoordinatesModels(pos);
            GetWeather();
        }

        private async void CitiesNamesSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            try
            {
                weather = await App.TodoManager.GetTodoItemModels(CitiesNamesSearchBar.Text);
                GetWeather();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Введите название города\n{ex.Message}", "Ok");
            }
        }

        private void GetWeather()
        {
            BindingContext = weather;
            TempLbl.Text = weather.main.temp.ToString() + " ℃  ";
            FeelsLikeLbl.Text = weather.main.feels_like.ToString() + " ℃  ";
            PressureLbl.Text = weather.main.pressure.ToString();
            HumidityLbl.Text = weather.main.humidity.ToString();
            WindLbl.Text = weather.wind.speed.ToString();
            qqww.Text = weather.weather[0].description;
            WindDegLbl.Text = GetWindDirection(weather.wind.deg);
            CitiesNamesSearchBar.Text = weather.name;
            Pin pin = new Pin
            {
                Label = weather.name,
                Address = weather.weather[0].description,
                Type = PinType.Place,
                Position = new Position(weather.coord.lat, weather.coord.lon)
            };
            MyMap.Pins.Add(pin);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMeters(5000)));
            weatherImg.Source = ImageSource.FromUri(new Uri($"http://openweathermap.org/img/w/{weather.weather[0].icon}.png"));
        }

        private string GetWindDirection(int deg)
        {
            if (deg == 0)
                return "C";
            if (deg == 90)
                return "В";
            if (deg == 180)
                return "Ю";
            if (deg == 270)
                return "З";
            if (deg > 0 && deg < 90)
                return "С-В";
            if (deg > 90 && deg < 180)
                return "Ю-В";
            if (deg > 180 && deg < 270)
                return "Ю-З";

            return "С-З";
        }

        private async void MyMap_MapClicked(object sender, MapClickedEventArgs e)
        {
            MyMap.Pins.Clear();
            weather = await App.TodoManager.GetTodoItemWithCoordinatesModels(e.Position);
            GetWeather();
        }
    }
}
