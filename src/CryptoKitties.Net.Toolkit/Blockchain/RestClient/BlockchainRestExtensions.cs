using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain.RestClient.Messages;
using CryptoKitties.Net.Exceptions;

namespace CryptoKitties.Net.Blockchain.RestClient
{
    public static class BlockchainRestExtensions
    {
     
        public static ulong GetBlockNumber(this LogRecord instance)
        {
            return Convert.ToUInt64(instance.BlockNumber,  16);
        }
    }
}
