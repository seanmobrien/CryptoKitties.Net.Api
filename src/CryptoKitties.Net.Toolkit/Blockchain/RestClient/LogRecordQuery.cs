using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain.RestClient.Messages;

namespace CryptoKitties.Net.Blockchain.RestClient
{
    public class LogRecordQuery : ILogRecordQuery
    {
        public LogRecordQuery(IEtherscanApiClient client, LogQueryRequestMessage query)
        {
            Client = client;
            // Copy query
            OriginalQuery = new LogQueryRequestMessage(query);
            Reset();
        }
        protected IEtherscanApiClient Client { get; }
        protected LogQueryRequestMessage OriginalQuery { get; }
        protected IList<LogRecord> LastResultset { get; private set; }
        protected LogQueryRequestMessage NextQuery { get; private set; }

        public void Reset()
        {
            NextQuery = OriginalQuery;
        }


        public async Task<IEnumerable<LogRecord>> GetNextBlock()
        {
            if (NextQuery == null)
            {
                return new LogRecord[0];
            }
            // Query response and assert success
            var response = await Client.GetLogs(NextQuery);
            response.Assert();
            if (response.Result.Count == 0 
                || LastResultset?[0].TransactionHash == response.Result[0].TransactionHash)
            {
                NextQuery = null;
                LastResultset = null;
                return new LogRecord[0];
            }
            // Find first transaction hash by search
            var lastLog = response.Result[response.Result.Count - 1];
            NextQuery.FromBlock = lastLog.GetBlockNumber().ToString();

            LastResultset = response.Result;
            return response.Result;
        }

        internal const int MaxReturned = 1000;

    }
}
