using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKDD_RNG_Tool.Utils
{
    public class stRandom
    {
        static public double shiftRNGcnvtoFloat(uint SEED)
        {
            uint nextSeed2 = (SEED >> 9); // shift the seed 9 bits to the right
            nextSeed2 |= 0x3f800000; // OR with 0x3f800000 to essentially convert it to a floating point number
            byte[] bytes = BitConverter.GetBytes(nextSeed2);
            double myFloat = BitConverter.ToSingle(bytes, 0);
            myFloat = myFloat - 1.0;
            return myFloat;
        }

        static uint convert_fp2unsigned(double d)
        {
            uint uVar1 = 0;
            if ((0.0 <= d) && (d < 4.294967296E9))
            {
                uVar1 = 0xffffffff;
                if (2.147483648E9 <= d)
                {
                    d = d - 2.147483648E9;
                }
                uVar1 = (uint)d;
                if (2.147483648E9 <= d)
                {
                    uVar1 = uVar1 + 0x80000000;
                }
            }
            return uVar1;
        }

        static public uint AdvanceRNG(uint SEED)
        {
            return (SEED * 0x19660d) + 0x3c6ef35f;
        }

        static public uint getRandomMax(uint SEED, uint MAX)
        {
            SEED = AdvanceRNG(SEED);
            byte[] arr = new byte[8];
            arr[0] = 0x43;
            arr[1] = 0x30;
            arr[2] = 0x00;
            arr[3] = 0x00;

            byte[] maxARR = BitConverter.GetBytes(MAX + 1);
            maxARR = maxARR.Reverse().ToArray();
            for (int i = 0; i < 4; i++)
            {
                arr[4 + i] = maxARR[i];
            }
            arr = arr.Reverse().ToArray();
            double max = BitConverter.ToDouble(arr, 0) - 4.503599627370496E15;
            return convert_fp2unsigned(max * shiftRNGcnvtoFloat(SEED));
        }
    }
}
