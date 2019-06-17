using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

namespace TestLinq
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            string assemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;

            return WebHost.CreateDefaultBuilder(args)
                        .UseUrls("http://*:5000", "https://*:5001")
                        .UseStartup<Startup>();
        }

    }
}
