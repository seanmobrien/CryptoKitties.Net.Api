using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain;
using CryptoKitties.Net.Blockchain.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CryptoKitties.Net.Api.Tests.Unit.Integration
{
    [TestClass]
    public class NethereumTests
    {
        IWeb3Client CreateTarget(bool local = false)
        {
            var url = local
                ? "http://10.69.0.100:8545"
                : "https://mainnet.infura.io/rpvNv6mG4pSh7iTZdosU";
            var web3 = new Web3(url);
            return web3.Abstract();
        }

        public TestContext TestContext { get; set; }
        [TestMethod]
        public void GetEvent_WIthLogs_ReturnsData()
        {
            var w3 = CreateTarget(true);

            var contract = w3.Eth.GetKittyContract(CryptoKittyContractType.Siring);
            var evt = contract.GetKittyEvent(KittyEventType.AuctionCreated);
            var f = evt.CreateFilterAsync(fromBlock: new BlockParameter(4608825)).Result;
            var data = evt.GetFilterChanges<AuctionCreatedEventData>(f).Result;
            TestContext.WriteLine(JsonConvert.SerializeObject(data));
        }
        [TestMethod]
        public void GetEvent_WIthLogs_TryOtherApproach()
        {
            var w3 = CreateTarget();

            var contract = w3.Eth.GetKittyContract(CryptoKittyContractType.Sales);
            var evt = contract.GetKittyEvent(KittyEventType.AuctionCreated);
            var fi = evt.CreateFilterInput(fromBlock: new BlockParameter(4608825), toBlock: new BlockParameter(4608829));

            var logs = w3.Eth.Filters.GetLogs.SendRequestAsync(fi).Result;

            TestContext.WriteLine(JsonConvert.SerializeObject(logs));
        }
    }
}
