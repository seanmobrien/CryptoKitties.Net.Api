using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// The <see cref="EnhancedCattributeInfo"/> class extends <see cref="CattributeInfo"/> by including details on it&apos;s origin.
    /// </summary>
    [DataContract]
    public class EnhancedCattributeInfo
        : CattributeInfo
    {
        /// <summary>
        /// The id of the kitty this cattribute was introduced by.
        /// </summary>
        [DataMember(Name = "kittyId")]
        public long KittyId { get; set; }
        /// <summary>
        /// How manny other kitties in this line have had this mewtation already.
        /// </summary>
        [DataMember(Name = "position")]
        public int Position { get; set; }
    }
}