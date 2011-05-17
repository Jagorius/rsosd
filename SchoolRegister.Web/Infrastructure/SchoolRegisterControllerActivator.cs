namespace SchoolRegister.Web.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Routing;

    using SchoolRegister.Model.Abstract;
    using SchoolRegister.Model.Objects;
    using SchoolRegister.Web.Controllers;

    public class SchoolRegisterControllerActivator : IControllerActivator
    {

        public IController Create(RequestContext requestContext, Type controllerType)
        {


            if (controllerType.Equals(typeof(CourseRealizationController)))
            {
                string classCode = (string)requestContext.RouteData.Values["classCode"];
                string courseName = (string)requestContext.RouteData.Values["courseName"];
                var courseRealization = new CourseRealization(classCode, courseName);

                return new CourseRealizationController(courseRealization);
            }



            return DependencyResolver.Current
                .GetService(controllerType) as IController;
        }
    }
}