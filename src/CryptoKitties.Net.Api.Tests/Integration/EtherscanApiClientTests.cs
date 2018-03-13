using CryptoKitties.Net.Api.RestClient;
using CryptoKitties.Net.Blockchain.RestClient;
using CryptoKitties.Net.Blockchain.RestClient.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CryptoKitties.Net.Api.Tests.Unit.Integration
{
    [TestClass]
    public class EtherscanApiIntegrationTests
    {
        public TestContext TestContext { get; set; }

        private const string KnownAddress = "0x5fa4879f2800b176d2f6d861be878aadfd1d5452";
        private const string KnownNickname = "captain crypto";


        EtherscanApiClient CreateTarget()
        {
            return new EtherscanApiClient(
                new HttpClientRequestFactory()
            );
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
    }
}
