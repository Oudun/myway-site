using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MyWay;

public static class Startup
{
    public static WebApplicationBuilder CreateWebBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            WebRootPath = "static",
            Args = args
        });
        builder.Configuration.AddEnvironmentVariables();
        var config = builder.Configuration;
        if (!int.TryParse(config["PORT"], out int port))
        {
            port = 80;
        }
        builder.WebHost.ConfigureKestrel(opts =>
        {
            opts.ListenAnyIP(port);
        });
        return builder;
    }

    public static void ConfigurePipeline(this WebApplication app)
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();
    }
}