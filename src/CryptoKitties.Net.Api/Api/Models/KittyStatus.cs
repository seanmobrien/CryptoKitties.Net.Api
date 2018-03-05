using System;
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// The <see cref="KittyStatus"/> class is used to describe kitty properties.
    /// </summary>
    [DataContract]
    public class KittyStatus
    {
        /// <summary>
        /// Whether or not the kitty is ready to breed.
        /// </summary>
        [DataMember(Name="is_ready")]
        public bool IsReady { get; set; }
        /// <summary>
        /// Whether or not the kitty is currently gestating.
        /// </summary>
        [DataMember(Name="is_gestating")]
        public bool IsGestating { get; set; }
        /// <summary>
        /// An <see cref="Int64"/> containing the cooldown.
        /// </summary>
        [DataMember(Name="cooldown")]
        public Int64 Cooldown { get; set; }
        /// <summary>
        /// An <see cref="int"/> used to describe the 
        /// </summary>
        [DataMember(Name="cooldown_index")]
        public CooldownIndexType CooldownIndex { get; set; }
        /// <summary>
        /// A <see cref="WatchlistInfo"/> containing watch statistics.
        /// </summary>
        [DataMember(Name="watchlist")]
        public WatchlistInfo Watchlist { get; set; }
        /// <summary>
        /// A <see cref="PurrInfo"/> containing purr-stitics.
        /// </summary>
        [DataMember(Name="purrs")]
        public PurrInfo Purrs { get; set; }
    }
}
