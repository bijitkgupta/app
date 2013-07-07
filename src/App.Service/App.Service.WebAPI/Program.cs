using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Web.Http.Dispatcher;
using System.Web.Http.Tracing;
using System.Net.Http.Formatting;
using System.Net.Http;

namespace App.Service.WebAPI
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var config = new HttpSelfHostConfiguration("http://PSHYS0256");
            config.Services.Replace(typeof(IHttpControllerActivator), new ControllerComposer());

            config.Routes.MapHttpRoute(
                "Extension", "api/{controller}.{ext}", new { ext = RouteParameter.Optional });

            config.Formatters.Clear();
            config.Formatters.Add(new XmlMediaTypeFormatter());
            config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "application/xml");
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");

            //config.MaxBufferSize = 2000000000;
            //config.MaxReceivedMessageSize = 2000000000;
            //config.ReceiveTimeout = new TimeSpan(0, 2, 0);

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
