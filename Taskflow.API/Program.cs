using Taskflow.Application;
using Taskflow.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddControllers();
  builder.Services.AddInfrastructure(builder.Configuration);
  builder.Services.AddApplication();
}
{
  WebApplication app = builder.Build();
  app.UseHttpsRedirection();
  app.MapControllers();
  app.Run();
}






