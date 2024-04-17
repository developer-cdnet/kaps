using Kaps.API.Middleware;
using Kaps.Application;
using Kaps.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

 
var app = builder.Build();

 

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();