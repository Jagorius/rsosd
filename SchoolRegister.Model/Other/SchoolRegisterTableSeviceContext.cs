namespace SchoolRegister.Model.Other
{
    #region Usings

    using System.Linq;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;

    using SchoolRegister.Model.Entities;

    #endregion

    public class SchoolRegisterTableSeviceContext : TableServiceContext
    {
        

        public SchoolRegisterTableSeviceContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {
        }

        public IQueryable<PersonSchema> PersonSchemas
        {
            get
            {
                return CreateQuery<PersonSchema>(TableNameOf.PersonSchema);
            }
        }
    }
}