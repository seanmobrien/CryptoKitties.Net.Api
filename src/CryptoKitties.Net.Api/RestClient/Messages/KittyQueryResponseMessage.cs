using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using CryptoKitties.Net.Api.Models;

namespace CryptoKitties.Net.Api.RestClient.Messages
{
    /// <summary>
    /// The <see cref="KittyQueryResponseMessage"/> class extens <see cref="QueryResponseMessageBase{Auction}"/> to support message serialization.
    /// </summary>
    /// <seealso cref="QueryResponseMessageBase{Auction}"/>
    [DataContract]
    public class KittyQueryResponseMessage
        : QueryResponseMessageBase<KittySummary>
    {
        /// <summary>
        /// Serializes <see cref="QueryResponseMessageBase{TModel}.Items"/>.
        /// </summary>
        [DataMember(Name = "kitties")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<KittySummary> Kitties
        {
            get => Items;
            set => Items = value;
        }
    }
}