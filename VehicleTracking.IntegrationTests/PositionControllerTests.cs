using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Requests.Query;
using VehicleTracking.Application.Core.Responses.Command;
using VehicleTracking.Application.Core.Responses.Query;
using VehicleTracking.Utils.Routes;
using Xunit;

namespace VehicleTracking.IntegrationTests
{
    public class PositionControllerTests : BaseIntegrationTest
    {

        [Fact]
        public async Task Post_Vehicle_ForAuthUser()
        {
            // Arrange
            await AuthenticateAsync();

            var addPositionReq = new AddPositionCommand
            {
                DeviceId = "demodeviceId1",
                Latitude = 35.681610805430566,
                Longitude = 139.76923880376333,
            };

            // Act
            var response = await _testClient.PostAsJsonAsync(ApiRoutes.Position.Add, addPositionReq);
            var add_position_response = await response.Content.ReadAsAsync<AddPositionResponse>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            add_position_response.Latitude.Should().Be(addPositionReq.Latitude);

        }
        
        [Fact]
        public async Task Get_Position_GetCurrentPosition()
        {
            // Arrange
            await AuthenticateAsync();

            var req = new GetCurrentPositionQuery
            {
                VehicleId = 1
            };

            // Act
            var response = await _testClient.GetAsync(ApiRoutes.Position.CurrentPosition.Replace("{vehicleId}", req.VehicleId.ToString()));
            var current_position_response = await response.Content.ReadAsAsync<GetCurrentPositionResponse>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        } 
        
        [Fact]
        public async Task Get_Position_GetJourney()
        {
            // Arrange
            await AuthenticateAsync();

        
            // Act
            var url = ApiRoutes.Position.Journey
                .Replace("{vehicleId}", "1")
                .Replace("{start}", "2021-6-1")
                .Replace("{end}", "2021-6-13");


            var response = await _testClient.GetAsync(url);

            var position_response = await response.Content.ReadAsAsync<List<GetJourneyResponse>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
