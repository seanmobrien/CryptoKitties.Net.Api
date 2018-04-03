using System;
using System.Collections.Generic;
using System.Linq;
using CryptoKitties.Net.Api.GeneScience.Models;
using CryptoKitties.Net.Api.Models;

namespace CryptoKitties.Net
{
    
    partial class Globals
    {
     
        public static class Cattributes
        {
 
            public static CattributeCategoryData Wild => CattributeCategories[CattributeType.Wild];
            public static CattributeCategoryData ColorHighlight => CattributeCategories[CattributeType.ColorHighlight];
            public static CattributeCategoryData Body => CattributeCategories[CattributeType.Body];
            public static CattributeCategoryData ColorPrimary => CattributeCategories[CattributeType.ColorPrimary];
            public static CattributeCategoryData EyeColor => CattributeCategories[CattributeType.EyeColor];
            public static CattributeCategoryData ColorAccent => CattributeCategories[CattributeType.ColorAccent];
            public static CattributeCategoryData EyeShape => CattributeCategories[CattributeType.EyeShape];
            public static CattributeCategoryData Mouth => CattributeCategories[CattributeType.Mouth];
            public static CattributeCategoryData Pattern => CattributeCategories[CattributeType.Pattern];
            public static CattributeCategoryData Unknown => CattributeCategories[CattributeType.Unknown];
            public static CattributeCategoryData Secret => CattributeCategories[CattributeType.Secret];
            public static CattributeCategoryData Mystery => CattributeCategories[CattributeType.Mystery];
            public static IEnumerable<CattributeCategoryData> AllCategories => CattributeCategories.Values;
            public static IEnumerable<CattributeCategoryData> KnownCategories => AllCategories.Where(x => UnknownCategories.All(y => y != x.Type));
            public static readonly CattributeType[] UnknownCategories = {CattributeType.Mystery, CattributeType.Secret, CattributeType.Unknown};
            public static readonly Dictionary<CattributeType, CattributeCategoryData> CattributeCategories = new Dictionary<CattributeType, CattributeCategoryData>()
            {
                // Create category-specific category data instances
                {CattributeType.Wild, new WildCategoryData() }, {CattributeType.ColorAccent, new AccentColorCategoryData() },
                {CattributeType.ColorHighlight, new HightlightColorCategoryData() }, {CattributeType.EyeShape, new EyeShapeCategoryData() },
                {CattributeType.Body, new BodyCategoryData() }, {CattributeType.Mouth, new MouthCategoryData() },
                {CattributeType.ColorPrimary, new PrimaryColorCategoryData() }, {CattributeType.Pattern, new PatternCategoryData() },
                {CattributeType.EyeColor, new EyeColorCategoryData() },
                // Unknown data blocks
                { CattributeType.Unknown, new UnknownCategoryData(CattributeType.Unknown, 0) },
                {CattributeType.Secret, new UnknownCategoryData(CattributeType.Secret, 4) },
                {CattributeType.Mystery, new UnknownCategoryData(CattributeType.Mystery,8) }
            };


        }

       
    }
}
