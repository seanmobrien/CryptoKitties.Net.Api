using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// The <see cref="Kitty"/> class extends <see cref="KittySummary"/> to include additional information.
    /// </summary>
    [DataContract]
    public class Kitty
        : KittySummary
    {
        /// <summary>
        /// Message straight from the heart of this kitty to you.
        /// </summary>
        public string Bio { get; set; }
        /// <summary>
        /// <see cref="KittySummary"/> this kitty has participated in creating.
        /// </summary>
        [DataMember(Name = "children", EmitDefaultValue = false)]
        public KittySummary[] Children { get; set; }
        /// <summary>
        /// <see cref="KittySummary"/> this kitty has participated in creating.
        /// </summary>
        [DataMember(Name = "cattributes", EmitDefaultValue = false)]
        public CattributeInfo[] Cattributes { get; set; }
        /// <summary>
        /// <see cref="KittySummary"/> this kitty has participated in creating.
        /// </summary>
        [DataMember(Name = "enhanced_cattributes", EmitDefaultValue = false)]
        public EnhancedCattributeInfo[] EnhancedCattributes { get; set; }
    }
}