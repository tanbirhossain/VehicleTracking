using System.Threading.Tasks;
using VehicleTracking.Application.ViewModels;

namespace VehicleTracking.Application.Services
{
    public interface IGoogleApiService
    {
        Task<string> GetGeoAddress(double latitude, double longitude);
        Task<GeoEncoding> GetGeoData(double latitude, double longitude);
    }
}
