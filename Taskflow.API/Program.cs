using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Taskflow.API.Exceptions;
using Taskflow.Application;
using Taskflow.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
  builder.Services.AddProblemDetails();
  builder.Services.AddControllers();
  builder.Services.AddInfrastructure(builder.Configuration);
  builder.Services.AddApplication();
  builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new()
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]!))
      };
    });
  builder.Services.AddAuthorization();
}
{
  WebApplication app = builder.Build();
  app.UseExceptionHandler();
  app.UseHttpsRedirection();
  app.UseAuthentication();
  app.UseAuthorization();
  app.MapControllers();
  app.Run();
}

