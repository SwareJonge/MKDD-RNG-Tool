using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MKDD_RNG_Tool.Utils;

namespace MKDD_RNG_Tool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            uint[] SpecialItem = new uint[8];
            string SpecialItemName = "";
            string Character = comboBox1.GetItemText(comboBox1.SelectedItem);
            uint[] empty = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int comboID = 0;

            bool petey_boo = false;

            uint[] tShells = { 0, 10, 20, 10, 10, 10, 0, 0 };
            uint[] bwserShell = { 0, 10, 10, 20, 10, 0, 0, 0 };
            uint[] gBanana = { 50, 20, 0, 0, 0, 0, 0, 0 };
            uint[] fireBalls = { 0, 10, 10, 10, 10, 10, 10, 0 };
            uint[] Bomb = { 0, 0, 10, 10, 10, 10, 0, 0 };
            uint[] Egg = { 10, 10, 10, 10, 10, 10, 10, 0 };
            uint[] Dog = { 0, 0, 0, 0, 0, 0, 10, 30 };
            uint[] gMushroom = { 0, 0, 0, 0, 10, 10, 20, 10 };
            uint[] Heart = { 0, 0, 0, 0, 0, 10, 10, 20 };

            if (Character == "Koopa/Paratroopa")
            {
                SpecialItem = new uint[8] { 20, 50, 100, 100, 100, 100, 50, 0 }; // entry 1
                SpecialItemName = "Triple Green Shells"; // HEX ID 0x11
                comboID = 9;
            }
            else if (Character == "Bowser/Bowser Jr.")
            {
                SpecialItem = new uint[8] { 20, 50, 100, 100, 100, 100, 50, 0 }; // entry 2
                SpecialItemName = "Bowser Shell"; // HEX ID 0x1
                comboID = 0xA;
            }
            else if (Character == "Donkey Kong/Diddy Kong")
            {
                SpecialItem = new uint[8] { 120, 100, 90, 60, 30, 0, 0, 0 }; // entry 3
                SpecialItemName = "Giant Banana"; // HEX ID 0x4
                comboID = 0xB;
            }
            else if (Character == "Mario/Luigi")
            {
                SpecialItem = new uint[8] { 0, 60, 100, 100, 100, 100, 60, 0 }; // entry 4
                SpecialItemName = "Red/Green Fire Balls"; // HEX ID 0x15
                comboID = 0xC;
            }
            else if (Character == "Wario/Waluigi")
            {
                SpecialItem = new uint[8] { 20, 60, 100, 100, 100, 100, 60, 0 }; // entry 5
                SpecialItemName = "Bob-Omb"; // HEX ID 0x8
                comboID = 0xD;
            }
            else if (Character == "Yoshi/Birdo")
            {
                SpecialItem = new uint[8] { 40, 70, 80, 80, 80, 70, 60, 0 }; // entry 6
                SpecialItemName = "Yoshi/Birdo Egg"; // HEX ID 0xB
                comboID = 0xE;
            }
            else if (Character == "Baby Mario/Baby Lugi")
            {
                SpecialItem = new uint[8] { 0, 0, 1, 3, 20, 20, 130, 180 }; // entry 7
                SpecialItemName = "Chain Chomp"; // HEX ID 0x7
                comboID = 0xF;
            }
            else if (Character == "Toad/Toadette")
            {
                SpecialItem = new uint[8] { 0, 3, 10, 30, 50, 80, 100, 120 }; // entry 8
                SpecialItemName = "Golden Mushroom"; // HEX ID 0xC
                comboID = 0x10;
            }
            else if (Character == "Peach/Daisy")
            {
                SpecialItem = new uint[8] { 0, 1, 3, 10, 30, 90, 110, 130 }; // entry 9
                SpecialItemName = "Heart"; // HEX ID 0xE
                comboID = 0x11;
            }
            else if (Character == "Petey/King Boo")
            {
                petey_boo = true;
            }
            else // Default
            {
                SpecialItem = new uint[8] { 20, 50, 100, 100, 100, 100, 50, 0 }; // entry 1
                SpecialItemName = "Triple Green Shells"; // HEX ID 0x11
            }

            string[] NormalItems = { "Green Shell", "Red Shell", "Blue Shell", "Banana", "Mushroom", "Triple Mushroom", "Star", "Lightning", "Fake Item Box", SpecialItemName };

            if (petey_boo)
            {
                NormalItems = new string[] { "Green Shell", "Red Shell", "Blue Shell", "Banana", "Mushroom", "Triple Mushroom", "Star", "Lightning", "Fake Item Box", "Triple Green Shells", "Bowser Shell", "Giant Banana", "Fire Balls", "Bomb", "Egg", "Chain Chomp", "Golden Mushroom", "Heart" };
            }
            int NormalItemCount = NormalItems.Length;

            uint[] GreenShell = { 100, 60, 45, 10, 0, 0, 0, 0 };
            uint[] RedShell = { 0, 45, 60, 75, 70, 50, 40, 20 };
            uint[] BlueShell = { 0, 0, 0, 10, 15, 20, 20, 20 };
            uint[] Banana = { 70, 35, 15, 5, 0, 0, 0, 0 };
            uint[] Mushroom = { 0, 40, 60, 70, 60, 35, 10, 0 };
            uint[] _3Mushroom = { 0, 0, 10, 20, 35, 55, 70, 90 };
            uint[] Star = { 0, 0, 0, 10, 20, 30, 40, 40 };
            uint[] Lightning = { 0, 0, 0, 0, 0, 10, 20, 30 };
            uint[] FIB = { 30, 20, 10, 0, 0, 0, 0, 0 };

            if (!checkBox2.Checked)
                Lightning = empty;

            if (checkBox1.Checked)
                BlueShell = empty;

            if (checkBox3.Checked)
            {
                for (int j = 0; j < 8; j++)
                {
                    SpecialItem[j] = (uint)Math.Floor(SpecialItem[j] * 1.5f);
                    // for Petey and Boo
                    tShells[j] = (uint)Math.Floor(tShells[j] * 1.5f);
                    bwserShell[j] = (uint)Math.Floor(bwserShell[j] * 1.5f);
                    gBanana[j] = (uint)Math.Floor(gBanana[j] * 1.5f);
                    fireBalls[j] = (uint)Math.Floor(fireBalls[j] * 1.5f);
                    Bomb[j] = (uint)Math.Floor(Bomb[j] * 1.5f);
                    Egg[j] = (uint)Math.Floor(Egg[j] * 1.5f);
                    Dog[j] = (uint)Math.Floor(Dog[j] * 1.5f);
                    gMushroom[j] = (uint)Math.Floor(gMushroom[j] * 1.5f);
                    Heart[j] = (uint)Math.Floor(Heart[j] * 1.5f);
                }
            }

            Array[] Lst = { GreenShell, RedShell, BlueShell, Banana, Mushroom, _3Mushroom, Star, Lightning, FIB, SpecialItem };
            if (petey_boo)
            {
                Lst = new Array[] { GreenShell, RedShell, BlueShell, Banana, Mushroom, _3Mushroom, Star, Lightning, FIB, tShells, bwserShell, gBanana, fireBalls, Bomb, Egg, Dog, gMushroom, Heart };
            }

            IDictionary<byte, byte> IDtoIDX = new Dictionary<byte, byte>()
            {
                // Normal Items
                {0x0, 0x0}, // Green Shell
                {0x2, 0x1}, // Red Shell
                {0x3, 0x3}, // Banana
                {0x5, 0x4}, // Mushroom
                {0xF,  0x8}, // FIB
                // Power Items
                {0xD,  0x2}, // Blue Shell
                {0x12, 0x5}, // Triple Mushrooms
                {0x6,  0x6}, // Star
                {0xA,  0x7}, // Thunderbolt/Shock/Lightning
                // Special Item(these should all be set to 0x9 except for petey and king boo?)
            };

            byte[] useableItems = { 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1,
                0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1, 0x1,
                0x1, 0x1};
            byte[] sSlotKindIndexArray = { 0x0, 0x2, 0xD, 0x3, 0x5, 0x12, 0x6, 0xA, 0xF, 0x11, 0x1, 0x4, 0x15, 0x8, 0xB, 0x7, 0xC, 0xE, 0x11, 0x1, 0x4, 0x15, 0x8, 0xB, 0x7, 0xC, 0xE };
            byte[] ToNameID = { 0x0, 0x2, 0xD, 0x3, 0x5, 0x12, 0x6, 0xA, 0xF, 0x11, 0x1, 0x4, 0x15, 0x8, 0xB, 0x7, 0xC, 0xE, 0x11, 0x1, 0x4, 0x15, 0x8, 0xB, 0x7, 0xC, 0xE };
            int output = -1;

            uint startRNG = uint.Parse(textBox1.Text.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber);

            dataGridView1.Columns.Add("RNGSeed", "Seed");
            for (int j = 0; j < 8; j++)
            {
                dataGridView1.Columns.Add("ItemPos" + j.ToString(), (j + 1).ToString());
            }

            int i = 0;
            int seedsToShow = (int)numericUpDown1.Value;

            string[] posItemOut = new string[8];
            Array[] itemListBackup = Lst;

            int[] ItemTotal = new int[Lst.Length];
            uint[] item = new uint[NormalItems.Length];

            while (i < seedsToShow)
            {
                uint RNG = startRNG;

                for (int j = 0; j < 8; j++)
                {
                    uint TOTAL = 0;
                    for (int k = 0; k < Lst.Length; k++)
                    {
                        item = (uint[])Lst[k];
                        TOTAL += item[j];
                    } // Has to be reset every cycle

                    output = ItemRndMgr.calcRank(RNG, useableItems, Lst, comboID, j, TOTAL, petey_boo);

                    for (int k = 0; k < useableItems.Length; k++)
                    {
                        useableItems[k] = 1; // reset the field 
                    }

                    if (IDtoIDX.ContainsKey((byte)output))
                    {
                        posItemOut[j] = NormalItems[IDtoIDX[(byte)output]];
                    }
                    else if (!petey_boo)
                    {
                        posItemOut[j] = NormalItems[9];
                    }
                    else
                    {
                        if (petey_boo)
                        {
                            posItemOut[j] = NormalItems[output];
                        }
                    }

                    if (output == 0x11)
                    {
                        posItemOut[j] = "Triple Green Shells";
                        if (j != 0) // if not in first place, can't pull triple red(the driver can't pull this either)
                        {
                            startRNG = stRandom.AdvanceRNG(startRNG);
                            if (0.4 < (stRandom.shiftRNGcnvtoFloat(startRNG)))
                            {
                                posItemOut[j] = "Triple Red Shells";
                                output = 0x13;
                            }
                        }
                    }
                }

                startRNG = stRandom.AdvanceRNG(startRNG);
                dataGridView1.Rows.Add(RNG.ToString("X2"), posItemOut[0], posItemOut[1], posItemOut[2], posItemOut[3], posItemOut[4], posItemOut[5], posItemOut[6], posItemOut[7]);
                i++;
            }

        }

        bool isDefaultcombo(string Character1, string Character2)
        {
            if (Character1 == Character2)
            {
                return true;
            }
            return false;
        }
    }



}
