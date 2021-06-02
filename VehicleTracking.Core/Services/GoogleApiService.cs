using System;
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
        private readonly HttpClient _httpClient;
        //private readonly IHttpClientFactory _clientFactory;

        public GoogleApiService()
        {

            //_clientFactory = clientFactory;
            _httpClient = new HttpClient();//  _clientFactory.CreateClient();
        }
        public async Task<GeoEncoding> GetGeoData(double latitude, double longitude)
        {
            string apiKey = "AIzaSyBN0vaTwUpcADHkSEsGcyWW0MKhVoezgWU";
            string Url= $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&key={apiKey}";

            var response = await _httpClient.GetAsync(Url);
            var result  = await response.Content.ReadAsAsync<GeoEncoding>();
            return result;
        }
    }
}
