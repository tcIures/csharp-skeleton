namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            int maxSum = 10000;


            bool[] res = new bool[maxSum + 1];
            bool[] ok = new bool[maxSum+1];

            res[0] = false;
            ok[0] = true;
           
            for (int i = 0; i < cashflowIn.Length; i++)
            {
                for (int ii = maxSum - cashflowIn[i]; ii >= 0; ii--)
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
                for (int ii = 0; ii <= maxSum; ii++)
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
            for (int i = 0; i <= maxSum; i++)
            {
                if (res[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}