using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTracking.Api.Controllers.V1;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Requests.Query;
using VehicleTracking.Application.Core.Responses.Command;
using VehicleTracking.Application.Core.Responses.Query;
using Xunit;

namespace VehicleTracking.UnitTests.v1
{
    public class VehicleController_Test
    {
        private Mock<IMediator> _mediator;
        public VehicleController_Test()
        {
            _mediator = new Mock<IMediator>();
        }


        [Fact]
        public async Task Vehicle_Add_Test()
        {
            // Arrange
            var command = new AddVehicleCommand
            {
                Name = "BMW car",
                DeviceId = "d12345"
            };
            var responseMockResult = new AddVehicleResponse
            {
                Id = 1,
                Name = "BMW car",
                DeviceId = "d12345"
            };


            _mediator.Setup(x => x.Send(It.IsAny<AddVehicleCommand>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(responseMockResult);

            var controller = new VehicleController(_mediator.Object);
            // Act
            var result = await controller.Add(command);
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as AddVehicleResponse;
            Assert.Equal(command.Name, response.Name);
        }

        [Fact]
        public async Task Vehicle_GetVehicles_Test()
        {
            // Arrange
            var command = new GetVehiclesByClientIdQuery();

            var responseMockResult = new List<GetVehiclesByClientIdResponse>
            {
                new GetVehiclesByClientIdResponse
                {
                    Id = 0,
                    Name = "BMW car",
                    DeviceId = "d12345"
                },
                new GetVehiclesByClientIdResponse
                {
                    Id = 1,
                    Name = "Toyota Premio",
                    DeviceId = "d123rtr5"
                }
            };




            _mediator.Setup(x => x.Send(It.IsAny<GetVehiclesByClientIdQuery>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(responseMockResult);

            var controller = new VehicleController(_mediator.Object);
            // Act
            var result = await controller.GetVehicles();
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as List<GetVehiclesByClientIdResponse>;
            Assert.Equal(responseMockResult.Count, response.Count);
        }
    }

}
