using WeatherOfEntryCountryRestApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WeatherOfEntryCountryRestApi.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //http://openweathermap.org/img/w/04d.png
        private async void CitiesNamesSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            try
            {
                Rootobject a = await App.TodoManager.GetTodoItemModels(CitiesNamesSearchBar.Text);
                BindingContext = a;
                TempLbl.Text = a.main.temp.ToString() + " ℃  ";
                FeelsLikeLbl.Text = a.main.feels_like.ToString() + " ℃  ";
                PressureLbl.Text = a.main.pressure.ToString();
                HumidityLbl.Text = a.main.humidity.ToString();
                WindLbl.Text = a.wind.speed.ToString();
                qqww.Text = a.weather[0].description;
                Pin pin = new Pin
                {
                    Label = a.name,
                    Address = a.weather.Rank.ToString(),
                    Type = PinType.Place,
                    Position = new Position(a.coord.lat, a.coord.lon)
                };
                MyMap.Pins.Add(pin);
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMeters(5000)));
                weatherImg.Source = ImageSource.FromUri(new Uri($"http://openweathermap.org/img/w/{a.weather[0].icon}.png"));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Введите название города\n{ex.Message}", "Ok");
            }
        }

        private void MyMap_MapClicked(object sender, MapClickedEventArgs e)
        {

        }
    }
}
