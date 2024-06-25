using System;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;

[assembly: OwinStartup(typeof(OWIN_WebAPI.Startup1))]
namespace OWIN_WebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup1>("http://localchost:9000"))
            {
                Console.WriteLine("Press [enter] to quit...");
                Console.ReadLine();
            }
        }
    }
}

