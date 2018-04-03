using System;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain.RestClient;
using CryptoKitties.Net.Blockchain.RestClient.Messages;
using CryptoKitties.Net.Exceptions;
using Nethereum.Contracts;
using Nethereum.Web3;

namespace CryptoKitties.Net.Blockchain
{
    using Res = Properties.Resources;
    /// <summary>
    /// The <see cref="BlockchainExtensionMethods"/> class contains extension methods used to simplify extracting kitty data from the Ethereum blockchain.
    /// </summary>
    public static class BlockchainExtensionMethods
    {
        /// <summary>
        /// Simplifies creating an abstract <see cref="IWeb3Client"/> from an actual <see cref="Web3"/> instance.
        /// </summary>
        /// <param name="instance">The <see cref="Web3"/> instance being abstracted.</param>
        /// <returns>An <see cref="IWeb3Client"/> interface wrapping <paramref name="instance"/>.</returns>
        public static IWeb3Client Abstract(this Web3 instance)
        {
            return new Web3Client(instance);
        }
        /// <summary>
        /// Asserts <paramref name="instance"/> was successful.
        /// </summary>
        /// <param name="instance">The <see cref="EtherscanResponseMessage"/> to assert.</param>
        /// <exception cref="EtherscanApiException">Thrown if <paramref name="instance"/> failed.</exception>
        public static void Assert(this EtherscanResponseMessage instance)
        {
            Guard.NotNull(instance, nameof(instance));
            if (!instance.IsSuccess()) { throw new EtherscanApiException(instance); }
        }
        /// <summary>
        /// Asserts <paramref name="instance"/> was successful.
        /// </summary>
        /// <param name="instance">The <see cref="EtherscanResponseMessage"/> to assert.</param>
        /// <exception cref="EtherscanApiException">Thrown if <paramref name="instance"/> failed.</exception>
        public static void AssertCallSuccess(this EtherscanResponseMessage instance)
        {
            Guard.NotNull(instance, nameof(instance));
            if (instance.Status != 0) { throw new EtherscanApiException(instance); }
        }

        /// <summary>
        /// Returns a <see cref="Contract"/> instance for one of the known cryptokitty contracts.
        /// </summary>
        /// <param name="instance">The <see cref="EthApiContractService"/> being extended.</param>
        /// <param name="contract">A <see cref="CryptoKittyContractType"/> identifying the desired contract.</param>
        /// <returns>A <see cref="Contract"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="contract"/> is not a recognized value.</exception>
        /// <exception cref="InvalidOperationException">Thrown if there is some failure attaching to a valid contract.</exception>
        public static Contract GetKittyContract(this EthApiContractService instance, CryptoKittyContractType contract)
        {
            // Note that ForContract will throw on an invalid contract type
            var address = Globals.Contracts.Address.ForContract(contract);
            // If we made it this far then we know we were givven a good contract
            var ret = instance.GetContract(Globals.Contracts.ABI.ForContract(contract), address);
            if (ret == null) { throw new InvalidOperationException(Res.FatalContractFailure); }
            return ret;
        }

        public static Event GetKittyEvent(this Contract instance, KittyEventType kittyEvent)
        {
            return instance.GetEvent(kittyEvent.ToEventName());
        }
        /// <summary>
        /// Calls a contract method and returns the response.
        /// </summary>
        /// <param name="instance">The <see cref="IEtherscanApiClient"/> being extended.</param>
        /// <param name="to"></param>
        /// <param name="fn"></param>
        /// <param name="buildCall"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static async Task<EtherscanResponseMessage<string>> Call(this IEtherscanApiClient instance, string to, string fn,
            Action<ContractCallDataBuilder> buildCall, string tag = default(string))
        {
            var builder = new ContractCallDataBuilder(fn);
            buildCall(builder);
            var message = new CallRequestMessage
            {
                To = to, 
                Data= builder.EncodeData(),
                Tag = tag ?? "latest"
            };
            return await instance.Call(message);
        }
        /// <summary>
        /// Calls the getKitty contract method and parses the result.
        /// </summary>
        /// <param name="instance">The <see cref="IEtherscanApiClient"/> being extended.</param>
        /// <param name="kittyId">The kitty id to load.</param>
        /// <returns>A <see cref="CryptoKitties.Net.Blockchain.Models.Contracts.KittyResponseModel"/></returns>
        public static async Task<Models.Contracts.KittyResponseModel> GetKitty(this IEtherscanApiClient instance, long kittyId)
        {
            var response = await Call(instance, Globals.Contracts.KittyCore.ContractAddress, Globals.Contracts.KittyCore.Functions.GetKitty, b => b.AddParameter(kittyId));
            response.AssertCallSuccess();
            return Parse(response.Result);
        }
        /// <summary>
        /// Parses <paramref name="response"/> into <see cref="Models.Contracts.KittyResponseModel"/>
        /// </summary>
        /// <param name="response">A <see cref="string"/> containing the contract response.</param>
        /// <returns>The parsed <see cref="Models.Contracts.KittyResponseModel"/> value.</returns>
        public static Models.Contracts.KittyResponseModel Parse(string response)
        {
            // was a null value returned?
            if (ContractCallResultReader.IsNull(response)) { return default(Models.Contracts.KittyResponseModel); }
            // Otherwise parse response
            var ret = new Models.Contracts.KittyResponseModel();
            var parser = new ContractCallResultReader(response);
            if (!parser.MoveNext()) { throw new ArgumentOutOfRangeException(nameof(response), response, Res.InvalidCallResponse);}
            ret.IsGestating = parser.CurrentBool;
            if (!parser.MoveNext()) { throw new ArgumentOutOfRangeException(nameof(response), response, Res.InvalidCallResponse);}
            ret.IsReady = parser.CurrentBool;
            if (!parser.MoveNext()) { throw new ArgumentOutOfRangeException(nameof(response), response, Res.InvalidCallResponse); }
            ret.CooldownIndex = parser.CurrentValue.IntValue;
            if (!parser.MoveNext()) { throw new ArgumentOutOfRangeException(nameof(response), response, Res.InvalidCallResponse); }
            ret.NextActionAt = parser.CurrentValue;
            if (!parser.MoveNext()) { throw new ArgumentOutOfRangeException(nameof(response), response, Res.InvalidCallResponse); }
            ret.SiringWithId = parser.CurrentValue.LongValue;
            if (!parser.MoveNext()) { throw new ArgumentOutOfRangeException(nameof(response), response, Res.InvalidCallResponse); }
            ret.BirthTime = parser.CurrentValue;
            if (!parser.MoveNext()) { throw new ArgumentOutOfRangeException(nameof(response), response, Res.InvalidCallResponse); }
            ret.MatronId = parser.CurrentValue.LongValue;
            if (!parser.MoveNext()) { throw new ArgumentOutOfRangeException(nameof(response), response, Res.InvalidCallResponse); }
            ret.SireId = parser.CurrentValue.LongValue;
            if (!parser.MoveNext()) { throw new ArgumentOutOfRangeException(nameof(response), response, Res.InvalidCallResponse); }
            ret.Generation = parser.CurrentValue.IntValue;
            if (!parser.MoveNext()) { throw new ArgumentOutOfRangeException(nameof(response), response, Res.InvalidCallResponse); }
            ret.Genes = parser.CurrentValue;
            return ret;
        }
    }
}
