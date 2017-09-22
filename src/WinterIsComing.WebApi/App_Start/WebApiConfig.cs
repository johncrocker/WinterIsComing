using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using WinterIsComing.WebApi.Services;

namespace WinterIsComing.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            RegisterContentNegotiator(config);
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "BooksApi",
                routeTemplate: "api/books",
                defaults: new
                {
                    controller = "Books"
                }
            );

            config.Routes.MapHttpRoute(
                name: "SeasonsApi",
                routeTemplate: "api/seasons",
                defaults: new
                {
                    controller = "Seasons"
                }
            );

            config.Routes.MapHttpRoute(
                name: "BookApi",
                routeTemplate: "api/book/{bookId}/{action}",
                defaults: new
                {
                    controller = "Book",
                    bookId = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "SeasonApi",
                routeTemplate: "api/season/{season}/{action}",
                defaults: new
                {
                    controller = "Season",
                    season = RouteParameter.Optional
                }
            );

            /*
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            */
        }

        public static void RegisterContentNegotiator(HttpConfiguration config)
        {
            var jsonFormatter = new JsonMediaTypeFormatter();
            jsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.None;
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));
        }
    }
}
