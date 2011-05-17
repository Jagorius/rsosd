// Author: Piotr Trzpil

namespace SchoolRegister.Web.Controllers
{
    #region Usings

    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Routing;

    using SchoolRegister.Web.Models;

    #endregion

    public class HomeController : Controller
    {


       // [Authorize(Roles = "Admin")] 
        public ActionResult Index()
        {
            return this.View();
        }







        public ActionResult MainMenu(string currentPage)
        {


            var menu = this.CreateMainMenu(currentPage);
            return this.View(menu);
        }


//        public ActionResult Panels(string currentPage)
//        {
//
//
//            var menu = this.CreateMainMenu(currentPage);
//            return this.View(menu);
//        }
//








        private IEnumerable<MenuLink> CreateMainMenu(string currentPage)
        {
            yield return CreateLink("Strona Główna", "Home", currentPage == "Home");
            yield return CreateLink("Email", "Email", currentPage == "Email");

            if (true)
            {
                yield return CreateLink("Logowanie", "Account", false);
            }
            else
            {
                yield return CreateLink("Wyloguj", "Account", false);
            }
        }








        private MenuLink CreateLink(string text, string controllerName, bool isSelected)
        {
            return new MenuLink
            {
                Text = text,
                RouteValues = new RouteValueDictionary(
                    new
                    {
                        controller = controllerName
                    }),
                IsSelected = isSelected
            };
        }
    }

   



    internal enum Privileges
    {
        Admin,
        Headmaster,
        Teacher, 
        Guardian, 
        Student
    }

}