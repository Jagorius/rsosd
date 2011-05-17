using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolRegister.Web.Controllers
{
    using SchoolRegister.Model.Abstract;
    using SchoolRegister.Model.Objects;

    public class UsersController : Controller
    {

        private IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }

        public ActionResult Index()
        {
            return View(_usersRepository.Persons);
        }


        public ActionResult Add()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            _usersRepository.Persons.Add(person);

            return RedirectToAction("Index");
        }


        public ActionResult Remove(string pesel)
        {

            _usersRepository.Persons.Remove(new Person
            {
                Pesel = pesel
            });

            return RedirectToAction("Index");
        }



    }
}
