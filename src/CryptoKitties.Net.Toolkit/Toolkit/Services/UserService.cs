using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain;
using CryptoKitties.Net.Blockchain.Models;
using CryptoKitties.Net.Blockchain.RestClient;
using CryptoKitties.Net.Blockchain.RestClient.Messages;
using CryptoKitties.Net.Exceptions;
using Newtonsoft.Json;

namespace CryptoKitties.Net.Toolkit.Services
{
    using Models;
    using IRestUserService = Api.RestClient.IUserService;

    public class UserService : IUserService
    {
        public UserService(
            IRestUserService restUserService,
            IEtherscanApiClient etherscanApi
            )
        {
            Guard.NotNull(restUserService, nameof(restUserService));
            _restService = restUserService;
            _etherscanApi = etherscanApi;
        }

        private readonly IEtherscanApiClient _etherscanApi;
        private readonly IRestUserService _restService;

        public async Task<User> LoadUser(string walletAddress, bool loadTransactions = true)
        {
            var userTask = _restService.GetUser(walletAddress);
            var txTask = loadTransactions ? LoadTransactions(walletAddress) : Task.FromResult(default(IEnumerable<IGrouping<string, Transaction>>));

            var profile = await userTask;
            if (profile == null) return null;
            var user = new User(profile)
            {
                InternalTranactions = (await txTask).ToDictionary(x => x.Key, x => x.ToArray())
            };


            return user;
        }

        public async Task<IEnumerable<IGrouping<string, Transaction>>> LoadTransactions(string walletAddress)
        {
            var internalTxTask = _etherscanApi.GetTransactions(new InternalTransactionQueryRequestMessage(walletAddress));
            // note: need to get external for outgiong transfers
            var response = await internalTxTask;
            if (!response.IsSuccess()) {  throw new EtherscanApiException(response); }
            return response.Result.GetKittyTransactions();
        }




        


    }
    public class KittyTransactionState
    {
        public KittyTransactionState(IEnumerable<IGrouping<string, Transaction>> input)
        {
            Transactions = input.ToList();
            var blocks = Transactions.SelectMany(x => x).Select(x => x.BlockNumber).AsQueryable();
            MaxBlock = blocks.Max();
            MinBlock = blocks.Min();
        }

        public IList<IGrouping<string, Transaction>> Transactions { get; }
        public IEnumerable<Transaction> Sales => GetTransactions(Globals.Contracts.Address.SalesAuction);
        public IEnumerable<Transaction> Sires => GetTransactions(Globals.Contracts.Address.SiringAuction);
        public long MaxBlock { get; }
        public long MinBlock { get; }



        private IEnumerable<Transaction> GetTransactions(string key)
        {
            return ((IEnumerable<Transaction>)Transactions.FirstOrDefault(y => y.Key == key)) ?? new Transaction[0];
        }
    }
}
