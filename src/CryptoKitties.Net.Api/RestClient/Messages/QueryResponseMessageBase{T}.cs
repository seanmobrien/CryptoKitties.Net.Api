using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.RestClient.Messages
{
    /// <summary>
    /// The <see cref="QueryResponseMessageBase{TModel}"/> class provides a standard base class for kitty query responses.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    [DataContract]
    [KnownType(typeof(AuctionQueryResponseMessage))]
    [KnownType(typeof(KittyQueryResponseMessage))]
    public abstract class QueryResponseMessageBase<TModel>
        : ICollection<TModel>
        where TModel : class
    {
        /// <summary>
        /// Initializes a new <see cref="QueryResponseMessageBase{TModel}"/> instance.
        /// </summary>
        protected QueryResponseMessageBase()
            : this(default(IList<TModel>))
        {
            
        }
        /// <summary>
        /// Initializes a new <see cref="QueryResponseMessageBase{TModel}"/> instance.
        /// </summary>
        /// <param name="items">Initial <see cref="Items"/> value.</param>
        protected QueryResponseMessageBase(IList<TModel> items)
        {
            Items = items ?? new List<TModel>();
        }
        /// <summary>
        /// Total number of auctions matching the query
        /// </summary>
        [DataMember(Name = "total")]
        public Int64 Total { get; set; }
        /// <summary>
        /// Index of the first auction 
        /// </summary>
        [DataMember(Name = "offset")]
        public Int64 Offset { get; set; }
        /// <summary>
        /// Maximum number of items returned in this response.
        /// </summary>
        [DataMember(Name = "limit")]
        public Int32 Limit { get; set; }
        
        /// <summary>
        /// An object that implements <see cref="IList{T}"/> for <see cref="Items"/> data.
        /// </summary>
        [IgnoreDataMember]
        protected IList<TModel> Items { get; set; }

        #region ICollection{TModel} Implementation
        int ICollection<TModel>.Count => Items.Count;
        bool ICollection<TModel>.IsReadOnly => Items.IsReadOnly;
        IEnumerator<TModel> IEnumerable<TModel>.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        void ICollection<TModel>.Add(TModel item)
        {
            Items.Add(item);
        }
        void ICollection<TModel>.Clear()
        {
            Items.Clear();
        }
        bool ICollection<TModel>.Contains(TModel item)
        {
            return Items.Contains(item);
        }
        void ICollection<TModel>.CopyTo(TModel[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }
        bool ICollection<TModel>.Remove(TModel item)
        {
            return Items.Remove(item);
        }
        #endregion
    }
}
