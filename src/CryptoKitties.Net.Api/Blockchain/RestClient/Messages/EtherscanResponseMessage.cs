
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Blockchain.RestClient.Messages
{
    /// <summary>
    /// The <see cref="EtherscanResponseMessage{TResult}"/> reporesents an etherscan.io api reponse.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    [DataContract]
    public class EtherscanResponseMessage<TResult>
    {
        [DataMember(Name = "status")]
        public int Status { get; set; }
        [DataMember(Name = "message")]
        public string Message{ get; set; }
        [DataMember(Name="result")]
        public TResult Result { get; set; }
    }
}
