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
    public class AuctionServiceIntegrationTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void AuctionService_Get_ReturnsAuctionData()
        {
            var target = new AuctionService();

            var data = target.GetAuctions(new AuctionQueryRequestMessage(AuctionType.Sire)).Result;

            TestContext.WriteLine(JsonConvert.SerializeObject(data));

        }
    }
}
