namespace SchoolRegister.Model.Entities
{
    #region Usings

    using Microsoft.WindowsAzure.StorageClient;

    using SchoolRegister.Model.Abstract;

    #endregion

    public class PersonSchema : TableServiceEntity, ISchema
    {
        /// <summary>
        /// Person's Pesel
        /// </summary>
        public override string PartitionKey { get; set; }

        public override sealed string RowKey { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}