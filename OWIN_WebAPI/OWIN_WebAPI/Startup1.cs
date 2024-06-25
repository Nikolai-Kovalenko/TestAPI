using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

//[assembly: OwinStartup(typeof(OWIN_WebAPI.Startup1))]

namespace OWIN_WebAPI
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(LoggerModule), "OwinLogger: ");
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("default", "{controller}");
            app.UseWebApi(config);
        }
    }
}
