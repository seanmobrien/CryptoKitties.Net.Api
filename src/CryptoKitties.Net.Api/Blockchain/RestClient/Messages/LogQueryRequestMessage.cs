using System.Collections.Generic;
using System.Linq;

namespace CryptoKitties.Net.Blockchain.RestClient.Messages
{
    public class LogQueryRequestMessage
        : EtherscanApiRequestMessageBase
    {
        public LogQueryRequestMessage(string action = default(string), string module = default(string))
            : base(module ?? Modules.Logs, action ?? Actions.GetLogs)
        {
            Topics = new List<string>();
        }

        public LogQueryRequestMessage(LogQueryRequestMessage copy)
            : base(copy)
        {
            Address = copy.Address;
            Topics = (copy.Topics ?? new string[0]).ToList();
            TopicsOr = copy.TopicsOr;
            FromBlock = copy.FromBlock;
            ToBlock = copy.ToBlock;
        }


        public string Address { get; set; }

        public string FromBlock { get; set; }
        public string ToBlock { get; set; }
        public IList<string> Topics { get; set; }

        public bool TopicsOr{ get; set; }


        protected override void WriteToQueryDictionary(IDictionary<string, string> target)
        {
            base.WriteToQueryDictionary(target);
            SetValue(target, "address", Address);
            SetValue(target, "fromBlock", FromBlock);
            SetValue(target, "toBlock", ToBlock);
            for (var idx = 0; idx < Topics.Count; idx++)
            {
                SetValue(target, $"topic{idx}", Topics[idx]);
                if (idx < Topics.Count - 1)
                {
                    SetValue(target, $"topic{idx}_{idx+1}_opr", TopicsOr ? "or" : "and");
                }
            }
        }


        internal static class Actions
        {
            public const string GetLogs = "getLogs";
        }
    }
}
