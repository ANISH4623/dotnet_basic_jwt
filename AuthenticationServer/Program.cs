using Microsoft.AspNetCore.Authentication.JwtBearer;
using DotNetEnv;
using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();
var key = Environment.GetEnvironmentVariable("JWT_SECRET");
if (string.IsNullOrEmpty(key))
{
    throw new Exception("JWT_SECRET is not set in the environment variables");
}
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
builder.Services.AddAuthorization();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
