using System;
using System.Reflection;
using CryptoKitties.Net.Blockchain;

namespace CryptoKitties.Net
{
    using Res = Properties.Resources;
    public static partial class Globals
    {
        public static class BlockNumber
        {
            public const string Latest = "latest";
            public const string Earliest = "earliest";
            public const string Pending = "pending";
        }

        public static class Contracts
        {
            /// <summary>
            /// The <see cref="Address"/> class contains contract addresses.
            /// </summary>
            public static class Address
            {
                /// <summary>
                /// Contract used to process siring auctions.
                /// </summary>
                public const string SiringAuction = "0xc7af99fe5513eb6710e6d5f44f9989da40f27f26";
                /// <summary>
                /// Contract used to process sales auctions.
                /// </summary>
                public const string SalesAuction = "0xb1690c08e213a35ed9bab7b318de14420fb57d8c";
                /// <summary>
                /// Core contractType used to control game mechanics.
                /// </summary>
                public const string KittyCore = "0x06012c8cf97bead5deae237070f9587f8e7a266d";
                /// <summary>
                /// Returns the address for known cryptokitty contracts.
                /// </summary>
                /// <param name="contractType">A <see cref="CryptoKittyContractType"/> identifying the kitty contractType.</param>
                /// <returns>A <see cref="string"/> that contains the specified address.</returns>
                /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="contractType"/> is not a supported value.</exception>
                public static string ForContract(CryptoKittyContractType contractType)
                {
                    switch (contractType)
                    {
                        case CryptoKittyContractType.Core:
                            return KittyCore;
                        case CryptoKittyContractType.Sales:
                            return SalesAuction;
                        case CryptoKittyContractType.Siring:
                            return SiringAuction;
                    }
                    throw new ArgumentOutOfRangeException(nameof(contractType), contractType, Res.UnsupportedKittyContractValue);
                }
            }
            /// <summary>
            /// The <see cref="ABI"/> class contains contract ABI source.
            /// </summary>
            public static class ABI
            {
                /// <summary>
                /// Contract used to process siring auctions.
                /// </summary>
                public static string SiringAuction => LookupAbi("SiringAuction");
                /// <summary>
                /// Contract used to process sales auctions.
                /// </summary>
                public static string SalesAuction => LookupAbi("SalesAuction");
                /// <summary>
                /// Core contractType used to control game mechanics.
                /// </summary>
                public static string KittyCore => LookupAbi("KittyCore");
                /// <summary>
                /// Returns the ABI for known cryptokitty contracts.
                /// </summary>
                /// <param name="contractType">A <see cref="CryptoKittyContractType"/> identifying the kitty contractType.</param>
                /// <returns>A <see cref="string"/> that contains the specified ABI.</returns>
                /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="contractType"/> is not a supported value.</exception>
                public static string ForContract(CryptoKittyContractType contractType)
                {
                    switch (contractType)
                    {
                        case CryptoKittyContractType.Core:
                            return KittyCore;
                        case CryptoKittyContractType.Sales:
                            return SalesAuction;
                        case CryptoKittyContractType.Siring:
                            return SiringAuction;
                    }
                    throw new ArgumentOutOfRangeException(nameof(contractType), contractType, Res.UnsupportedKittyContractValue);
                }
                /// <summary>
                /// Reads contract ABI from embedded resource.
                /// </summary>
                /// <param name="name"></param>
                /// <returns></returns>
                private static string LookupAbi(string name)
                {
                    using (var stream = Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream($"CryptoKitties.Net.Blockchain.ABI.{name}.json"))
                    using (var reader = new System.IO.StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                    ;
                }
            }

            public static class SalesAuction
            {
                public const string ContractAddress = Address.SalesAuction;

                public static class Functions
                {
                    public const string CreateAuction = "createAuction";
                    public const string Unpause = "unpause";
                    public const string Paused = "paused";
                    public const string Pause = "pause";
                    public const string Bid = "bid";
                    public const string LastGen0SalePrices = "lastGen0SalePrices";
                    public const string WithdrawBalance = "withdrawBalance";
                    public const string GetAuction = "getAuction";
                    public const string OwnerCut = "ownerCut";
                    public const string IsSaleClockAuction = "isSaleClockAuction";
                    public const string CancelAuctionWhenPaused = "cancelAuctionWhenPaused";
                    public const string Gen0SaleCount = "gen0SaleCount";
                    public const string Owner = "owner";
                    public const string CancelAuction = "cancelAuction";
                    public const string GetCurrentPrice = "getCurrentPrice";
                    public const string NonFungibleContract = "nonFungibleContract";
                    public const string AverageGen0SalePrice = "averageGen0SalePrice";
                    public const string TransferOwnership = "transferOwnership";
                }
                public static class Events
                {
                    public const string AuctionCreated = "AuctionCreated";
                    public const string AuctionSuccessful = "AuctionSuccessful";
                    public const string AuctionCancelled = "AuctionCancelled";
                    public const string Pause = "Pause";
                    public const string Unpause = "Unpause";
                }
            }

            public static class SiringAuction
            {
                public const string ContractAddress = Address.SiringAuction;

                public static class Functions
                {
                    public const string CreateAuction = "createAuction";
                    public const string Bid = "bid";
                    public const string Paused = "paused";
                    public const string WithdrawBalance = "withdrawBalance";
                    public const string IsSiringClockAuction = "isSiringClockAuction";
                    public const string GetAuction = "getAuction";
                    public const string OwnerCut = "ownerCut";
                    public const string Pause = "pause";
                    public const string CancelAuctionWhenPaused = "cancelAuctionWhenPaused";
                    public const string Owner = "owner";
                    public const string CancelAuction = "cancelAuction";
                    public const string GetCurrentPrice = "getCurrentPrice";
                    public const string NonFungibleContract = "nonFungibleContract";
                    public const string TransferOwnership = "transferOwnership";
                    public const string Unpause = "unpause";
                }
                public static class Events
                {
                    public const string AuctionCreated = "AuctionCreated";
                    public const string AuctionSuccessful = "AuctionSuccessful";
                    public const string AuctionCancelled = "AuctionCancelled";
                    public const string Pause = "Pause";
                    public const string Unpause = "Unpause";
                }
            }

            public class KittyCore
            {
                public const string ContractAddress = Address.KittyCore;

                public static class Functions
                {
                    public const string GetKitty = "getKitty";
                }
            }
        }


        public static string ToEventName(this KittyEventType instance)
        {
            switch (instance)
            {
                case KittyEventType.AuctionCancelled:
                    return Contracts.SiringAuction.Events.AuctionCancelled;
                    case KittyEventType.AuctionCreated:
                        return Contracts.SiringAuction.Events.AuctionCreated;
                    case KittyEventType.AuctionSuccessful:
                        return Contracts.SiringAuction.Events.AuctionSuccessful;
                case KittyEventType.Pause:
                    return Contracts.SiringAuction.Events.Pause;
                case KittyEventType.Unpause:
                    return Contracts.SiringAuction.Events.Unpause;
            }
            throw new ArgumentOutOfRangeException(nameof(instance), instance, Res.OurOfRange);
        }
    }
}
