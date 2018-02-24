using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.RestClient.Messages
{
    /// <summary>
    /// The <see cref="CattributeQueryRequestMessage"/> class extends <see cref="QueryRequestMessageBase"/> for kitty queries.
    /// </summary>
    [DataContract]
    public class CattributeQueryRequestMessage : RequestMessageBase
    {
        /// <summary>
        /// The target generation
        /// </summary>
        [DataMember(Name = "total")]
        public bool Total { get; set; }
        /// <inheritdoc />
        protected override void WriteToQueryDictionary(IDictionary<string, string> target)
        {
            if (Total)
            {
                SetBoolValue(target, "total", Total);
            }
        }
    }
}