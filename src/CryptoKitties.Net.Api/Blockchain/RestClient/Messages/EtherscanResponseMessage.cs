
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Blockchain.RestClient.Messages
{
    [DataContract]
    [KnownType(typeof(EtherscanResponseMessage<>))]
    public class EtherscanResponseMessage
    {
        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "message")]
        public string Message{ get; set; }

        public bool IsSuccess()
        {
            return Status == 1;
        }
    }

    /// <summary>
    /// The <see cref="EtherscanResponseMessage{TResult}"/> reporesents an etherscan.io api reponse.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    [DataContract]
    public class EtherscanResponseMessage<TResult> : EtherscanResponseMessage
    {
        [DataMember(Name="result")]
        public TResult Result { get; set; }
    }
}
