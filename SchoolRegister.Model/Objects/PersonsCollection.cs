namespace SchoolRegister.Model.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SchoolRegister.Model.Entities;
    using SchoolRegister.Model.Other;
    using SchoolRegister.Model.Repositories;

    public class AzureAbstractionCollection : AzureAbstractionCollection<Person>
    {
        public AzureAbstractionCollection(AzureTablesSource context)
            : base(context)
        {
            
        }



        public override void Add(Person person)
        {
//            var schema = new PersonSchema
//            {
//                Name = person.Name,
//                Surname = person.Surname,
//                PartitionKey = person.Pesel,
//            };


            var schema = person.MapInto<PersonSchema>();

            Context.AddObject(TableNameOf.PersonSchema, schema);
            Context.SaveChanges();
        }

        public override void Update(Person item)
        {
            throw new NotImplementedException();
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        private ICollection<Person> GetAllPersons()
        {
            return Context.PersonSchemas.ToList().Select(
                    account => PersonFrom(account)).ToList();
        }

        private bool TryGetOne(string pesel, out PersonSchema schema)
        {

            schema = (from p in Context.PersonSchemas
                      where p.PartitionKey.Equals(pesel)
                         select p).FirstOrDefault();

            if (schema == null)
            {
         
                return false;
            }

            return true;
        }

        private Person PersonFrom(PersonSchema schema)
        {

//            return new Person
//            {
//                Pesel = schema.PartitionKey,
//                Name = schema.Name,
//                Surname = schema.Surname
//            };

            return schema.MapInto<Person>();

        }



        public override bool Contains(Person item)
        {
            var persons = from accountSchema in Context.PersonSchemas
            where accountSchema.PartitionKey.Equals(item.Pesel)
            select accountSchema;

            return persons.Count() > 0;
        }

        public bool Remove(string pesel)
        {
            if (pesel == null)
            {
                throw new ArgumentNullException();
            }

            PersonSchema schema;
            if (TryGetOne(pesel, out schema))
            {
                Context.DeleteObject(schema);

                var response = Context.SaveChanges();

                Console.Out.WriteLine(response);

                return true;

            }
            return false;

        }

        public override bool Remove(Person person)
        {
            return Remove(person.Pesel);
        }

        public override IEnumerator<Person> GetEnumerator()
        {
            
            return GetAllPersons().GetEnumerator();
        }
        



    }
}