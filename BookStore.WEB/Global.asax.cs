﻿using BookStore.BLL.Services;
using BookStore.WEB.Util;
using Ninject;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookStore.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Ninject
            ServiceModule serviceModule = new ServiceModule("BookContext");
            OrderModule orderModule = new OrderModule();
            var kernel = new StandardKernel(serviceModule, orderModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}