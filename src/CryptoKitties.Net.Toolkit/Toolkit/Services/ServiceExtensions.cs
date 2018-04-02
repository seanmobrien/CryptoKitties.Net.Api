using System.Collections.Generic;
using System.Linq;
using CryptoKitties.Net.Blockchain.Models;

namespace CryptoKitties.Net.Toolkit.Services
{
    /// <summary>
    /// The <see cref="ServicesExtensions"/> class extends the services namespace.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Fitlers crypto-kitty related transactions from <see cref="instance"/>.
        /// </summary>
        /// <param name="instance">An <see cref="IEnumerable{T}"/> of <see cref="Transaction"/> data.</param>
        /// <param name="watchedAddresses">An optional <see cref="IEnumerable{T}"/> of <see cref="string"/> values identifying additional addresses to watch.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of grouped <see cref="Transaction"/> data.</returns>
        public static IEnumerable<IGrouping<string, Transaction>> GetKittyTransactions(this IEnumerable<Transaction> instance, IEnumerable<string> watchedAddresses = default(IEnumerable<string>))
        {
            var kittyContracts = (watchedAddresses ?? new string[0])
                .Union(new[] {Globals.Contracts.Address.SalesAuction, Globals.Contracts.Address.SiringAuction})
                .ToArray();
            return
                (instance ?? new Transaction[0])
                .Where(x => kittyContracts.Any(y => y == x.From))
                .GroupBy(x => x.From);

        }
    }
}
