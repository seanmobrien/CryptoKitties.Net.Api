using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain.Models;
using CryptoKitties.Net.Toolkit.Models;

namespace CryptoKitties.Net.Toolkit.Services
{
    public interface IUserService
    {
        Task<User> LoadUser(string walletAddress, bool loadTransactions = true);
        Task<IEnumerable<IGrouping<string, Transaction>>> LoadTransactions(string walletAddress);
    }
}