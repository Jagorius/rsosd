namespace SchoolRegister.Web.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.SessionState;

    using Ninject;
    using Ninject.Syntax;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IResolutionRoot root;

        public NinjectDependencyResolver(IResolutionRoot root)
        {
            this.root = root;
        }

        public object GetService(Type serviceType)
        {
            return this.root.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.root.GetAll(serviceType);
        }
    }

//
//
//    class ss : DefaultControllerFactory
//    {
//
//        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
//        {
//            
//
//            requestContext.
//
//        }
//    }
}