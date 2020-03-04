using System;
using ScriptSDK;
using StealthAPI;
using ScriptSDK.Items;
using XScript.Items;
using System.Collections.Generic;
using System.Linq;
using ScriptSDK.Data;

namespace XScript.Scripts.unisharpUO
{
    public class LocateGear
    {
        private static List<ushort> ArmorTypes = GetTypes(typeof(BaseArmor));
        private static List<ushort> WeaponTypes = GetTypes(typeof(BaseWeapon));
        private static List<ushort> ShieldTypes = GetTypes(typeof(BaseShield));
        private static List<ushort> JewelTypes = GetTypes(typeof(BaseJewel));

        public static List<BaseArmor> ArmorList = new List<BaseArmor>();
        public static List<BaseWeapon> WeaponList = new List<BaseWeapon>();
        public static List<BaseShield> ShieldList = new List<BaseShield>();
        public static List<BaseJewel> JewelList = new List<BaseJewel>();

        public static List<ushort> GetTypes(Type T)
        {
            var ca = T.GetCustomAttributes(false);
            var tlist = new List<ushort>();

            if (ca != null)
            {

                foreach (var a in ca)
                {
                    if (a is QuerySearchAttribute)
                    {
                        var x = (QuerySearchAttribute)a;
                        tlist.AddRange(x.Graphics);
                    }
                    else if (a is QueryTypeAttribute)
                    {
                        var x = (QueryTypeAttribute)a;
                        foreach (var e in x.Types)
                            tlist.AddRange(GetTypes(e));
                    }
                }
            }

            return tlist.Distinct().ToList();
        }

        public static void Find(Item Container, List<string> Types)
        {
            List<Item> _itemList = new List<Item>();
            List<uint> _findList = new List<uint>();

            Stealth.Client.FindTypeEx(0xFFFF, 0xFFFF, Container.Serial.Value, true);
            if (!(Stealth.Client.GetFindCount() == 0))
                _findList = Stealth.Client.GetFindList();

            foreach (uint _item in _findList)
            {
                _itemList.Add(new Item(new Serial(_item)));
            }

            foreach (string _type in Types)
            {
                if (_type == "Armor")
                    ArmorList = _itemList.Where(e => ArmorTypes.Contains(e.ObjectType)).Select(e => new BaseArmor(e.Serial)).ToList();
                else if (_type == "Weapon")
                    WeaponList = _itemList.Where(e => WeaponTypes.Contains(e.ObjectType)).Select(e => new BaseWeapon(e.Serial)).ToList();
                else if (_type == "Shield")
                    ShieldList = _itemList.Where(e => ShieldTypes.Contains(e.ObjectType)).Select(e => new BaseShield(e.Serial)).ToList();
                else if (_type == "Jewel")
                    JewelList = _itemList.Where(e => JewelTypes.Contains(e.ObjectType)).Select(e => new BaseJewel(e.Serial)).ToList();
            }
        }
    }
}
