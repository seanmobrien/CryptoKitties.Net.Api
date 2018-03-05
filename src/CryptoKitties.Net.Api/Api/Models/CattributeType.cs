using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// The <see cref="CattributeType"/> enum describes available cattribute categories.
    /// </summary>
    [DataContract]
    public enum CattributeType
    {
        /// <summary>
        /// Reserved for future use
        /// </summary>
        Unknown,
        /// <summary>
        /// Body
        /// </summary>
        [EnumMember(Value = "body")]
        Body,
        /// <summary>
        /// Eye Color
        /// </summary>
        [EnumMember(Value = "coloreyes")]
        ColorEyes,
        /// <summary>
        /// Primary Color
        /// </summary>
        [EnumMember(Value = "colorprimary")]
        ColorPrimary,
        /// <summary>
        /// Secondary Color
        /// </summary>
        [EnumMember(Value = "colorsecondary")]
        ColorSecondary,
        /// <summary>
        /// Tertiary Color
        /// </summary>
        [EnumMember(Value = "colortertiary")]
        ColorTertiary,
        /// <summary>
        /// Eye type
        /// </summary>
        [EnumMember(Value = "eyes")]
        Eyes,
        /// <summary>
        /// Pattern
        /// </summary>
        [EnumMember(Value = "pattern")]
        Pattern,
        /// <summary>
        /// Mouth Type
        /// </summary>
        [EnumMember(Value = "mouth")]
        Mouth,
        /// <summary>
        /// Wild
        /// </summary>
        [EnumMember(Value = "wild")]
        Wild 
    }
}