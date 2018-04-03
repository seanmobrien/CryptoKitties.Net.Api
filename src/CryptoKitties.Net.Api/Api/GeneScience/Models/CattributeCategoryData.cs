using System.Collections.Generic;
using System.Linq;
using CryptoKitties.Net.Api.Models;

namespace CryptoKitties.Net.Api.GeneScience.Models
{
    public abstract class CattributeCategoryData
    {
        protected CattributeCategoryData(CattributeType type, int bitOffset, params CattributeData[] cattributes)
        {
            InnerCattributes = new List<CattributeData>(cattributes ?? new CattributeData[0]);
            Type = type;
            BitOffset = bitOffset;
        }
        public CattributeType Type { get; }
        public string Name => Type.ToName();
        public int BitOffset { get; }
        public IEnumerable<CattributeData> Cattributes => InnerCattributes.ToArray();
        protected List<CattributeData> InnerCattributes { get; }

        public CattributeData GetCattribute(char kai)
        {
            return InnerCattributes.FirstOrDefault(x => x.Kai == kai)
                ?? new CattributeData($"{Name}-{kai}", kai);
        }
    }
}
