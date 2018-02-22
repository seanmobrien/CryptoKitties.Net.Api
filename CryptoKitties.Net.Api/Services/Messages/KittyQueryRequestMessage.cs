using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Services.Messages
{
    /// <summary>
    /// The <see cref="KittyQueryRequestMessage"/> class extends <see cref="QueryRequestMessageBase"/> for kitty queries.
    /// </summary>
    [DataContract]
    public class KittyQueryRequestMessage : QueryRequestMessageBase
    {
        /// <summary>
        /// The target generation
        /// </summary>
        [DataMember(Name = "generation")]
        public int? Generation { get; set; }
        [DataMember(Name = "owner_wallet_address")]
        public string OwnerWalletAddress { get; set; }
        protected override void WriteToQueryDictionary(IDictionary<string, string> target)
        {
            base.WriteToQueryDictionary(target);
            if (!string.IsNullOrEmpty(OwnerWalletAddress))
            {
                SetValue(target, "owner_wallet_address", OwnerWalletAddress);          
            }
            else
            {
                SetValue(target, "generation", Generation);
            }
        }
    }
}