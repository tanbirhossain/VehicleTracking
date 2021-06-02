﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.ViewModels;

namespace VehicleTracking.Application.Services
{
    public class GoogleApiService : IGoogleApiService
    {
        string _apiKey = "AIzaSyBN0vaTwUpcADHkSEsGcyWW0MKhVoezgWU";
        private readonly HttpClient _httpClient;
        public GoogleApiService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<GeoEncoding> GetGeoData(double latitude, double longitude)
        {
            string Url = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&key={_apiKey}";

            var response = await _httpClient.GetAsync(Url);
            var result = await response.Content.ReadAsAsync<GeoEncoding>();

            return result;
        }
        public async Task<string> GetGeoAddress(double latitude, double longitude)
        {
            string Url = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&key={_apiKey}";
            var response = await _httpClient.GetAsync(Url);
            var result = await response.Content.ReadAsAsync<GeoEncoding>();
            string address = result.results[0].formatted_address;

            return address;
        }
    }
}
