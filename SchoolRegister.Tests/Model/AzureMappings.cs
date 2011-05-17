namespace SchoolRegister.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;

    using Moq;

    using NUnit.Framework;

    using SchoolRegister.Model.Abstract;
    using SchoolRegister.Model.Entities;
    using SchoolRegister.Model.Objects;
    using SchoolRegister.Model.Other;
    using SchoolRegister.Web.Controllers;

    [TestFixture]
    public class AzureMappings
    {

        [Test]
        public void Mappings()
        {

            Mapper.CreateMap<PersonSchema, Person>()
                    .ForMember(dest => dest.Pesel, opt => opt.MapFrom(source => source.PartitionKey));
            Mapper.AssertConfigurationIsValid();

            var schema = new PersonSchema
            {
                Name = "A",
                Surname = "B",
                PartitionKey = "000",    
            };

            var result = schema.MapInto<Person>();


            result.Name.ShouldEqual("A");
            result.Surname.ShouldEqual("B");
            result.Pesel.ShouldEqual("000");
        }


    }
}