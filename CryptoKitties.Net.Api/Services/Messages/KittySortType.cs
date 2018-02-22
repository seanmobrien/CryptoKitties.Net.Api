using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Services.Messages
{
    [DataContract]
    public enum KittySortType
    {
        /// <summary>
        /// Indicates kitties should be sorted by age.
        /// </summary>
        [EnumMember]
        Age = 0,
        /// <summary>
        /// Indicates kitties should be sorted by price.  
        /// </summary>
        /// <remarks>When this value is set the orderBy query parameter will be set to current_price.</remarks>
        [EnumMember]
        Price = 1,
        /// <summary>
        /// Indicates kitties should be sorted by the number of purrs they have received.
        /// </summary>
        [EnumMember]
        Purrs = 2

    }
}
