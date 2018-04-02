using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain.RestClient.Messages;

namespace CryptoKitties.Net.Blockchain.RestClient
{
    public interface ILogRecordQueryFactory
    {
        ILogRecordQuery Create(LogQueryRequestMessage query);
    }

    public class LogRecordQueryFactory : ILogRecordQueryFactory
    {
        public LogRecordQueryFactory(IEtherscanApiClient client)
        {
            Guard.NotNull(client, nameof(client));
            Client = client;
        }
        protected IEtherscanApiClient Client { get;  }


        public ILogRecordQuery Create(LogQueryRequestMessage query)
        {
            Guard.NotNull(query, nameof(query));
            return new LogRecordQuery(Client, query);
        }

    }
}
