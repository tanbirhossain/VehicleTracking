using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Api.Controllers.V1;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Responses.Command;
using Xunit;

namespace VehicleTracking.UnitTests.v1
{
    public class AccountController_Test
    {
        private Mock<IMediator> _mediator;
        public AccountController_Test()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Account_Registration_TestAsync()
        {
            // Arrange
            var command = new RegistrationCommand
            {

                FirstName = "Mohammed",
                LastName = "Tanbir",
                Email = "ovibhuiyan43@gmail.com",
                Password = "12345"
            };
            var registerMockResult = new RegistrationResponse
            {

                FirstName = "Mohammed",
                LastName = "Tanbir",
                Email = "ovibhuiyan43@gmail.com"
            };


            _mediator.Setup(x => x.Send(It.IsAny<RegistrationCommand>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(registerMockResult);

            var controller = new AccountController(_mediator.Object);
            // Act
            var result = await controller.Registration(command);
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as RegistrationResponse;
            Assert.Equal(command.Email, response.Email);
        }

        [Fact]
        public async Task Account_Login_TestAsync()
        {
            // Arrange
            var command = new LoginCommand
            {
                Email = "ovibhuiyan43@gmail.com",
                Password = "12345"
            };
            var responseMockResult = new LoginResponse
            {


                FirstName = "Mohammed",
                LastName = "Tanbir",
                AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJuYmYiOjE2MjI1MTQ1NzYsImV4cCI6MTc4MDI4MDk3NiwiaWF0IjoxNjIyNTE0NTc2fQ.-1eDiEvnIfUicSP01rhaXplf7-ZGy5j5RuYKefT2gY8"
            };


            _mediator.Setup(x => x.Send(It.IsAny<LoginCommand>(), new System.Threading.CancellationToken()))
                    .ReturnsAsync(responseMockResult);

            var controller = new AccountController(_mediator.Object);
            // Act
            var result = await controller.Login(command);
            var okResult = result as OkObjectResult;

            // Assert
            if (okResult != null)
            {
                Assert.NotNull(okResult);
            }
            var response = okResult.Value as LoginResponse;
            Assert.Equal("Mohammed Tanbir", response.FullName);
        }

    }
}
