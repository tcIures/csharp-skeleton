namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            int n = cashflowIn.Length, m = cashflowOut.Length;
            int[] cando = new int[10004];
            int[] ans = new int[10004];
            cando[0] = 1;
            ans[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                cando[i] = 0;
                ans[i] = 0;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 10000 - cashflowIn[i]; j >= 0; j--)
                {
                    if (cando[j] == 1)
                    {
                        cando[j + cashflowIn[i]] = 1;
                        ans[j + cashflowIn[i]] = 1;
                        //System.out.println(j+cashflowIn[i]+"\n");
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j <= 10000; j++)
                {
                    if (ans[j] == 1)
                    {
                        if (j > cashflowOut[i]) ans[j - cashflowOut[i]] = 1;
                        else ans[cashflowOut[i] - j] = 1;
                        // System.out.println(j-cashflowOut[i]+"\n");
                    }
                }
            }
            for (int i = 0; i <= 10000; i++)
            {
                if (ans[i] == 1) return i;
            }
            return -1;
        }
    }
}