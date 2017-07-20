using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using StructureMap.AspNetCore;

namespace ApiControllers
{
    //https://docs.microsoft.com/en-us/aspnet/core/publishing/iis
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseStructureMap()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
