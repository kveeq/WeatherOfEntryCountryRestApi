using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherOfEntryCountryRestApi.Model;

namespace WeatherOfEntryCountryRestApi.Services
{
    public interface IRestService
    {
        Task<Rootobject> GetTodoItemAsync(string cityName);
    }
}
