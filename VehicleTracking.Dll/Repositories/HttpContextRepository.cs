using System;
using VehicleTracking.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace VehicleTracking.Infrastructure.Repositories
{
    public class HttpContextRepository : IHttpContextRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HttpContextRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public long GetUserId()
        {
            var result = Convert.ToInt64( _httpContextAccessor.HttpContext.User.Identity.Name);
            return result;
        }
    }
}
