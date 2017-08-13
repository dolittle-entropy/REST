using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var descriptor = new ControllerActionDescriptor();

            var d = new ActionDescriptor();
            */
            
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();            

        }
    }
}
