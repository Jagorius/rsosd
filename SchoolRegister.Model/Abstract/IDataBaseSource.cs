namespace SchoolRegister.Model.Abstract
{
    using System.Linq;

    using SchoolRegister.Model.Entities;

    public interface IDataBaseSource
    {
        IQueryable<PersonSchema> PersonSchemas { get; }
    }
}