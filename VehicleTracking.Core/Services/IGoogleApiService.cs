using System.Threading.Tasks;
using VehicleTracking.Application.ViewModels;

namespace VehicleTracking.Application.Services
{
    public interface IGoogleApiService
    {
        Task<GeoEncoding> GetGeoData(double latitude, double longitude);
    }
}
