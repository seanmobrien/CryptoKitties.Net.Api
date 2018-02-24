#define OLD_VS

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using CryptoKitties.Net.Api.Models;

namespace CryptoKitties.Net.Api.RestClient.Messages
{
    /// <summary>
    /// The <see cref="AuctionQueryResponseMessage"/> class extens <see cref="QueryResponseMessageBase{Auction}"/> to support message serialization.
    /// </summary>
    /// <seealso cref="QueryResponseMessageBase{Auction}"/>
    [DataContract]
    public class AuctionQueryResponseMessage
        : QueryResponseMessageBase<Auction>
    {
        /// <summary>
        /// Serializes <see cref="QueryResponseMessageBase{TModel}.Items"/>.
        /// </summary>
        [DataMember(Name = "auctions")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<Auction> Auctions
        {
#if OLD_VS
            get { return Items; }
            set { Items = value; }
#else
            get => Items;
            set => Items = value;
#endif
            }
    }
}