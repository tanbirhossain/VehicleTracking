using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Responses.Command;
using VehicleTracking.Application.Core.Responses.Query;
using VehicleTracking.Utils.Routes;
using Xunit;

namespace VehicleTracking.IntegrationTests
{
    public class VehicleControllerTests : BaseIntegrationTest
    {
        [Fact]
        public async Task Get_Vehicle_PostVehicle_ForAuthUser()
        {
            // Arrange
            await AuthenticateAsync();
            var vehicleReq = new AddVehicleCommand
            {
                Name = "BMQ car",
                DeviceId = "d1234"
            };

            // Act
            var response = await _testClient.PostAsJsonAsync(ApiRoutes.Vehicle.Add, vehicleReq);
            var add_vehicle_response = await response.Content.ReadAsAsync<AddVehicleResponse>();

            var response_GetVehicles = await _testClient.GetAsync(ApiRoutes.Vehicle.GetVehicles);
            var allvehicleByUser = await response_GetVehicles.Content.ReadAsAsync<List<GetVehiclesByClientIdResponse>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response_GetVehicles.StatusCode.Should().Be(HttpStatusCode.OK);

            add_vehicle_response.Name.Should().Be(vehicleReq.Name);

        }
    } 
}
