using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using CryptoKitties.Net.Api.Models;

namespace CryptoKitties.Net.Api.Services.Messages
{
    /// <summary>
    /// The <see cref="AuctionQueryRequestMessage"/> contains parameters that can be passed to the Auction service.
    /// </summary>
    [DataContract]
    public class AuctionQueryRequestMessage : QueryRequestMessageBase
    {
        public AuctionQueryRequestMessage()
            : this(DefaultType)
        { }

        public AuctionQueryRequestMessage(AuctionType type, int? offset = default(int?), byte limit = DefaultLimit)
        {
            Type = type;
            Offset = offset;
            Limit = limit;
        }
        /// <summary>
        /// An <see cref="AuctionType"/> value identifying the type of auctions to query.
        /// </summary>
        [DataMember(Name="type")]
        [DefaultValue(DefaultType)]
        public AuctionType Type { get; set; }

        /// <summary>
        /// An optional <see cref="AuctionStatusType"/> value used to filter the resultset.
        /// </summary>
        [DataMember(Name="status")]
        public AuctionStatusType? Status { get; set; }

   

        protected override void WriteToQueryDictionary(IDictionary<string, string> target)
        {
            base.WriteToQueryDictionary(target);
            SetValue(target, "type", Type.ToString(), x => x.ToLowerInvariant());
            SetValue(target, "status", Status, x => x.ToLowerInvariant());
        }


        /// <summary>
        /// The default <see cref="AuctionQueryRequestMessage.Type"/> value.
        /// </summary>
        internal const AuctionType DefaultType = AuctionType.Sale;
        /// <summary>
        /// The default <see cref="AuctionQueryRequestMessage.Limit"/> value.
        /// </summary>
        internal const byte DefaultLimit = 25;
    }
}
