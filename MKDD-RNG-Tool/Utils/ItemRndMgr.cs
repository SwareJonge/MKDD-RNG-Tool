using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MKDD_RNG_Tool.Utils;

namespace MKDD_RNG_Tool.Utils
{
    public class ItemRndMgr
    {
        public static int calcRank(uint Seed, byte[] useableItems, Array[] ItemList, int comboID, int rankIdx, uint maxItemCnt, bool petey_boo)
        {
            byte[] sSlotKindIndexArray = { 0x0, 0x2, 0xD, 0x3, 0x5, 0x12, 0x6, 0xA, 0xF, 0x11, 0x1, 0x4, 0x15, 0x8, 0xB, 0x7, 0xC, 0xE, 0x11, 0x1, 0x4, 0x15, 0x8, 0xB, 0x7, 0xC, 0xE };

            int output = -1;
            uint randomNum = stRandom.getRandomMax(Seed, maxItemCnt - 1);
            int possibleItems = 0xA;

            if (petey_boo)
            {
                possibleItems = 0x1B;
            }

            int itemIdx = 0;
            int ItemChance = 0;
            int uVar2 = 0;

            do
            {
                if (possibleItems == 0)
                {
                    break;
                }

                int specialIdx = itemIdx;
                uint[] item = (uint[])ItemList[itemIdx];
                ItemChance = (int)item[rankIdx];

                if (!petey_boo)
                {
                    if (itemIdx >= 9)
                    {
                        specialIdx = comboID;
                        uint[] SpecialItem = (uint[])ItemList[9];
                        ItemChance = (int)(SpecialItem[rankIdx]);
                    }
                }

                bool bVar1 = uVar2 <= randomNum;
                uVar2 = uVar2 + (ItemChance & -(Convert.ToByte(useableItems[itemIdx] == 1)));
                if (bVar1 && (randomNum < uVar2))
                {
                    if (petey_boo)
                    {
                        output = sSlotKindIndexArray[itemIdx];
                    }
                    else
                    {
                        output = sSlotKindIndexArray[specialIdx];
                    }

                    if (output != -1)
                    {
                        break;
                    }
                }

                itemIdx++;
                possibleItems--;
            } while (true);

            if (output == -1)
            {
                output = 3; // If nothing found, return banana
            }

            return output;
        }

        // this is very poorly reverse engineered but it works, used to obtain the offset of the itemslotlist file
        int calcBuffOffset(byte[] file, int itemModeOffset)
        {
            byte bVar1;
            byte bVar2;
            int iVar3;

            int i = 0;
            if (itemModeOffset > 0)
            {
                do
                {
                    bVar1 = file[0];
                    bVar2 = file[1];
                    file = file.Skip(2).ToArray();
                    iVar3 = bVar1 * bVar2;
                    i = iVar3 + i;
                    file = file.Skip(iVar3).ToArray();
                    i += 2;
                    itemModeOffset--;
                }
                while (itemModeOffset != 0);
            }
            return i;
        }
    }
}
