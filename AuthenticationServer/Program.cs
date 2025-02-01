using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true, 
            ValidateIssuerSigningKey = true,
            ValidAudience = "http://localhost:5000",
            RequireExpirationTime = true,
            RefreshBeforeValidation = true,  // Ensures that the token is validated before it expires         
            };
    });
app.MapGet("/", () => "Hello World!");

app.Run();
