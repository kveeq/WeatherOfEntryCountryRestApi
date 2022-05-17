using WeatherOfEntryCountryRestApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherOfEntryCountryRestApi.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

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

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Введите название города\n{ex.Message}", "Ok");
            }
        }
    }
}
