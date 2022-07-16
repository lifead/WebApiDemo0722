using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Authentication;
using WebApiDemo0722.Server.Contexts;
using WebApiDemo0722.Server.Interfaces;
using WebApiDemo0722.Server.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<WebApiDemo0722Context>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("WebApiDemoDBConectionString")));

builder.Services.AddTransient<IWebApiDemo0722Context, WebApiDemo0722Context>();

builder.Services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));

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
