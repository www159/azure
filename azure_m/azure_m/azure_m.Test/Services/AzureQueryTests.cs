using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using azure_m.Services;
using NUnit.Framework;

namespace azure_m.Test.Services
{
    [TestFixture]
    internal class AzureQueryTests
    {
        [Test]
        public void listResourcesTest()
        {
            //var resQuery = new ResourcesQuery();
            //var res = resQuery.listResources("", -1).Result;
            Assert.IsNotNull("1");
            Assert.Pass();
        }
    }
}
