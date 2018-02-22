using System;
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Api.Models
{
    /// <summary>
    /// Base class shared by all kitties
    /// </summary>
    [DataContract]
    [KnownType(typeof(KittySummary))]
    [KnownType(typeof(Kitty))]
    [KnownType(typeof(RelatedKitty))]
    public class KittyBase
    {
        /// <summary>
        /// Kitty Id
        /// </summary>
        [DataMember(Name="id")]
        public Int64 Id { get; set; }

        /// <summary>
        /// Nickname
        /// </summary>
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// URL to kitty image
        /// </summary>
        [DataMember(Name="image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// URL to cdn-based kitty image
        /// </summary>
        [DataMember(Name="image_url_cdn")]
        public string ImageUrlCdn { get; set; }

        /// <summary>
        /// The Generation of this kitty
        /// </summary>
        [DataMember(Name="generation")]
        public int Generation { get; set; }

        /// <summary>
        /// When the kitty was created
        /// </summary>
        [DataMember(Name="created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The color of the kitty
        /// </summary>
        [DataMember(Name="color")]
        public string Color{ get; set; }

        /// <summary>
        /// If <c>true</c> then the kitty is fancy.
        /// </summary>
        [DataMember(Name="is_fancy")]
        public bool IsFancy { get; set; }

        /// <summary>
        /// The name of this kitty&apos;s &quot;Fancy&quot; type.
        /// </summary>
        [DataMember(Name="fancy_type")]
        public string FancyType { get; set; }

        /// <summary>
        /// If set to <c>true</c> then this is an exclusive kitty.
        /// </summary>
        [DataMember(Name="is_exclusive")]
        public bool IsExclusive { get; set; }

        /// <summary>
        /// A <see cref="Profile"/> describing the owner.
        /// </summary>
        [DataMember(Name="owner")]
        public Profile Owner { get; set; }

        /// <summary>
        /// A <see cref="KittyStatus"/> containing kitty status.
        /// </summary>
        [DataMember(Name="status")]
        public KittyStatus Status { get; set; }

        /// <summary>
        /// Whether or not this kitty was hatched?
        /// </summary>
        [DataMember(Name="hatched")]
        public bool Hatched { get; set; }
    }
}