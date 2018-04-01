using System;

namespace CryptoKitties.Net.Blockchain
{
    partial class ContractCallDataBuilder
    {
        public ContractCallDataBuilder AddParameter(string value)
        {
            var ret = new StringContractCallParameter(value);
			Parameters.Add(ret);
            return this;
        }

        public ContractCallDataBuilder AddParameter(ulong value)
        {
            var ret = new NumericContractCallParameter(value);
            Parameters.Add(ret); 
            return this;
        }

        public ContractCallDataBuilder AddParameter(long value)
        {
            var ret = new NumericContractCallParameter(value);
            Parameters.Add(ret); 
            return this;
        }


        class StringContractCallParameter
            : ContractCallParameter
        {
            public StringContractCallParameter(string value)
                : base("string")
            {
                Value = value;
            }
            public string Value { get; }
            protected override string Encode()
            {
                throw new NotImplementedException();
            }
        }

        class NumericContractCallParameter
            : ContractCallParameter
        {
            public NumericContractCallParameter(ulong value)
                : base("uint256")
            {
                Value = value.ToString("X");
            }
            public NumericContractCallParameter(long value)
                : base("uint256")
            {
                Value = value.ToString("X");
            }
            public NumericContractCallParameter(int value)
                : base("uint256")
            {
                Value = value.ToString("X");
            }
            public NumericContractCallParameter(uint value)
                : base("uint256")
            {
                Value = value.ToString("X");
            }

            public string Value { get; }
            protected override string Encode()
            {
                return Value;
            }
        }
    }
}
