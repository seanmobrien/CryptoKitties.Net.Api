using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoKitties.Net.Api.Tests.Unit.Unit.Blockchain
{
    [TestClass]
    public class ContractCallDataBuilderTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void ContractCallDataBuilder_BuildsGetGetty()
        {
            var builder = new ContractCallDataBuilder("getKitty")
                .AddParameter(523632);
            var actual = builder.EncodeData();
            TestContext.WriteLine($"Encoded data = [{actual}]");

        }
    }
}
