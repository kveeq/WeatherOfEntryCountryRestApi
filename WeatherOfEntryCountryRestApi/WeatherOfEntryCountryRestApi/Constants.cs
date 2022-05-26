using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherOfEntryCountryRestApi
{
    public static class Constants
    {
        public static string RestUrl = "https://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&appid=fa88c9cdfdb5bff9bc0b42893067a148&lang=ru"; 
        public static string RestUrl1 = "https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units=metric&appid=fa88c9cdfdb5bff9bc0b42893067a148&lang=ru";

    }
}