using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using azure_m.Services;

namespace azure_m.Test.Services
{
    [TestFixture]
    internal class AzureQueryTests
    {
        [Test]
        public void listResources()
        {
            var resQuery = new ResourcesQuery();
            var res = resQuery.listResources("", -1).Result;
            Assert.IsNotNull(res);
        }
    }
}
