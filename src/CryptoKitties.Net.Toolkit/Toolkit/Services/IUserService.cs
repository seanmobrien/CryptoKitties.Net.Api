using System.Threading.Tasks;
using CryptoKitties.Net.Toolkit.Models;

namespace CryptoKitties.Net.Toolkit.Services
{
    public interface IUserService
    {
        Task<User> LoadUser(string walletAddress, bool loadTransactions = true);
        Task LoadTransactions(User user);
    }
}