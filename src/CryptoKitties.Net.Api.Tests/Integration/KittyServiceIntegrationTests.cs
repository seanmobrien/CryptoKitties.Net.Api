using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Api.Models;
using CryptoKitties.Net.Api.RestClient;
using CryptoKitties.Net.Api.RestClient.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CryptoKitties.Net.Api.Tests.Unit.Integration
{
    [TestClass]
    public class KittyServiceIntegrationTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Query_ReturnsKittyData()
        {
            var target = new KittyService();

            var data = target.GetKitties(new KittyQueryRequestMessage()).Result;

            TestContext.WriteLine(JsonConvert.SerializeObject(data));
        }
        [TestMethod]
        public void Get_GoodId_ReturnsKittyData()
        {
            var target = new KittyService();

            var data = target.GetKitty(435234).Result;
            Assert.IsNotNull(data);

            TestContext.WriteLine(JsonConvert.SerializeObject(data));
        }
        [TestMethod]
        public void Get_BigBigId_ReturnsNullValue()
        {
            var target = new KittyService();

            var data = target.GetKitty(99999999).Result;
            Assert.IsNull(data);
        }
    }
}
