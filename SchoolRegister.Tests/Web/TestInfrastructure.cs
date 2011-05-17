namespace SchoolRegister.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;

    using SchoolRegister.Web;

    using NUnit.Framework;

    using SchoolRegister.Web.Infrastructure;

    [TestFixture]
    public class TestInfrastructure
    {

        [Test]
        public void Mappings_Should_Be_Valid()
        {
            Setup.ObjectMappings();
            Mapper.AssertConfigurationIsValid();
        }
    }
}