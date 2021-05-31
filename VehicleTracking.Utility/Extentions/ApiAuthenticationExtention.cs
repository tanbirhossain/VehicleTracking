//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace VehicleTracking.Utility.Extentions
//{
//    public static class ApiAuthenticationExtention
//    {


//        public static void ApiAuthServiceBuild(this IServiceCollection services)
//        {
//            #region JWT Api Authentication
//            // configure strongly typed settings objects
//            var appSettingsSection = Configuration.GetSection("AppSettings");
//            services.Configure<AppSettings>(appSettingsSection);

//            var key = Encoding.ASCII.GetBytes(AppSettings.ApiAuthSecret);
//            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//            .AddJwtBearer(options =>
//            {

//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ClockSkew = TimeSpan.Zero,
//                    ValidateIssuer = false,
//                    ValidateAudience = false,
//                    //ValidateLifetime = true,
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(key)

//                };
//            });



//            #endregion

//            #region Global Authorization
//            services.AddMvc(options =>
//            {
//                var policy = new AuthorizationPolicyBuilder()
//                    .RequireAuthenticatedUser()
//                    .Build();
//                options.Filters.Add(new AuthorizeFilter(policy));
//            });
//            #endregion


//        }


//    }
//}
