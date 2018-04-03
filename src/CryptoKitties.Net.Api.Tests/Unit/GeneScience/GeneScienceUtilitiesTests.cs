using CryptoKitties.Net.Api.GeneScience;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.Api.Tests.Unit.Unit.GeneScience
{
    [TestClass]
    public class GeneScienceUtilitiesTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void KnownGene_ToKai_ReturnsExpected()
        {
            var real = new BigInteger("63129314a7185c642d2310ca0310026acc620084298e339ca65394373d76", 16);
            var target = new GeneSplicer(real);
            TestContext.WriteLine($"Kai: {target.Kai}\r\nCattributes:{JsonConvert.SerializeObject(target.KnownCattributes)}"); 
        }



        [TestMethod]
        public void KittyScience_KnownExample_Succeeds()
        {
            var set = new GeneScienceSet(
                "000063169218f348dc640d171b000208934b5a90189038cb3084624a50f7316c",
                "00005a13429085339c6521ef0300011c82438c628cc431a63298e3721f772d29",
                "000000000000000000000000000000000000000000000000000000000047ff27",
                "f9dd4486d68b13839d2f7b345f5223f17abae39a951f2cea5b0ca0dd6dc8db83",
                "5b174298a44b9c6521176000021c53734c9018c431a73298674a5177316c"
                );
            RunTest(set);
        }


        void RunTest(GeneScienceSet set)
        {
            var actual = GeneScienceUtilities.SimulateOffspring(
                set.MatronGenome,
                set.SireGenome,
                set.MatronCooldownEndBlock,
                set.CooldownBlockHash
            );
            TestContext.WriteLine(string.Format("Offsptring Genome - {0}", actual));
            Assert.AreEqual(set.OffspringGenome, actual);
        }



        public class GeneScienceSet
        {
            public GeneScienceSet(
                string matron, string sire, string matronCooldown, string cooldownBlock, string offspring
            )
            {
                MatronGenome = new BigInteger(matron, 16);
                SireGenome = new BigInteger(sire, 16);
                MatronCooldownEndBlock = new BigInteger(matronCooldown, 16);
                CooldownBlockHash = new BigInteger(cooldownBlock, 16);
                OffspringGenome = new BigInteger(offspring, 16);
            }



            public BigInteger MatronGenome { get;set; }
            public BigInteger SireGenome { get; set; }
            public BigInteger MatronCooldownEndBlock { get; set; }
            public BigInteger CooldownBlockHash { get; set; }
            public BigInteger OffspringGenome { get; set; }
        }

    }
}
