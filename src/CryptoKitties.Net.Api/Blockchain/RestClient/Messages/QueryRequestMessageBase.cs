using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CryptoKitties.Net.Blockchain.RestClient.Messages
{
    /// <summary>
    /// The <see cref="QueryRequestMessageBase"/> class extends <see cref="EtherscanApiRequestMessageBase"/> to support standard pagination. 
    /// </summary>
    public abstract class QueryRequestMessageBase
        : EtherscanApiRequestMessageBase
    {
        protected QueryRequestMessageBase(string module, string action)
            : base(module, action)
        {
            
        }

        protected QueryRequestMessageBase(QueryRequestMessageBase copy)
            : base(copy)
        {
            Page = copy.Page;
            Count = copy.Count;
            Order = copy.Order;
        }
        /// <summary>
        /// Page of records
        /// </summary>
        public long? Page { get; set; }
        /// <summary>
        /// Number of records returned in this page
        /// </summary>
        public int? Count { get; set; }
        /// <summary>
        /// Direction results should be sorted by 
        /// </summary>
        public ListSortDirection? Order { get; set; }


        protected override void WriteToQueryDictionary(IDictionary<string, string> target)
        {
            base.WriteToQueryDictionary(target);

            SetValue(target, "page", Page);
            SetValue(target, "offset", Count);
            SetValue(target, "sort", SortString(Order));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static string SortString(ListSortDirection? sort)
        {
            return sort.HasValue
                ? sort.Value == ListSortDirection.Ascending
                    ? "asc"
                    : "desc"
                : default(string);
        }
    }
}