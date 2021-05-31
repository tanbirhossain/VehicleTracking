namespace VehicleTracking.Infrastructure.Domain.Entities
{
    public class Position
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

    }
}
