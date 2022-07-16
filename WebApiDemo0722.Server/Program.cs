using System.Net;
using System.Security.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var data = context;
    var remoteIpAddress = context.Request.HttpContext.Connection.RemoteIpAddress ?? throw new Exception("");
    List<IPAddress> ip = new()
    {
        IPAddress.Parse("127.0.0.1"),
        IPAddress.Parse("::1")
    };
    if (!ip.Contains(remoteIpAddress))
    {
        throw new AuthenticationException();
    }
    await next.Invoke();
});

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
