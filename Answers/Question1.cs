using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question1
    {
        public static int Answer(int[] portfolios)
        {
            ushort max = UInt16.MinValue;

            for (int i = 0; i < prt.Length; i++)
            {
                for (int ii = i + 1; ii < prt.Length; ii++)
                {
                    ushort result = (ushort)(prt[i] ^ prt[ii]);
                    if (result > max)
                    {
                        max = result;
                    }
                }
            }

            return (int)max;
        }
    }
}
