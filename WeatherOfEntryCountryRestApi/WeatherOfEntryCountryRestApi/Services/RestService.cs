﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherOfEntryCountryRestApi.Model;
using Xamarin.Forms.Maps;

namespace WeatherOfEntryCountryRestApi.Services
{
    public class RestService : IRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        public Rootobject TodoItems { get; set; }

        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);

            serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<Rootobject> GetTodoItemAsync(string cityName)
        {
            TodoItems = new Rootobject();

            Uri uri = new Uri(string.Format(Constants.RestUrl, cityName));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    TodoItems = JsonSerializer.Deserialize<Rootobject>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return TodoItems;
        }     
        
        public async Task<Rootobject> GetTodoItemWithCoordinatesAsync(Position position)
        {
            TodoItems = new Rootobject();

            Uri uri = new Uri(string.Format(Constants.RestUrl1, position.Latitude, position.Longitude));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    TodoItems = JsonSerializer.Deserialize<Rootobject>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return TodoItems;
        }
        
    }
}