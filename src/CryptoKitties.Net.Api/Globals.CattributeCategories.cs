using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Api.GeneScience.Models;
using CryptoKitties.Net.Api.Models;

namespace CryptoKitties.Net
{
    partial class Globals
    {

        private class WildCategoryData
            : CattributeCategoryData
        {
            public WildCategoryData()
                : base(CattributeType.Wild,  19,
                    new CattributeData(CattributeNames.Trioculus, 'i'),
                    new CattributeData(CattributeNames.Elk, 'k'))
            { }
        }

        private class AccentColorCategoryData
            : CattributeCategoryData
        {
            public AccentColorCategoryData()
                : base(CattributeType.ColorAccent, 23,
                    new CattributeData(CattributeNames.BelleBlue, '1'), new CattributeData(CattributeNames.Sandalwood, '2'), new CattributeData(CattributeNames.Peach, '3'),
                    new CattributeData(CattributeNames.Icy, '4'), new CattributeData(CattributeNames.GraniteGrey, '5'), new CattributeData(CattributeNames.KittenCream, '7'),
                    new CattributeData(CattributeNames.EmeraldGreen, '8'), new CattributeData(CattributeNames.PurpleHaze, 'b'), new CattributeData(CattributeNames.Azaleablush, 'd'),
                    new CattributeData(CattributeNames.MissMuffet, 'e'), new CattributeData(CattributeNames.MorningGlory, 'f'), new CattributeData(CattributeNames.Daffodil, 'h'),
                    new CattributeData(CattributeNames.Flamingo, 'i'), new CattributeData(CattributeNames.Bloodred, 'k'), new CattributeData(CattributeNames.Periwinkle, 'o'),
                    new CattributeData(CattributeNames.Seafoam, 'q'))
            { }
        }

        private class HightlightColorCategoryData
            : CattributeCategoryData
        {
            public HightlightColorCategoryData() :
                base(CattributeType.ColorHighlight, 27,
                    new CattributeData(CattributeNames.SpringCrocus, '2'), new CattributeData(CattributeNames.EgyptianKohl, '3'), new CattributeData(CattributeNames.PoisonBerry, '4'), new CattributeData(CattributeNames.Lilac, '5'),
                    new CattributeData(CattributeNames.Apricot, '6'), new CattributeData(CattributeNames.RoyalPurple, '7'), new CattributeData(CattributeNames.SwampGreen, '9'),
                    new CattributeData(CattributeNames.Violet, 'a'), new CattributeData(CattributeNames.Scarlet, 'b'), new CattributeData(CattributeNames.BarkBrown, 'c'),
                    new CattributeData(CattributeNames.Coffee, 'd'), new CattributeData(CattributeNames.Lemonade, 'e'), new CattributeData(CattributeNames.Chocolate, 'f'),
                    new CattributeData(CattributeNames.SafetyVest, 'i'), new CattributeData(CattributeNames.Turtleback, 'j'), new CattributeData(CattributeNames.Wolfgrey, 'm'),
                    new CattributeData(CattributeNames.Cerulian, 'n'), new CattributeData(CattributeNames.SkyBlue, 'o'), new CattributeData(CattributeNames.RoyalBlue, 's')
                )
            { }
        }

        private class EyeShapeCategoryData
            : CattributeCategoryData
        {
            public EyeShapeCategoryData() :
                base(CattributeType.EyeShape,  35,
                    new CattributeData(CattributeNames.Wonky, '2'), new CattributeData(CattributeNames.Serpent, '3'), new CattributeData(CattributeNames.Googly, '4'), new CattributeData(CattributeNames.Otaku, '5'),
                    new CattributeData(CattributeNames.Simple, '6'), new CattributeData(CattributeNames.Crazy, '7'), new CattributeData(CattributeNames.Thiccbrowz, '8'),
                    new CattributeData(CattributeNames.BadDate, 'b'), new CattributeData(CattributeNames.Chronic, 'd'), new CattributeData(CattributeNames.SlyBoots, 'e'),
                    new CattributeData(CattributeNames.Wiley, 'f'), new CattributeData(CattributeNames.Stunned, 'g'), new CattributeData(CattributeNames.Alien, 'i'),
                    new CattributeData(CattributeNames.Fabulous, 'j'), new CattributeData(CattributeNames.RaisedBrow, 'k'), new CattributeData(CattributeNames.Sass, 'o'),
                    new CattributeData(CattributeNames.SweetMeloncakes, 'p'), new CattributeData(CattributeNames.Wingtips, 'r'), new CattributeData(CattributeNames.Buzzed, 't')
                )
            { }
        }

        private class BodyCategoryData
            : CattributeCategoryData
        {
            public BodyCategoryData() :
                base(CattributeType.Body,47,
                    new CattributeData(CattributeNames.Savannah, '1'), new CattributeData(CattributeNames.Selkirk, '2'), new CattributeData(CattributeNames.Birmin, '4'),
                    new CattributeData(CattributeNames.Bobtail, '6'), new CattributeData(CattributeNames.Pixiebob, '8'), new CattributeData(CattributeNames.Cymric, 'a'),
                    new CattributeData(CattributeNames.Chartreux, 'b'), new CattributeData(CattributeNames.Himalayan, 'c'), new CattributeData(CattributeNames.Munchkin, 'd'),
                    new CattributeData(CattributeNames.Sphynx, 'e'), new CattributeData(CattributeNames.Ragamuffin, 'f'), new CattributeData(CattributeNames.Ragdoll, 'g'),
                    new CattributeData(CattributeNames.NorwegianForest, 'h'), new CattributeData(CattributeNames.Maincoon, 'n'), new CattributeData(CattributeNames.Laperm, 'o'),
                    new CattributeData(CattributeNames.Persian, 'p'), new CattributeData(CattributeNames.Manx, 't')
                )
            { }
        }

        private class MouthCategoryData
            : CattributeCategoryData
        {
            public MouthCategoryData() :
                base(CattributeType.Mouth,  15,
                    new CattributeData(CattributeNames.Whixtensions, '1'), new CattributeData(CattributeNames.WasntMe, '2'), new CattributeData(CattributeNames.WuvMe, '3'),
                    new CattributeData(CattributeNames.Gerbil, '4'),
                    new CattributeData(CattributeNames.Belch, '7'), new CattributeData(CattributeNames.Beard, '9'), new CattributeData(CattributeNames.Pouty, 'a'),
                    new CattributeData(CattributeNames.SayCheese, 'b'), new CattributeData(CattributeNames.Grim, 'c'), new CattributeData(CattributeNames.HappyGoKitty, 'f'),
                    new CattributeData(CattributeNames.SoSerious, 'g'), new CattributeData(CattributeNames.Cheeky, 'h'), new CattributeData(CattributeNames.Starstruck, 'i'),
                    new CattributeData(CattributeNames.Dali, 'm'), new CattributeData(CattributeNames.Grimace, 'n'), new CattributeData(CattributeNames.Tongue, 'p'),
                    new CattributeData(CattributeNames.Yokel, 'q'), new CattributeData(CattributeNames.Neckbeard, 's')
                )
            { }
        }

        private class PrimaryColorCategoryData
            : CattributeCategoryData
        {
            public PrimaryColorCategoryData() :
                base(CattributeType.ColorPrimary,  31,
                    new CattributeData(CattributeNames.ShadowGrey, '1'), new CattributeData(CattributeNames.Salmon, '2'), new CattributeData(CattributeNames.OrangeSoda, '4'),
                    new CattributeData(CattributeNames.CottonCandy, '5'), new CattributeData(CattributeNames.Mauveover, '6'),
                    new CattributeData(CattributeNames.Aquamarine, '7'), new CattributeData(CattributeNames.NachoCheez, '8'), new CattributeData(CattributeNames.HarbourFog, '9'),
                    new CattributeData(CattributeNames.GreyMatter, 'b'), new CattributeData(CattributeNames.Dragonfruit, 'e'), new CattributeData(CattributeNames.HinToMint, 'f'),
                    new CattributeData(CattributeNames.BananaCream, 'g'), new CattributeData(CattributeNames.CloudWhite, 'h'), new CattributeData(CattributeNames.OldLace, 'j'),
                    new CattributeData(CattributeNames.Koala, 'k'), new CattributeData(CattributeNames.Verdigris, 'p'), new CattributeData(CattributeNames.Onyx, 'r')
                )
            { }
        }

        // NOTE: TotesBasic not mapped
        private class PatternCategoryData
            : CattributeCategoryData
        {
            public PatternCategoryData() :
                base(CattributeType.Pattern, 43,
                    new CattributeData(CattributeNames.Tiger, '2'), new CattributeData(CattributeNames.Rascal, '3'), new CattributeData(CattributeNames.Ganado, '4'),
                    new CattributeData(CattributeNames.Leopard, '5'), new CattributeData(CattributeNames.Camo, '6'),
                    new CattributeData(CattributeNames.Spangled, '8'), new CattributeData(CattributeNames.Calicool, '9'), new CattributeData(CattributeNames.LuckyStripe, 'a'),
                    new CattributeData(CattributeNames.Amur, 'b'), new CattributeData(CattributeNames.Jaguar, 'c'), new CattributeData(CattributeNames.Spock, 'd'),
                    new CattributeData(CattributeNames.Thunderstruck, 'i'), new CattributeData(CattributeNames.DippedCone, 'j'), new CattributeData(CattributeNames.Tigerpunk, 'm'),
                    new CattributeData(CattributeNames.Henna, 'n'), new CattributeData(CattributeNames.Hotrod, 's'), new CattributeData(CattributeNames.TotesBasic, 'f'), new CattributeData(CattributeNames.TotesBasic, 'g')
                )
            { }
        }

        private class EyeColorCategoryData
            : CattributeCategoryData
        {
            public EyeColorCategoryData() :
                base(CattributeType.EyeColor,  39,
                    new CattributeData(CattributeNames.ThunderGrey, '1'), new CattributeData(CattributeNames.Gold, '2'), new CattributeData(CattributeNames.Topaz, '3'),
                    new CattributeData(CattributeNames.MintGreen, '4'), new CattributeData(CattributeNames.Sizzurp, '6'), new CattributeData(CattributeNames.Chestnut, '7'),
                    new CattributeData(CattributeNames.Strawberry, '8'), new CattributeData(CattributeNames.Sapphire, '9'), new CattributeData(CattributeNames.ForgetMeNot, 'a'),
                    new CattributeData(CattributeNames.CoralSunrise, 'c'), new CattributeData(CattributeNames.DoridNudiBranch, 'e'), new CattributeData(CattributeNames.Cyan, 'g'), new CattributeData(CattributeNames.Pumpkin, 'h'),
                    new CattributeData(CattributeNames.LimeGreen, 'i'), new CattributeData(CattributeNames.Bubblegum, 'k'), new CattributeData(CattributeNames.TwilightSparkle, 'm'),
                    new CattributeData(CattributeNames.BabyPuke, 'q')
                )
            { }
        }

        private class UnknownCategoryData
            : CattributeCategoryData
        {
            public UnknownCategoryData(CattributeType type,  int bitOffset)
                : base(type, bitOffset)
            { }
        }
    }
}
