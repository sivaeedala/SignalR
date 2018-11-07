using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using SignalR_Console_SelfHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Startup))]
namespace SignalR_Console_SelfHost
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR(new Microsoft.AspNet.SignalR.HubConfiguration { EnableJSONP=true});
        }
    }
}
