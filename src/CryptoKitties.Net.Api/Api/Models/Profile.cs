using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// Public User profile
    /// </summary>
    [DataContract]
    public class Profile
    {
        /// <summary>
        /// User&apos;s wallet address
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }
        /// <summary>
        /// Nickname
        /// </summary>
        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }
        /// <summary>
        /// Profile image index
        /// </summary>
        [DataMember(Name = "image")]
        public long Image { get; set; }

        public override int GetHashCode()
        {
            return Address?.GetHashCode() ?? 0;
        }
    }
}
