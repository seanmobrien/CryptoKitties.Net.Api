using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// The <see cref="CooldownIndexType"/> enum describes how long a Kitty requires before it is ready to breed again.
    /// </summary>
    [DataContract]
    public enum CooldownIndexType
    {
        /// <summary>
        /// 1 Minute
        /// </summary>
        [EnumMember(Value = "fast")]
        Fast = 0,
        /// <summary>
        /// 2-5 Minutes
        /// </summary>
        [EnumMember(Value = "swift")]
        Swift = 1,
        /// <summary>
        /// 10-30 Minutes
        /// </summary>
        [EnumMember(Value = "snappy")]
        Snappy = 2,
        /// <summary>
        /// 1-2 Hours
        /// </summary>
        [EnumMember(Value = "brisk")]
        Brisk = 3,
        /// <summary>
        /// 4-8 Hours
        /// </summary>
        [EnumMember(Value = "plodding")]
        Plodding = 4,
        /// <summary>
        /// 16-24 Hours
        /// </summary>
        [EnumMember(Value = "slow")]
        Slow = 5,
        /// <summary>
        /// 2-4 Days
        /// </summary>
        [EnumMember(Value = "sluggish")]
        Sluggish = 6,
        /// <summary>
        /// 1 Week
        /// </summary>
        [EnumMember(Value = "catatonic")]
        Catatonic = 7,
        /// <summary>
        /// Reserved for Future Use
        /// </summary>
        CatatonicPlusOne = 8,
        /// <summary>
        /// Reserved for Further Future Use
        /// </summary>
        CatatonicPlusTwo = 9,
        /// <summary>
        /// Reserved for Unforseen Future Use
        /// </summary>
        CatatonicPlusThree = 10,
    }
}
