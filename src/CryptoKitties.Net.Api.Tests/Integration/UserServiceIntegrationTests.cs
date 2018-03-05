using CryptoKitties.Net.Api.RestClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CryptoKitties.Net.Api.Tests.Unit.Integration
{
    [TestClass]
    public class UserServiceIntegrationTests
    {
        public TestContext TestContext { get; set; }

        private const string KnownAddress = "0x5fa4879f2800b176d2f6d861be878aadfd1d5452";
        private const string KnownNickname = "captain crypto";

        [TestMethod]
        public void Get_ReturnsCattributeData()
        {
            var target = new UserService();

            var data = target.GetUser(KnownAddress).Result;

            TestContext.WriteLine(JsonConvert.SerializeObject(data));

            Assert.IsNotNull(data, "null result");
            Assert.AreEqual(KnownNickname, data.Nickname);
        }
    }
}
