using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// The <see cref="KittySummary"/> class contains high-level kitty information.
    /// </summary>
    [DataContract]
    [KnownType(typeof(Kitty))]
    public class KittySummary : KittyBase
    {
        /// <summary>
        /// An optional <see cref="PurrInfo"/> summarizing likes given to this kitty.
        /// </summary>
        [DataMember(Name="purrs")]
        public PurrInfo Purrs { get; set; }
        /// <summary>
        /// An optional <see cref="WatchlistInfo"/> summarizing users watching this kitty.
        /// </summary>
        [DataMember(Name="watchlist")]
        public WatchlistInfo Watchlist { get; set; }
        /// <summary>
        /// The sire of this kitty.
        /// </summary>
        [DataMember(Name="sire")]       
        public RelatedKitty Sire { get; set; }
        /// <summary>
        /// The matron of this kitty.
        /// </summary>
        [DataMember(Name="matron")]
        public RelatedKitty Matron { get; set; }
        /// <summary>
        /// Any active auction the kitty currently is participating in.
        /// </summary>
        [DataMember(Name="auction")]
        public Auction Auction { get; set; }
    }
}
