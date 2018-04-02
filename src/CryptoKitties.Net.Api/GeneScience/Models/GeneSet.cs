using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using CryptoKitties.Net.Api.Models;

namespace CryptoKitties.Net.GeneScience.Models
{
    /// <summary>
    /// The <see cref="GeneSet"/> class is used to represent a specific cattribute categories gene makeup.
    /// </summary>
    public class GeneSet
    {
        /// <summary>
        /// Initializes new <see cref="GeneSet"/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="genes"></param>
        public GeneSet(CattributeType type, IEnumerable<CattributeData> genes)
        {
            Genes = genes.ToArray();
            Type = type;
            if (Genes.Length != 4) throw new ArgumentOutOfRangeException(nameof(genes), genes, "Incorrect number of cattribues");
        }

        public GeneSet()
        {
            Genes = new CattributeData[4];
        }
        /// <summary>
        /// The <see cref="CattributeType"/> beng described.
        /// </summary>
        [DataMember]
        public CattributeType Type { get; set; }
        /// <summary>
        /// Dominant gene.
        /// </summary>
        [DataMember]
        public CattributeData Dominant => Genes[0];
        /// <summary>
        /// First recessive gene
        /// </summary>
        [DataMember]
        public CattributeData RecessiveOne => Genes[1];
        /// <summary>
        /// Secondary recessive gene.
        /// </summary>
        [DataMember]
        public CattributeData RecessiveTwo => Genes[2];
        /// <summary>
        /// Last recessive gene.
        /// </summary>
        [DataMember]
        public CattributeData RecessiveThree => Genes[3];
        /// <summary>
        /// Cattributes
        /// </summary>
        [DataMember]
        public CattributeData[] Genes { get; set; }
    }
}
