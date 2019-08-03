﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft;
using Unity;
using Unity.Lifetime;
using Prueba_TEV.Models;
using Prueba_TEV.Resolver;

namespace Prueba_TEV
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
