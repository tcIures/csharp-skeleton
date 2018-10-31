using System;


namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public static int getAns(int[] cashflowIn, int[] cashflowOut)
        {
            int maxDiff = 3000;

            bool[] res = new bool[maxDiff + 1];
            bool[] ok = new bool[maxDiff + 1];

            res[0] = false;
            ok[0] = true;

            for (int i = 0; i < cashflowIn.Length; i++)
            {
                for (int ii = maxDiff - cashflowIn[i]; ii >= 0; ii--)
                {
                    if (ok[ii])
                    {
                        ok[ii + cashflowIn[i]] = true;
                        res[ii + cashflowIn[i]] = true;
                    }
                }
            }
            for (int i = 0; i < cashflowOut.Length; i++)
            {
                for (int ii = 0; ii <= maxDiff; ii++)
                {
                    if (res[ii])
                    {
                        if (ii > cashflowOut[i])
                        {
                            res[ii - cashflowOut[i]] = true;
                        }
                        else
                        {
                            res[cashflowOut[i] - ii] = true;
                        }
                    }
                }
            }
            for (int i = 0; i <= maxDiff; i++)
            {
                if (res[i])
                {
                    return i;
                }
            }
            return -1;
        }


        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            return Math.Max(getAns(cashflowIn, cashflowOut), getAns(cashflowOut, cashflowIn));
        }
    }
}