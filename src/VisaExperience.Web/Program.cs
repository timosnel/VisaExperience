using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace VisaExperience.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables("")
                .Build();

            var url = config["ASPNETCORE_URLS"] ?? "http://*:5000";
            var env = config["ASPNETCORE_ENVIRONMENT"] ?? "Development";

            var host = new WebHostBuilder()
                        .UseKestrel()
                        .UseUrls(url)
                        .UseEnvironment(env)
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseStartup<Startup>()
                        .Build();

            host.Run();
        }
    }
}