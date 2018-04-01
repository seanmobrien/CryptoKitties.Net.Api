using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.Blockchain.Models.Contracts
{
    public class KittyResponseModel
    {
        public bool IsGestating { get; set; }
        public bool IsReady { get; set; }
        public int CooldownIndex { get; set; }
        public BigInteger NextActionAt { get; set; }
        public long SiringWithId { get; set; }
        public long MatronId { get; set; }
        public long SireId { get; set; }
        public BigInteger BirthTime { get; set; }
        public int Generation{ get; set; }
        public BigInteger Genes { get; set; }
    }
}
