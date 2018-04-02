using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain.RestClient.Messages;

namespace CryptoKitties.Net.Blockchain.RestClient
{
    public interface ILogRecordQuery
    {
        void Reset();
        Task<IEnumerable<LogRecord>> GetNextBlock();
    }
}