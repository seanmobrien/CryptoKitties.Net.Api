using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// Watchlist details
    /// </summary>
    [DataContract]
    public class WatchlistInfo
    {
        /// <summary>
        /// Number of users watching this kitty
        /// </summary>
        [DataMember(Name = "count")]
        public long Count { get; set; }
        /// <summary>
        /// When signed in, whether or not the current user is watching the kitty
        /// </summary>
        [DataMember(Name = "isWatchListed", EmitDefaultValue = false)]
        public bool? IsWatchListed { get; set; }
    }
}
