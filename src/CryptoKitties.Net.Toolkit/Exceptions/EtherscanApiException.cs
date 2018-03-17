using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain.RestClient.Messages;

namespace CryptoKitties.Net.Exceptions
{
    [Serializable]
    public class EtherscanApiException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public EtherscanApiException()
        {
        }

        public EtherscanApiException(EtherscanResponseMessage message) : base(message.Message)
        {
        }

        public EtherscanApiException(string message, Exception inner) : base(message, inner)
        {
        }

        protected EtherscanApiException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
