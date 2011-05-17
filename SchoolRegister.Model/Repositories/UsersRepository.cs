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

    /// <summary>
    /// Z tej klasy ustawienia azure pójdą gdzie indziej.
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        private static readonly CloudStorageAccount Account;

        private readonly AzureTablesSource _context;

        static UsersRepository()
        {
            Account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
        }

        public UsersRepository()
        {
            string uri = Account.TableEndpoint.AbsoluteUri;
            StorageCredentials credentials = Account.Credentials;
            _context = new AzureTablesSource(uri, credentials)
            {
                RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1)), 
                IgnoreResourceNotFoundException = true, 
            };

            CloudTableClient.CreateTablesFromModel(typeof(AzureTablesSource), uri, credentials);
        }

        public AzureTablesSource ServiceContext
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
                
                return new AzureAbstractionCollection(_context);
            }
        }

        #endregion
    }
}