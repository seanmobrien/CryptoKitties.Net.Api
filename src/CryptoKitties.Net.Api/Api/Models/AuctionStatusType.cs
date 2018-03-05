using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// Auction Status
    /// </summary>
    [DataContract]
    public enum AuctionStatusType
    {
        /// <summary>
        /// Unknown or unrecognized value
        /// </summary>
        [EnumMember]
        Unkown = 0,
        /// <summary>
        /// Open / active auction
        /// </summary>
        [EnumMember(Value="open")]
        Open = 1,
        /// <summary>
        /// Closed / completed auction
        /// </summary>
        [EnumMember(Value="closed")]
        Closed = 2
    }
}
