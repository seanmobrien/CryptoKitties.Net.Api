using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKitties.Net.Api.Models
{
    public static class ModelExtensions
    {
        public static string ToName(this CattributeType instance)
        {
            switch (instance)
            {
                    case CattributeType.Body: return CategoryNames.Body;
                    case CattributeType.ColorAccent: return CategoryNames.ColorAccent;
                    case CattributeType.ColorHighlight: return CategoryNames.ColorHighlight;
                    case CattributeType.Wild: return CategoryNames.Wild;
                    case CattributeType.EyeShape: return CategoryNames.EyeShape;
                    case CattributeType.Mouth: return CategoryNames.Mouth;
                    case CattributeType.Pattern: return CategoryNames.Pattern;
                    case CattributeType.ColorPrimary: return CategoryNames.ColorPrimary;
                    case CattributeType.EyeColor: return CategoryNames.EyeColor;
                    case CattributeType.Mystery: return CategoryNames.Mystery;
                    case CattributeType.Secret: return CategoryNames.Secret;
                    case CattributeType.Unknown: return CategoryNames.Unknown;
            }
            return default(string);
        }

        public static class CategoryNames
        {
            public const string ColorAccent = "ColorAccent";
            public const string ColorHighlight = "ColorHighlight";
            public const string Wild = "Wild";
            public const string EyeShape = "EyeShape";
            public const string Body = "Body";
            public const string Mouth = "Mouth";
            public const string Pattern = "Pattern";
            public const string ColorPrimary = "ColorPrimary";
            public const string EyeColor = "EyeColor";
            public const string Mystery = "Mystery";
            public const string Secret = "Secret";
            public const string Unknown = "Unknown";
        }
    }
}
