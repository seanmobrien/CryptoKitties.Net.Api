using Org.BouncyCastle.Math;
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// The <see cref="BlockSummary"/> class summarizes a block on the ethereum blockchain.
    /// </summary>
    [DataContract]
    public class BlockSummary
    {
        /// <summary>
        /// The block identifier.
        /// </summary>
        [DataMember(Name = "id")]
        public BigInteger Id { get; set; }
        /// <summary>
        /// The hash
        /// </summary>
        [DataMember(Name = "hash")]
        public BigInteger Hash { get; set; }
    }
}
