namespace SchoolRegister.Model.Objects
{
    using SchoolRegister.Model.Abstract;

    public class Person : IModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Pesel { get; set; }



    }
}