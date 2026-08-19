using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Taskflow.Application;
using Taskflow.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
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
  app.UseHttpsRedirection();
  app.UseAuthentication();
  app.UseAuthorization();
  app.MapControllers();
  app.Run();
}

