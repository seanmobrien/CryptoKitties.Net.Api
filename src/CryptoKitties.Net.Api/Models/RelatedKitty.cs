using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// The <see cref="RelatedKitty"/> class is used to describe a related kitty, such as a child or matron.
    /// </summary>
    [DataContract]
    public class RelatedKitty
        : KittyBase
    {
        /// <summary>
        /// Owner&apos;s wallet address
        /// </summary>
        /// <remarks>This is usually set on related kitties (matron, sire, children).</remarks>
        [DataMember(Name = "owner_wallet_address", EmitDefaultValue = false)]
        public string OwnerWalletAddress { get; set; }
    }
}