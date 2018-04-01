using CryptoKitties.Net.Api.RestClient;
using CryptoKitties.Net.Blockchain;
using CryptoKitties.Net.Blockchain.RestClient;
using CryptoKitties.Net.Blockchain.RestClient.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cmp;

namespace CryptoKitties.Net.Api.Tests.Unit.Integration
{
    [TestClass]
    public class EtherscanApiIntegrationTests
    {
        public TestContext TestContext { get; set; }

        private const string KnownAddress = "0x5fa4879f2800b176d2f6d861be878aadfd1d5452";
        private const string KnownNickname = "captain crypto";


        IEtherscanApiClient CreateTarget()
        {
            var ret = new EtherscanApiClient(
                new HttpClientRequestFactory()
            );
            ret.SetApiKey("QE11FT94VDIYWB4S8C8YGMI64TYJE4HPZF");
            return ret;
        }

        [TestMethod]
        public void GetTransactions_ReturnsTransactions()
        {
            var target = CreateTarget();

            var data = target.GetTransactions(new TransactionQueryRequestMessage(KnownAddress));

            TestContext.WriteLine(JsonConvert.SerializeObject(data));

            Assert.IsNotNull(data, "null result");
        }
        [TestMethod]
        public void GetTransactions_ReturnsInternalTransactions()
        {
            var target = CreateTarget();

            var data = target.GetTransactions(new InternalTransactionQueryRequestMessage(KnownAddress));

            TestContext.WriteLine(JsonConvert.SerializeObject(data));

            Assert.IsNotNull(data, "null result");
        }
        [TestMethod]
        public void GetLogs_ReturnsTransactions()
        {
            var target = CreateTarget();

            var data = target.GetLogs(new LogQueryRequestMessage
            {
                Address = Globals.Contracts.Address.SiringAuction,
                FromBlock = "379224",
                ToBlock = "latest",
                Topics = new[] { "0x4fcc30d90a842164dd58501ab874a101a3749c3d4747139cefe7c876f4ccebd2" }
            });

            TestContext.WriteLine(JsonConvert.SerializeObject(data));

            Assert.IsNotNull(data, "null result");
        }

        [TestMethod]
        public void Call_GetKitty_ReturnsRawData()
        {
            var target = CreateTarget();

            var data = target.Call("0x06012c8cf97bead5deae237070f9587f8e7a266d", "getKitty", b => b.AddParameter(612439));
            TestContext.WriteLine(JsonConvert.SerializeObject(data.Result));
        }
        [TestMethod]
        public void Call_GetKitty_ReturnsKittyData()
        {
            var target = CreateTarget();
            var data = target.GetKitty(612439).Result;
            TestContext.WriteLine(JsonConvert.SerializeObject(data));
        }

        [TestMethod]
        public void Call_GetKitty_ReturnsKittyGenes()
        {

            var target = CreateTarget();
            var data = target.GetKitty(612439).Result;
            var genes = new CryptoKitties.Net.GeneScience.GeneSplicer(data.Genes);
            TestContext.WriteLine($"Hex: {genes.Genes.ToString(16)}\r\nBinary: {genes.Binary}\r\nKai: {genes.Kai}");
            TestContext.WriteLine(JsonConvert.SerializeObject(data));
            TestContext.WriteLine($"The Other Kai Is: {GeneScience.GeneScienceUtilities.ComputeKai2(genes.Genes)}");
        }
        [TestMethod]
        public void Call_GetKitty_636658_ReturnsKittyGenes()
        {

            var target = CreateTarget();
            var data = target.GetKitty(636658).Result;
            var genes = new CryptoKitties.Net.GeneScience.GeneSplicer(data.Genes);
            TestContext.WriteLine($"Hex: {genes.Genes.ToString(16)}\r\nBinary: {genes.Binary}\r\nKai: {genes.Kai}");
            TestContext.WriteLine(JsonConvert.SerializeObject(data));
        }
    }
}
