using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Api.Models;
using CryptoKitties.Net.Api.Services;
using CryptoKitties.Net.Api.Services.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CryptoKitties.Net.Api.Tests.Unit.Integration
{
    [TestClass]
    public class CattributeServiceIntegrationTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Get_ReturnsCattributeData()
        {
            var target = new CattributeService();

            var data = target.GetCattributes(new CattributeQueryRequestMessage { Total = true }).Result.ToArray();

            Assert.IsTrue(data.All(x => x.Type != CattributeType.Unknown));

            TestContext.WriteLine(JsonConvert.SerializeObject(data));

        }
    }
}
