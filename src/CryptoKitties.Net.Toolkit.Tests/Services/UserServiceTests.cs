using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Api;
using CryptoKitties.Net.Api.Models;
using CryptoKitties.Net.Api.RestClient;
using CryptoKitties.Net.Blockchain.RestClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using IUserService = CryptoKitties.Net.Toolkit.Services.IUserService;
using UserService = CryptoKitties.Net.Toolkit.Services.UserService;

namespace CryptoKitties.Net.Toolkit.Tests.Services
{
    using IRestUserService = Api.RestClient.IUserService;
    using RestUserService = Api.RestClient.UserService;


    [TestClass]
    public class UserServiceTests
    {

        public TestContext TestContext { get; set; }

        private const string ValidAddress = "0x5fa4879f2800b176d2f6d861be878aadfd1d5452";

        [TestInitialize]
        public void OnTestInitialize()
        {
            MockFactory = new MockFactory();
            RestUserService = MockFactory.CreateMock<IRestUserService>();
            

        }
        private MockFactory MockFactory { get; set; }
        private Mock<IRestUserService> RestUserService { get; set; }

        IUserService CreateTarget()
        {
            var http = new HttpClientRequestFactory();

            return new UserService(new RestUserService(http), new EtherscanApiClient(new HttpClientRequestFactory()));
        }


        [TestMethod]
        public void GetProfile_NoTx_ReturnsExpected()
        {
            RestUserService.Expects.One.Method(x => x.GetUser(ValidAddress))
                .WillReturn(Task.FromResult(new Profile { Address = ValidAddress }));

            var user = CreateTarget().LoadUser(ValidAddress, false).Result;
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void GetProfile_Tx_ReturnsExpected()
        {
            RestUserService.Expects.One.Method(x => x.GetUser(ValidAddress))
                .WillReturn(Task.FromResult(new Profile { Address = ValidAddress }));

            var user = CreateTarget().LoadUser(ValidAddress, true).Result;
            Assert.IsNotNull(user);
        }
    }
}
