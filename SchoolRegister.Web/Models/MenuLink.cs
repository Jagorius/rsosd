namespace SchoolRegister.Web.Models
{
    using System;
    using System.Web.Routing;

    public class MenuLink
    {
        public string Text { get; set; }

        public RouteValueDictionary RouteValues { get; set; }

        public bool IsSelected { get; set; }
 
    }
}