using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question1
    {
        public static int getAnswer(ushort[] prt)
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

            return max;
        }

        public static int Answer(int[] portfolios)
        {
            //TODO: Please work out the solution;
            return -1;
        }
    }
}
