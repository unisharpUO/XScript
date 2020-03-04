//*******************************************************************
//* Class           : Runebook.cs
//* Author          : Jan Siems 
//* Last Update     : 01.10.15
//*******************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using ScriptSDK;
using StealthAPI;
using ScriptSDK.Data;
using ScriptSDK.Engines;
using ScriptSDK.Gumps;
using ScriptSDK.Items;
using XScript.Extensions;
using XScript.Interfaces;

namespace XScript.Items
{

    public class RunebookEntry
    {
        public Runebook _owner { get; private set; }

        public string Name { get; private set; }
        public string Location { get; private set; }
        public uint Hue { get; private set; }
        public int DefaultButton { get; private set; }
        public int DropButton { get; private set; }
        public int Gatebutton { get; private set; }
        public int SacredButton { get; private set; }
        public int RecallButton { get; private set; }
        public int ScrollButton { get; private set; }

        public RunebookEntry(Runebook owner, string name, string position, uint color, int def, int drop, int gate, int sacred, int recall, int scroll)
        {
            _owner = owner;
            Name = name;
            Location = position;
            Hue = color;
            DefaultButton = def;
            DropButton = drop;
            Gatebutton = gate;
            SacredButton = sacred;
            RecallButton = recall;
            ScrollButton = scroll;
        }
    }

    [QuerySearch(0x22C5)]
    public class Runebook : Item, ICraftable
    {
        #region Vars
        private Gump _lastparsedgump;
        public int DefaultRune { get; protected set; }

        private int _renamebutton;
        #endregion

        #region Triggers

        public override int DefaultLabelNumber
        {
            get
            {
                switch (XConfig.Engine)
                {
                    case ShardEngine.Broadsword:
                        return 1041267;
                    case ShardEngine.RebirthUO:
                        return 1041267;
                }
                return 0;
            }
        }

        public uint GumpType
        {
            get
            {
                switch (XConfig.Engine)
                {
                    case ShardEngine.Broadsword:
                        return 0x0059;
                    case ShardEngine.RebirthUO:
                        return 0x554B87F3;
                }
                return 0;
            }
        }

        public int BaseScrollOffset
        {
            get
            {
                switch (XConfig.Engine)
                {
                    case ShardEngine.Broadsword:
                        return 10;
                    case ShardEngine.RebirthUO:
                        return 2;
                }
                return 0;
            }
        }

        public int BaseDropOffset
        {
            get
            {
                switch (XConfig.Engine)
                {
                    case ShardEngine.Broadsword:
                        return 200;
                    case ShardEngine.RebirthUO:
                        return 3;
                }
                return 0;
            }
        }

        public int BaseSetDefaultOffset
        {
            get
            {
                switch (XConfig.Engine)
                {
                    case ShardEngine.Broadsword:
                        return 300;
                    case ShardEngine.RebirthUO:
                        return 4;
                }
                return 0;
            }
        }

        public int BaseRecallOffset
        {
            get
            {
                switch (XConfig.Engine)
                {
                    case ShardEngine.Broadsword:
                        return 50;
                    case ShardEngine.RebirthUO:
                        return 5;
                }
                return 0;
            }
        }

        public int BaseGateOffset
        {
            get
            {
                switch (XConfig.Engine)
                {
                    case ShardEngine.Broadsword:
                        return 100;
                    case ShardEngine.RebirthUO:
                        return 6;
                }
                return 0;
            }
        }

        public int BaseSacredOffset
        {
            get
            {
                switch (XConfig.Engine)
                {
                    case ShardEngine.Broadsword:
                        return 75;
                    case ShardEngine.RebirthUO:
                        return 7;
                }
                return 0;
            }
        }

        public int Jumper
        {
            get
            {
                switch (XConfig.Engine)
                {
                    case ShardEngine.Broadsword:
                        return 1;
                    case ShardEngine.RebirthUO:
                        return 6;
                }
                return 0;
            }
        }
        #endregion

        #region Constructors
        public Runebook(Serial serial)
            : base(serial)
        {
            CurCharges = -1;
            MaxCharges = -1;
        }
        public Runebook(uint objectID)
            : this(new Serial(objectID))
        {
        }
        #endregion

        #region Properties
        public bool Exceptional
        {
            get { return this.ReadIsExceptionalState(Properties); }
        }

        public string Crafter
        {
            get { return this.ReadCrafterName(Properties); }
        }

        public string Description
        {
            get { return this.ReadDescription(Properties); }
        }

        public List<RunebookEntry> Entries { get; private set; }

        public int CurCharges { get; private set; }

        public int MaxCharges { get; private set; }
        #endregion

        #region Functions

        protected virtual bool ParseGump(Gump g)
        {
            CurCharges = -1;
            MaxCharges = -1;
            Entries = new List<RunebookEntry>();
            _renamebutton = -1;
            DefaultRune = -1;
            _lastparsedgump = null;
            if (g.GumpType.Equals(GumpType))
            {
                _lastparsedgump = g;
                //Charges
                int Value;
                int.TryParse(g.HTMLTexts[0].Text, out Value);
                CurCharges = Value;
                int.TryParse(g.HTMLTexts[1].Text, out Value);
                MaxCharges = Value;


                var rButton = g.Buttons.First(e => e.Graphic.Released.Equals(2472) || e.Graphic.Pressed.Equals(2473));
                if (rButton != null)
                {
                    //Rename Button
                    _renamebutton = g.Buttons.First(e => e.Graphic.Released.Equals(2472) || e.Graphic.Pressed.Equals(2473)).PacketValue;
                }

                rButton = g.Buttons.FirstOrDefault(e => e.Graphic.Released.Equals(2360) || e.Graphic.Pressed.Equals(2360));
                if (rButton != null)
                {
                    // Highlighted Rune :
                    DefaultRune = (rButton.PacketValue / BaseSetDefaultOffset) + 1;
                }



                //Entries
                for (var i = 0; i < 15; i++)
                {
                    var PacketSetDefault = BaseSetDefaultOffset + (i * Jumper);
                    var PacketDropRune = BaseDropOffset + (i * Jumper);
                    var PacketUseGate = BaseGateOffset + (i * Jumper);
                    var PacketUseSacred = BaseSacredOffset + (i * Jumper);
                    var PacketUseRecall = BaseRecallOffset + (i * Jumper);
                    var PacketUseScroll = BaseScrollOffset + (i * Jumper);
                    var title = g.Labels[i].Text;
                    var Hue = g.Labels[i].Color;
                    var position = "Nowhere";
                    var add = false;

                    switch (XConfig.Engine)
                    {
                        case ShardEngine.Broadsword:
                            {

                                if (2 + i < g.HTMLTexts.Count)
                                {
                                    position = g.HTMLTexts[2 + i].Text;
                                    add = true;
                                }
                                break;
                            }
                        case ShardEngine.RebirthUO:
                            {
                                if ((2 * i) + 1 < g.Labels.Count)
                                {
                                    position = g.Labels[(2 * i)].Text + g.Labels[(2 * i) + 1].Text;
                                    add = true;
                                }
                                break;
                            }
                    }
                    if (add)
                        Entries.Add(new RunebookEntry(this, title, position, (uint)Hue, PacketSetDefault, PacketDropRune, PacketUseGate, PacketUseSacred, PacketUseRecall, PacketUseScroll));
                }
                return true;
            }
            return false;
        }


        public bool Close()
        {
            _lastparsedgump.Close();
            return _lastparsedgump.WaitForGumpClose(1000);
        }


        public bool Open()
        {
            Close();
            if (DoubleClick() && Gump.WaitForGump(GumpType, 1000))
            {
                var gump = Gump.GetGump(GumpType);
                _lastparsedgump = gump;
                return gump.Serial.Value > 0;
            }
            return false;
        }

        public bool Parse()
        {
            return Open() && ParseGump(_lastparsedgump) && Close();
        }

        public bool Recall()
        {
            return Stealth.Client.CastSpellToObj("Recall", Serial.Value);
        }
        public bool Sacred()
        {
            return Stealth.Client.CastSpellToObj("Sacred Journey", Serial.Value);
        }
        public bool Gate()
        {
            return Stealth.Client.CastSpellToObj("Gate Travel", Serial.Value);
        }

        public bool Recall(RunebookEntry entry)
        {
            var button = _lastparsedgump.Buttons.First(e => e.PacketValue.Equals(entry.RecallButton));
            return Open() && button != null && button.Click();
        }
        public bool Sacred(RunebookEntry entry)
        {
            var button = _lastparsedgump.Buttons.First(e => e.PacketValue.Equals(entry.SacredButton));
            return Open() && button != null && button.Click();
        }
        public bool Gate(RunebookEntry entry)
        {
            var button = _lastparsedgump.Buttons.First(e => e.PacketValue.Equals(entry.Gatebutton));
            return Open() && button != null && button.Click();
        }
        public bool UseScroll(RunebookEntry entry)
        {
            var button = _lastparsedgump.Buttons.First(e => e.PacketValue.Equals(entry.ScrollButton));
            return Open() && button != null && button.Click();
        }
        public bool DropRune(RunebookEntry entry)
        {
            var button = _lastparsedgump.Buttons.First(e => e.PacketValue.Equals(entry.DropButton));
            return Open() && button != null && button.Click();
        }
        public bool SetDefault(RunebookEntry entry)
        {
            var button = _lastparsedgump.Buttons.First(e => e.PacketValue.Equals(entry.DefaultButton));
            return Open() && button != null && button.Click();
        }
        public bool Rename()
        {
            var button = _lastparsedgump.Buttons.First(e => e.PacketValue.Equals(_renamebutton));
            return Open() && button != null && button.Click();
        }

        public bool Active()
        {
            return _lastparsedgump.Index > -1;
        }
        #endregion
    }

    public static class RunebookExtensions
    {
        public static string ReadDescription(this Runebook rb, List<ClilocItemRec> attrib)
        {
            uint ClilocID = 0;
            switch (XConfig.Engine)
            {
                case ShardEngine.Broadsword:
                    ClilocID = 1070722;
                    break;
                case ShardEngine.RebirthUO:
                    ClilocID = 1042971;
                    break;
            }
            return !ClilocHelper.Contains(attrib, ClilocID) ? String.Empty : ClilocHelper.GetParams(attrib, ClilocID)[0];
        }
    }
}