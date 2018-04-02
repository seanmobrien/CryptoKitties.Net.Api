using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace CryptoKitties.Net.Blockchain.Models.Contracts
{

    /// <summary>
    /// The <see cref="KittyEventData"/> class identifies the kitty that the event targets.
    /// </summary>
    public class KittyEventData
    {
        /// <summary>
        /// The kitty id.
        /// </summary>
        [Parameter("uint256", "tokenId", 1, false)]
        public BigInteger TokenId { get; set; }
    }

    /// <summary>
    /// The <see cref="AuctionCreatedEventData"/> class describes the creation of an auction.
    /// </summary>
    public class AuctionSuccessfulEventData : KittyEventData
    {
        /// <summary>
        /// The final auction price.
        /// </summary>
        [Parameter("uint256", "totalPrice", 2, false)]
        public BigInteger TotalPrice { get; set; }
        /// <summary>
        /// The address of the account that one the auction.
        /// </summary>
        [Parameter("address", "winner", 3, false)]
        public string Winner { get; set; }
    }
    /// <summary>
    /// The <see cref="AuctionCreatedEventData"/> class describes the creation of an auction.
    /// </summary>
    public class AuctionCreatedEventData : KittyEventData
    {
        /// <summary>
        /// The inital price of the auction.
        /// </summary>
        [Parameter("uint256", "startingPrice", 2, false)]
        public BigInteger StartingPrice { get; set; }
        /// <summary>
        /// The final price of the auction.
        /// </summary>
        [Parameter("uint256", "endingPrice", 3, false)]
        public BigInteger EndingPrice { get; set; }
        /// <summary>
        /// How long the price should decrement before stalling at the ending price.
        /// </summary>
        [Parameter("uint256", "duration", 4, false)]
        public BigInteger Duration { get; set; }
    }

    public class PregnantEventData
    {
        [Parameter("address", "owner", 1, false)]
        public string Owner { get; set; }
        [Parameter("uint256", "matronId",  2, false)]
        public BigInteger MatronId { get; set; }
        [Parameter("uint256", "sireId", 3, false)]
        public BigInteger SireId { get; set; }
    }
    public class AutoBirthEventData
    {
        [Parameter("uint256", "matronId", 1, false)]
        public BigInteger MatronId { get; set; }
        [Parameter("uint256", "cooldownEndTime", 2, false)]
        public BigInteger CooldownEndTime { get; set; }
    }

    public class TransferEventData
    {
        [Parameter("address", "from", 1, true)]
        public string From { get; set; }

        [Parameter("address", "to", 2, true)]
        public string To { get; set; }

        [Parameter("uint256", "tokenId", 3, true)]   
        public BigInteger TokenId { get; set; }
    }
    public class ApprovalEventData
    {
        [Parameter("address", "owner", 1, true)]
        public string From { get; set; }

        [Parameter("address", "approved", 2, true)]
        public string To { get; set; }

        [Parameter("uint256", "tokenId", 3, true)]
        public BigInteger TokenId { get; set; }
    }
    public class BirthEventData
    {
        [Parameter("address", "owner", 1, true)]
        public string Owner { get; set; }
        [Parameter("uint256", "kittyId", 2, false)]
        public BigInteger KittyId { get; set; }
        [Parameter("uint256", "matronId", 3, false)]
        public BigInteger MatronId { get; set; }
        [Parameter("uint256", "sireId",  4, false)]
        public BigInteger SireId { get; set; }
        [Parameter("uint256", "genes", 4, false)]
        public BigInteger Genes { get; set; }
    }

    public class ContractUpgradeEventData
    {
        [Parameter("address", "newContract", 1, false)]
        public string NewContract { get; set; }
    }

}
