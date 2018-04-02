using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.Blockchain.Models.Contracts
{
    [Serializable]
    [DataContract]
    public class KittyResponseModel
    {
        [DataMember]
        public bool IsGestating { get; set; }
        [DataMember]
        public bool IsReady { get; set; }
        [DataMember]
        public int CooldownIndex { get; set; }
        [DataMember]
        public BigInteger NextActionAt { get; set; }
        [DataMember]
        public long SiringWithId { get; set; }
        [DataMember]
        public long MatronId { get; set; }
        [DataMember]
        public long SireId { get; set; }
        [DataMember]
        public BigInteger BirthTime { get; set; }
        [DataMember]
        public int Generation { get; set; }
        [IgnoreDataMember]
        public BigInteger Genes { get; set; }
        [DataMember]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GenesHex
        {
            get => Genes.ToString(16);
            set => Genes = new BigInteger(value, 16);
        }
    }
}
