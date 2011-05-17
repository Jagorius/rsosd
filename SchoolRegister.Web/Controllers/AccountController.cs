namespace SchoolRegister.Web.Controllers
{
    #region Usings

    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using System.Web.Security;

    #endregion

    public class LogOnViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class AccountController : Controller
    {
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // No point trying authentication if model is invalid 
                if (!Membership.ValidateUser(model.UserName, model.Password))
                {
                    ModelState.AddModelError(string.Empty, "Incorrect username or password");
                }
            }

            if (ModelState.IsValid)
            {
                // Grant cookie and redirect (to admin home if not otherwise specified) 
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
            }
            else
            {
                return View();
            }
        }
    }
}