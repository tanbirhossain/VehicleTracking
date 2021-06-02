namespace VehicleTracking.Application.Core.Responses.Query
{
    public class GetVehiclesByClientIdResponse
    {
        public long VehicleId { get; set; }
        public string Name { get; set; }
        public string DeviceId { get; set; }
    }
}
