using WeatherOfEntryCountryRestApi.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherOfEntryCountryRestApi.View;

namespace WeatherOfEntryCountryRestApi
{
    public partial class App : Application
    {
        public static TodoManager TodoManager;
        public App()
        {
            InitializeComponent();
            TodoManager = new TodoManager(new RestService());
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
