using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// The <see cref="AuctionType"/> enum lists available auction types.
    /// </summary>
    [DataContract]
    public enum AuctionType
    {
        /// <summary>
        /// Unknown or unrecognized.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Siring auction
        /// </summary>
        [EnumMember(Value = "sire")]
        Sire = 1,
        /// <summary>
        /// Sale auction
        /// </summary>
        [EnumMember(Value = "sale")]
        Sale = 2
    }
}
