namespace SchoolRegister.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NUnit.Framework;

    public static class TestExtensions
    {
        public static void ShouldEqual(this object obj, object another)
        {
            Assert.AreEqual(obj, another);
        }
    }
}