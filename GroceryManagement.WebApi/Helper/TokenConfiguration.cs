using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace GroceryManagement.WebApi.Helper
{
    public static class TokenConfiguration
    {
        public static WebApplicationBuilder AddTokenConfiguration(this WebApplicationBuilder app)
        {
            app.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(name : JwtBearerDefaults.AuthenticationScheme,securityScheme: new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {   
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        }, new string[] {} }
                });
            });
            var settings = app.Configuration.GetSection("ApiSettings");
            var secretKey = settings.GetValue<string>("SecretKey");
            var issuer = settings.GetValue<string>("Issuer");
            var audience = settings.GetValue<string>("Audience");
            var key = Encoding.UTF8.GetBytes(secretKey);
            app.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            return app;
        }
    }
}
