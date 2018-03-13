using System;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain;
using Nethereum.RPC.Eth.DTOs;

namespace CryptoKitties.Net.Toolkit.Services
{
    using Models;
    using IRestUserService = Api.RestClient.IUserService;

    public class UserService : IUserService
    {
        public UserService(
            IRestUserService restUserService
            )
        {
            Guard.NotNull(restUserService, nameof(restUserService));
            _restService = restUserService;
        }

        private readonly IRestUserService _restService;

        public async Task<User> LoadUser(string walletAddress, bool loadTransactions = true)
        {
            throw new NotImplementedException();


            

        }

        public async Task LoadTransactions(User user)
        {
            await Task.Run(() => { });
        }
    }
}
