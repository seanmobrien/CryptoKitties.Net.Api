using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Api;
using CryptoKitties.Net.Blockchain.RestClient;
using CryptoKitties.Net.Blockchain.RestClient.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CryptoKitties.Net.Toolkit.Tests.Integration
{
    [TestClass]
    public class LogQueryTests
    {


        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void OnTestInit()
        {
            Client = new EtherscanApiClient(new HttpClientRequestFactory());
            Factory = new LogRecordQueryFactory(Client);
            
        }
        private IEtherscanApiClient Client { get; set; }
        private ILogRecordQueryFactory Factory { get; set; }


        LogQueryRequestMessage MakeRequest()
        {
            return new LogQueryRequestMessage
            {
                Address = Globals.Contracts.Address.SiringAuction,
                FromBlock = "379224",
                ToBlock = "latest",
                Topics = new[] {"0x4fcc30d90a842164dd58501ab874a101a3749c3d4747139cefe7c876f4ccebd2"}
            };
        }




        [TestMethod]
        public void LogQuery_Returns_Some_Chunks()
        {
            const int MAX_CHUNNKS = 3;
            var logs = new List<LogRecord>();

            var target = Factory.Create(MakeRequest());

            LogRecord lastRecord = null;

            for (var idx = 0; idx < MAX_CHUNNKS; idx++)
            {
                var chunk = target.GetNextBlock().Result.ToArray();

                var firstIn = logs.FindIndex(x => x.TransactionHash == chunk[0].TransactionHash);


                TestContext.WriteLine($"Returned {chunk.Length} records, first existed - {firstIn}");
                logs.AddRange(chunk);
            }
            TestContext.WriteLine($"Wrote {logs.Count} records - \r\n\r\n{JsonConvert.SerializeObject(logs)}");
        }

    }
}
