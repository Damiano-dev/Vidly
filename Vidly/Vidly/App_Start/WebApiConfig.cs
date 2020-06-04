using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var impostazioneCamel = config.Formatters.JsonFormatter.SerializerSettings;
            impostazioneCamel.ContractResolver = new CamelCasePropertyNamesContractResolver();
            impostazioneCamel.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "QueryApi",
               routeTemplate: "api/{controller}/{domanda}",
               defaults: new { domanda = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
