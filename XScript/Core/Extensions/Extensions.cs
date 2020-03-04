using System;
using System.Collections.Generic;
using System.Linq;
using ScriptSDK;
using StealthAPI;
using ScriptSDK.Data;
using ScriptSDK.Engines;
using ScriptSDK.Items;
using XScript.Attributes;
using XScript.Enumerations;
using XScript.Interfaces;
using XScript.Items;

namespace XScript.Extensions
{
    public static class Extensions
    {
        public static ItemValue GetItemValue(this Item item)
        {
            if(!XConfig.Engine.Equals(ShardEngine.RebirthUO))
                return ItemValue.None;
            
                if (!item.Valid)
                    return ItemValue.None;
                var props = item.Properties;

                if (ClilocHelper.GetIndex(props, 1150541) > -1)
                {
                    var value = ClilocHelper.GetParams(props, 1150541)[0];
                    if (value.Equals("[ <BASEFONT COLOR=#FFFAFA>Common<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.Common;
                    if (value.Equals("[ <BASEFONT COLOR=#1EFF00>Uncommon<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.Uncommon;
                    if (value.Equals("[ <BASEFONT COLOR=#0070FF>Rare<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.Rare;
                    if (value.Equals("[ <BASEFONT COLOR=#A335EE>Epic<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.Epic;
                    if (value.Equals("[ <BASEFONT COLOR=#FF8000>Legendary<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.Legendary;
                    if (value.Equals("[ <BASEFONT COLOR=#FF0000>Event<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.Event;
                    if (value.Equals("[ <BASEFONT COLOR=#B0E0E6>One Of A Kind<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.OOAK;
                    if (value.Equals("[ <BASEFONT COLOR=#FFFF00>Artifact<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.Artifact;
                    if (value.Equals("[ <BASEFONT COLOR=#580b1c>ITS - Artifact<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.ITSArtifact;
                    if (value.Equals("[ <BASEFONT COLOR=#7CFC00>Newbie<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.Newbie;
                    if (value.Equals("[ <BASEFONT COLOR=#D8BFD8>Set Item<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.SetItem;
                    if (value.Equals("[ <BASEFONT COLOR=#FF69B4>Donation<BASEFONT COLOR=#FFFFFF> ]"))
                        return ItemValue.Donation;
                }
                return ItemValue.None;
        }

        public static int ReadArtifactRarity(this IArtifactRarity obj, List<ClilocItemRec> reader)
        {
            return ClilocHelper.Contains(reader, 1061078) ? 0 : ClilocHelper.GetParams(reader, 1061078)[0];
        }

        public static CraftResource ReadCraftResource(this ICraftable obj, List<ClilocItemRec> reader)
        {
            if (ClilocHelper.Contains(reader, 1053099))
            {
                var Value = ClilocHelper.GetParams(reader, 1053099)[0];
                return
                    (from object e in Enum.GetValues(typeof (CraftResource)) where Value.Equals(e) select e)
                        .Cast<CraftResource>().FirstOrDefault();
            }
            return CraftResource.Default;
        }

        public static int ReadGorgonCharges(this IGorgonCharges obj, List<ClilocItemRec> properties)
        {
            return !ClilocHelper.Contains(properties, 1112590) ? 0 : ClilocHelper.GetParams(properties, 1112590)[0];
        }

        public static string ReadEngraveable(this IEngraveable obj, List<ClilocItemRec> properties)
        {
            return !ClilocHelper.Contains(properties, 1062613)
                ? string.Empty
                : ClilocHelper.GetParams(properties, 1062613)[0];
        }

        public static bool ReadFactionItemState(this IFactionItem obj, List<ClilocItemRec> properties)
        {
            return (ClilocHelper.Contains(properties, 1041350));
        }

        public static bool ReadAlteringState(this IAlterable obj, List<ClilocItemRec> properties)
        {
            return (ClilocHelper.Contains(properties, 1111880));
        }

        public static bool ReadMediableState(this ArmorMaterialType obj, List<ClilocItemRec> properties)
        {
            switch (obj)
            {
                case ArmorMaterialType.Cloth:
                    return true;
                case ArmorMaterialType.Leather:
                    return true;
            }
            return false;
        }

        public static SkillName ReadSkillRequirements(this IWeapon obj, List<ClilocItemRec> properties)
        {
            if (ClilocHelper.Contains(properties, 1061172))
                return SkillName.Swords;
            if (ClilocHelper.Contains(properties, 1061173))
                return SkillName.Macing;
            if (ClilocHelper.Contains(properties, 1061174))
                return SkillName.Fencing;
            if (ClilocHelper.Contains(properties, 1061175))
                return SkillName.Archery;
            return ClilocHelper.Contains(properties, 1112075) ? SkillName.Throwing : SkillName.Invalid;
        }

        public static double GetFillState(this IHasQuantity obj, List<ClilocItemRec> properties)
        {
            if (ClilocHelper.Contains(properties, 1042974)) // It's nearly empty.
                return 33.33;
            if (ClilocHelper.Contains(properties, 1042973)) // It's half full.
                return 66.66;
            return ClilocHelper.Contains(properties, 1042972) ? 100.0 : 0.0;
        }

        public static T Cast<T>(this UOEntity obj) where T : UOEntity
        {
            return Activator.CreateInstance(typeof (T), obj.Serial) as T;
        }

        public static bool ReadImbueState(this IImbueable obj, List<ClilocItemRec> properties)
        {
            return (ClilocHelper.Contains(properties, 1080418));
        }

        public static int[] ReadDurability(this IDurability obj, List<ClilocItemRec> properties)
        {
            if (!ClilocHelper.Contains(properties, 1060639))
                return new[] {0, 0};

            var Params = ClilocHelper.GetParams(properties, 1060639);
            var dura = new int[] {Params[0], Params[1]};
            return dura;
        }

        public static string ReadDecorationMessage(this IDecorateable ic, List<ClilocItemRec> properties)
        {
            return !ClilocHelper.Contains(properties, 1073183)
                ? string.Empty
                : ClilocHelper.GetParams(properties, 1073183)[0];
        }

        public static bool ReadIsExceptionalState(this ICraftable ic, List<ClilocItemRec> properties)
        {
            return (ClilocHelper.Contains(properties, 1060636));
        }

        public static string ReadCrafterName(this ICraftable ic, List<ClilocItemRec> properties)
        {
            return !ClilocHelper.Contains(properties, 1050043)
                ? string.Empty
                : ClilocHelper.GetParams(properties, 1050043)[0];
        }

        public static bool ReadBrittleState(this IDurability ic, List<ClilocItemRec> properties)
        {
            return (ClilocHelper.Contains(properties, 1116209));
        }

        public static bool ReadCursedState(this IDurability ic, List<ClilocItemRec> properties)
        {
            return (ClilocHelper.Contains(properties, 1049643));
        }

        public static bool ReadAntiqueState(this IDurability ic, List<ClilocItemRec> properties)
        {
            return (ClilocHelper.Contains(properties, 1152714));
        }

        public static bool ReadCannotRepairedState(this IDurability ic, List<ClilocItemRec> properties)
        {
            return (ClilocHelper.Contains(properties, 1151782));
        }

        public static bool ReadCanBeCooked(this ICookable food)
        {
            var old = Scanner.Range;
            Scanner.Range = 1;
            var sourcelist = new List<ushort>();
            for (ushort v = 0xDE3; v <= 0xDE9; v++) //Camp Fire
                sourcelist.Add(v);

            for (ushort v = 0x461; v <= 0x48E; v++) // Sandstone oven/fireplace
                sourcelist.Add(v);

            for (ushort v = 0x92B; v <= 0x96C; v++) // Stone oven/fireplace
                sourcelist.Add(v);

            for (ushort v = 0x184A; v <= 0x184C; v++) // Heating stand (left)
                sourcelist.Add(v);

            for (ushort v = 0x184E; v <= 0x1850; v++) // Heating stand (right)
                sourcelist.Add(v);

            for (ushort v = 0x398C; v <= 0x399F; v++) // Fire field
                sourcelist.Add(v);

            sourcelist.Add(0xFAC); //Fire Pit

            var state = (Scanner.Find<UOEntity>(sourcelist, 0xFFFF, 0x0, false).Count > 0);
            Scanner.Range = old;
            return state;
        }

        public static Layer ReadHandingType(this IWeapon ic, List<ClilocItemRec> properties)
        {
            return ClilocHelper.Contains(properties, 1061171) ? Layer.TwoHanded : Layer.OneHanded;
        }

        public static PoisonLevel ReadPoisonLevel(this IPoisonable obj, List<ClilocItemRec> reader)
        {
            return
                (from PoisonLevel x in Enum.GetValues(typeof (PoisonLevel)) where !x.Equals(PoisonLevel.None) select x)
                    .FirstOrDefault(x => ClilocHelper.Contains(reader, (uint) x));
        }

        public static int ReadWeaponRange(this IRangeWeapon ic, List<ClilocItemRec> properties)
        {
            return !ClilocHelper.Contains(properties, 1061169) ? 1 : ClilocHelper.GetParams(properties, 1061169)[0];
        }

        public static int[] ReadArcaneCharges(this IArcaneEquip obj, List<ClilocItemRec> reader)
        {
            if (!ClilocHelper.Contains(reader, 1061837))
                return new[] {0, 0};

            var Params = ClilocHelper.GetParams(reader, 1061837);
            var charges = new int[] {Params[0], Params[1]};
            return charges;
        }

        public static SlayerName GetSlayer(this ISlayer obj, List<ClilocItemRec> reader, int Index = 1)
        {
            return
                (from SlayerName x in Enum.GetValues(typeof (SlayerName)) where !x.Equals(SlayerName.None) select x)
                    .FirstOrDefault(x => ClilocHelper.Contains(reader, (uint) x));
        }

        public static bool ReadImmolation(this IWeapon obj, List<ClilocItemRec> reader)
        {
            return (ClilocHelper.Contains(reader, 1111917));
        }

        public static bool ReadEnchantment(this IWeapon obj, List<ClilocItemRec> reader)
        {
            return (ClilocHelper.Contains(reader, 1080125));
        }

        public static int ReadLowerStatRequirement(this IWeapon ic, List<ClilocItemRec> properties)
        {
            return !ClilocHelper.Contains(properties, 1060435) ? 0 : ClilocHelper.GetParams(properties, 1060435)[0];
        }

        public static int ReadLowerStrRequirement(this IWeapon ic, List<ClilocItemRec> properties)
        {
            return !ClilocHelper.Contains(properties, 1061170) ? 0 : ClilocHelper.GetParams(properties, 1061170)[0];
        }

        public static double ReadWeaponSpeed(this IWeapon ic, List<ClilocItemRec> properties)
        {
            return !ClilocHelper.Contains(properties, 1061167) ? 1.0 : ClilocHelper.GetParams(properties, 1061167)[0];
        }

        public static int[] ReadWeaponDamage(this IWeapon ic, List<ClilocItemRec> properties)
        {
            if (!ClilocHelper.Contains(properties, 1061168))
                return new[] {0, 0};

            var Params = ClilocHelper.GetParams(properties, 1061168);
            var damages = new int[] {Params[0], Params[1]};
            return damages;
        }

        public static int ReadWandCharges(this BaseWand obj, List<ClilocItemRec> properties)
        {
            foreach (
                var w in
                    from object w in Enum.GetValues(typeof (WandEffect))
                    where ClilocHelper.Contains(properties, (uint) w)
                    select w)
            {
                return ClilocHelper.GetParams(properties, (uint) w)[0];
            }
            return 0;
        }

        public static WandEffect ReadWandType(this BaseWand obj, List<ClilocItemRec> properties)
        {
            return
                Enum.GetValues(typeof (WandEffect))
                    .Cast<WandEffect>()
                    .FirstOrDefault(w => ClilocHelper.Contains(properties, (uint) w));
        }

        public static LootValue ReadLootValue(this ILootValue iv, List<ClilocItemRec> properties)
        {
            return
                Enum.GetValues(typeof (LootValue))
                    .Cast<LootValue>()
                    .FirstOrDefault(e => ClilocHelper.Contains(properties, (uint) e));
        }

        public static dynamic[] ReadSkillBonus(this SkillBonuses attrib, uint ClilocID, List<ClilocItemRec> properties)
        {
            var result = new dynamic[2];

            if ((ClilocHelper.GetIndex(properties, ClilocID) > -1))
            {
                var p = ClilocHelper.GetParams(properties, ClilocID);
                result[0] = (SkillName) p[0];
                result[1] = p[1];
            }
            else
            {
                result[0] = SkillName.Invalid;
                result[1] = 0.0;
            }
            return result;
        }
    }
}