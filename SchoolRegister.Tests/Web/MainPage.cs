namespace SchoolRegister.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;

    using NUnit.Framework;

    using SchoolRegister.Model.Abstract;
    using SchoolRegister.Model.Objects;
    using SchoolRegister.Web.Controllers;

    [TestFixture]
    public class UserManagement
    {

        [Test]
        public void User_Can_Be_Added()
        {
            var users = new FakePersonsCollection<Person>();

            var mock = new Mock<IUsersRepository>();
            mock.Setup(x => x.Persons).Returns(users);

            var controller = new UsersController(mock.Object);

            var person = new Person
                {
                    Name = "Jan",
                    Surname = "A",
                    Pesel = "00"
                };

            controller.Add(person);
                

            users.Count.ShouldEqual(1);
            users.First().ShouldEqual(person);
        }


    }
}