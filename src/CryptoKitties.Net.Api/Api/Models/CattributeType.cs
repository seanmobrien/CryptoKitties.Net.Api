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
        EyeColor,
        /// <summary>
        /// Primary Color
        /// </summary>
        [EnumMember(Value = "colorprimary")]
        ColorPrimary,
        /// <summary>
        /// Secondary Color
        /// </summary>
        [EnumMember(Value = "colorsecondary")]
        ColorHighlight,
        /// <summary>
        /// Tertiary Color
        /// </summary>
        [EnumMember(Value = "colortertiary")]
        ColorAccent,
        /// <summary>
        /// Eye type
        /// </summary>
        [EnumMember(Value = "eyes")]
        EyeShape,
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
        Wild,
        /// <summary>
        /// Wild
        /// </summary>
        [EnumMember(Value = "secret")]
        Secret,
        /// <summary>
        /// Wild
        /// </summary>
        [EnumMember(Value = "mystery")]
        Mystery
    }
}