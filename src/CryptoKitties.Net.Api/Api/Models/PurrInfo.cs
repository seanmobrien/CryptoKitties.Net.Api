using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// Describes purr-related info
    /// </summary>
    [DataContract]
    public class PurrInfo
    {
        /// <summary>
        /// Total number of purrs this kitty has recieved
        /// </summary>
        [DataMember(Name = "purrs")]
        public long Purrs { get; set; }
        /// <summary>
        /// When logged in, whether or not you have purred the kitty
        /// </summary>
        [DataMember(Name = "is_purred", EmitDefaultValue = false)]
        public bool? IsPurred { get; set; }
    }
}