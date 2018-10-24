namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            int n = cashflowIn.Length, m = cashflowOut.Length;
            int bigNumber = 100000;
            bool[] cando = new bool[bigNumber+4];
            bool[] ans = new bool[bigNumber+4];
            cando[0] = true;
            ans[0] = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = bigNumber - cashflowIn[i]; j >= 0; j--)
                {
                    if (cando[j])
                    {
                        cando[j + cashflowIn[i]] = true;
                        ans[j + cashflowIn[i]] = true;
                        //System.out.println(j+cashflowIn[i]+"\n");
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j <= bigNumber; j++)
                {
                    if (ans[j])
                    {
                        if (j > cashflowOut[i]) ans[j - cashflowOut[i]] = 1;
                        else ans[cashflowOut[i] - j] = true;
                        // System.out.println(j-cashflowOut[i]+"\n");
                    }
                }
            }
            for (int i = 0; i <= bigNumber; i++)
            {
                if (ans[i]) return i;
            }
            return -1;
        }
    }
}