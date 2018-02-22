using System;
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// The <see cref="Auction"/> class describes a kitty auction.
    /// </summary>
    [DataContract]
    public class Auction
    {
        /// <summary>
        /// Auction identifier
        /// </summary>
        [DataMember(Name = "id")]
        public Int64 Id { get; set; }
        /// <summary>
        /// Auction start price in GWEI.
        /// </summary>
        [DataMember(Name = "start_price")]
        public Int64 StartPrice { get; set; }
        /// <summary>
        /// Auction end price in GWEI.
        /// </summary>
        [DataMember(Name = "end_price")]
        public Int64 EndPrice { get; set; }
        /// <summary>
        /// The block the auction begins
        /// </summary>
        [DataMember(Name = "start_time")]
        public Int64 StartTime { get; set; }
        /// <summary>
        /// The block that the auction will end
        /// </summary>
        [DataMember(Name = "end_time")]
        public Int64 EndTime { get; set; }
        /// <summary>
        /// The current kitty price in GWEI
        /// </summary>
        [DataMember(Name = "current_price")]
        public Int64 CurrentPrice { get; set; }
        /// <summary>
        /// The number of blocks the auction will last.
        /// </summary>
        [DataMember(Name = "duration")]       
        public Int64 Duration { get; set; }
        /// <summary>
        /// An <see cref="AuctionStatusType"/> identifying the auction status.
        /// </summary>
        [DataMember(Name = "status")]
        public AuctionStatusType Status { get; set; }
        /// <summary>
        /// An <see cref="AuctionType"/> identifying the auction type (Sire or Sell).
        /// </summary>
        [DataMember(Name = "type")]
        public AuctionType Type { get; set; }
        /// <summary>
        /// A <see cref="Profile"/> describing the current owner of the kitty.
        /// </summary>
        [DataMember(Name = "seller")]
        public Profile Seller { get; set; }
        /// <summary>
        /// A <see cref="KittySummary"/> describing the kitty being auctioned.
        /// </summary>
        [DataMember(Name = "kitty")]
        public KittySummary Kitty { get; set; }
    }
}
