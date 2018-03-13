using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Api.Models;
using CryptoKitties.Net.Toolkit.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;

namespace CryptoKitties.Net.Toolkit.Tests.Services
{
    using IRestUserService = Api.RestClient.IUserService;


    [TestClass]
    public class UserServiceTests
    {

        public TestContext TestContext { get; set; }

        private const string ValidAddress = "asd";

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
            return new UserService(RestUserService.MockObject);
        }


        [TestMethod]
        public void GetProfile_NoTx_ReturnsExpected()
        {
            RestUserService.Expects.One.Method(x => x.GetUser(ValidAddress))
                .WillReturn(Task.FromResult(new Profile { Address = ValidAddress }));

            var user = CreateTarget().LoadUser(ValidAddress, false).Result;
        }

    }
}
