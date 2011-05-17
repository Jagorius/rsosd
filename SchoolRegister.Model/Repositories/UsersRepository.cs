namespace SchoolRegister.Model.Repositories
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;

    using SchoolRegister.Model.Abstract;
    using SchoolRegister.Model.Objects;
    using SchoolRegister.Model.Other;

    #endregion

    public class UsersRepository : IUsersRepository
    {
        private static readonly CloudStorageAccount Account;

        private readonly SchoolRegisterTableSeviceContext _context;

        static UsersRepository()
        {
            Account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
        }

        public UsersRepository()
        {
            string uri = Account.TableEndpoint.AbsoluteUri;
            StorageCredentials credentials = Account.Credentials;
            _context = new SchoolRegisterTableSeviceContext(uri, credentials)
            {
                RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1)), 
                IgnoreResourceNotFoundException = true, 
            };

            CloudTableClient.CreateTablesFromModel(typeof(SchoolRegisterTableSeviceContext), uri, credentials);
        }

        public SchoolRegisterTableSeviceContext ServiceContext
        {
            get
            {
                return _context;
            }
        }

        #region IUsersRepository Members

        public IPersonsCollection<Person> Persons
        {
            get
            {
                
                return new PersonsCollection(_context);
            }
        }

        #endregion
    }
}