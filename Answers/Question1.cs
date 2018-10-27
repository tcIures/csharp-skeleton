using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question1
    {
        public static int Answer(int[] portofolios)
        {
            int max = UInt16.MinValue;

            for (int i = 0; i < portofolios.Length-1; i++)
            {
                for (int ii = i + 1; ii < portofolios.Length; ii++)
                {
                    int result =(portofolios[i] ^ portofolios[ii]);
                    if (result > max)
                    {
                        max = result;
                        if (max == 0xFF)
                        {
                            return max;
                        }
                    }
                }
            }

            return max;
        }
    }
}
