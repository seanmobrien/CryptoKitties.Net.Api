using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Api.GeneScience;

namespace CryptoKitties.Net.Blockchain
{
    public partial class ContractCallDataBuilder
    {
        public ContractCallDataBuilder(string functionName)
        {
            FunctionName = functionName;
            Parameters = new List<ContractCallParameter>();
        }
        public string FunctionName { get; }
        public IList<ContractCallParameter> Parameters { get; }

        public override string ToString()
        {
            return Parameters.Aggregate(
                new StringBuilder().Append(FunctionName).Append('('),
                (sb,p) => sb.Append(p.Name).Append(','),
                CloseParams);
        }


        private static string CloseParams(StringBuilder builder)
        {
            if (builder[builder.Length - 1] == ',')
            {
                builder.Length -= 1;
            }
            builder.Append(')');
            return builder.ToString();
        }


        public string EncodeData()
        {
            var abi = ToString();
            // Compute hash from function definition
            var hash = abi.Sha3Keccack();
            // Then grab first 4 bytes            
            return Parameters.Aggregate(
                new StringBuilder("0x").Append(hash.Substring(0, 8)),
                (sb, p) => sb.Append(p.EncodeValue()),
                sb => sb.ToString()
            );
        }



        

    }
    public abstract class ContractCallParameter
    {
        protected ContractCallParameter(string name)
        {
            Name = name;
        }

        public string Name { get; }
        
        public string EncodeValue()
        {
            var encoded = Encode();
            if (encoded.Length < 64)
            {
                encoded = new string('0', 64 - encoded.Length) + encoded;
            }
            return encoded;
        }
        protected abstract string Encode();
    }

  
}
