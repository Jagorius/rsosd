namespace SchoolRegister.Model.Abstract
{
    using System.Collections.Generic;

    using SchoolRegister.Model.Objects;

    public interface IUsersRepository
    {
        IPersonsCollection<Person> Persons
        {
            get;
        }
    }
}