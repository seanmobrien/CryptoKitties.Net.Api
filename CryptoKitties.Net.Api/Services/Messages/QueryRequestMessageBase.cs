using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Services.Messages
{
    /// <summary>
    /// The <see cref="QueryRequestMessageBase"/> class provides a base for api queries.
    /// </summary>
    public class QueryRequestMessageBase : RequestMessageBase
    {
        /// <summary>
        /// The number of items to return
        /// </summary>
        [DataMember(Name="limit")]
        [DefaultValue(AuctionQueryRequestMessage.DefaultLimit)]
        public byte Limit { get; set; }
        /// <summary>
        /// Optional offset of the first result.
        /// </summary>
        [DataMember(Name="offset")]
        public Int32? Offset { get; set; }
        /// <summary>
        /// A <see cref="string"/> containing space-delimited query keywords.  Note that only exact matches seem to work.
        /// </summary>
        [DataMember(Name = "search")]
        public string Keywords { get; set; }
        /// <summary>
        /// When <c>true</c>, the kitties parent&apos;s are returned.
        /// </summary>
        [DataMember(Name = "parents")]
        public bool? Parents { get; set; }
        /// <summary>
        /// When <c>true</c>, something related to authentication happens or influences the resultset.
        /// </summary>
        [DataMember(Name = "authenticated")]
        public bool? Authenticated { get; set; }
        /// <summary>
        /// A <see cref="KittySortType"/> specifying how results should be sorted.
        /// </summary>
        [DataMember(Name = "orderBy", EmitDefaultValue = false)]
        [DefaultValue(DefaultSortType)]
        public KittySortType Sort { get; set; }
        /// <summary>
        /// When <c>true</c> results will be sorted in ascending order; otherwise descending sort is used.
        /// </summary>
        [DataMember(Name = "ascending", EmitDefaultValue = false)]
        public bool SortAscending { get; set; }

        protected override void WriteToQueryDictionary(IDictionary<string, string> target)
        {
            SetValue<string>(target, "limit", Limit.ToString());
            SetValue(target, "offset", Offset);
            SetValue<string>(target, "search", Keywords);
            SetBoolValue(target, "parents", Parents);
            SetBoolValue(target, "authenticated", Authenticated);
            switch (Sort)
            {
                case KittySortType.Price:
                    SetValue(target, "orderBy", "current_price");
                    break;
                case KittySortType.Purrs:
                    SetValue(target, "orderBy", "purr_count");
                    break;
            }
            if (SortAscending)
            {
                SetValue(target, "orderDirection", "asc");
            }
        }


        internal const KittySortType DefaultSortType = KittySortType.Age;
    }
}