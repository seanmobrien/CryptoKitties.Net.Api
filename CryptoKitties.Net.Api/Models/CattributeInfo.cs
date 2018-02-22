
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// The <see cref="CattributeInfo"/> class summarizes known cattributes.
    /// </summary>
    [DataContract]
    [KnownType(typeof(EnhancedCattributeInfo))]
    public class CattributeInfo
    {
        /// <summary>
        /// A <see cref="CattributeType"/> value identifying the general category.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public CattributeType? Type { get; set; }
        /// <summary>
        /// Cattribute name.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }
        /// <summary>
        /// Total number of cats with this cattribute.
        /// </summary>
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public long? Total { get; set; }
    }
}
