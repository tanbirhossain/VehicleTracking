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
                DeviceId = "d1234",
                Latitude = 7.575904,
                Longitude = 6.440582
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

            var req = new GetJourneyQuery
            {
                VehicleId = 1,
                Start = DateTime.Parse("01/06/2021 2:02"),
                End = DateTime.Parse("02/06/2021 2:03"),
            };

            // Act
            var response = await _testClient.GetAsync(ApiRoutes.Position.Journey
                .Replace("{vehicleId}", req.VehicleId.ToString())
                .Replace("{start}", req.Start.ToString())
                .Replace("{end}", req.End.ToString()));

            var position_response = await response.Content.ReadAsAsync<List<GetJourneyResponse>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
