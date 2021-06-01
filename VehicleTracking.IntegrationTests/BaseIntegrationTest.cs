using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VehicleTracking.Api;
using VehicleTracking.Application.Core.Requests.Command;
using VehicleTracking.Application.Core.Responses.Command;
using VehicleTracking.Infrastructure.Domain;
using VehicleTracking.Utils.Routes;
using Xunit;

namespace VehicleTracking.IntegrationTests
{
    public class BaseIntegrationTest
    {
        protected readonly HttpClient _testClient;
        public BaseIntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<VehicleTrackingDbContext>));

                        services.Remove(descriptor);

                        services.AddDbContext<VehicleTrackingDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("VehicleTrackingDbForTesting");
                        });

                    });
                });
            _testClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            _testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }
        private async Task<string> GetJwtAsync()
        {
            var response = await _testClient.PostAsJsonAsync(ApiRoutes.Account.Login, new LoginCommand
            {
                Email = "ovibhuiyan43@gmail.com",
                Password = "1234"
            });
            var registrationResponse = await response.Content.ReadAsAsync<LoginResponse>();
            return registrationResponse.AccessToken;
        }
    }

}
