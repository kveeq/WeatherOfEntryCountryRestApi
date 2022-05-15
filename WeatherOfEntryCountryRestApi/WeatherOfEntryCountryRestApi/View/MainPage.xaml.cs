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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void CitiesNamesSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            try
            {
                Rootobject a = await App.TodoManager.GetTodoItemModels(CitiesNamesSearchBar.Text);
                TempLbl.Text = a.main.temp.ToString() + " ℃  ";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Введите название города\n{ex.Message}", "Ok");
            }

        }
    }
}
