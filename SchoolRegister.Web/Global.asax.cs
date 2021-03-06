﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SchoolRegister.Web
{
    using SchoolRegister.Web.Controllers;
    using SchoolRegister.Web.Infrastructure;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null, // Route name
                "Classes/{classCode}/Courses/{courseName}", // URL with parameters
                new
                {
                    controller = "CourseRealization",
                    action = "Index"
                });


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Setup.DependencyInjection();
            Setup.ObjectMappings();
            Setup.WindowsAzure();

            ValueProviderFactories.Factories.Add(new CurrentPanelValueProviderFactory()); 
        }
    }
}