using System;
using System.Collections.Generic;
using WeatherOfEntryCountryRestApi.Model;
using System.Text;
using System.Threading.Tasks;

namespace WeatherOfEntryCountryRestApi.Services
{
    public class TodoManager
    {
        IRestService service;

        public TodoManager(IRestService restService)
        {
            service = restService;
        }
        public Task<Rootobject> GetTodoItemModels(string cityName)
        {
            return service.GetTodoItemAsync(cityName);
        }
    }
}
