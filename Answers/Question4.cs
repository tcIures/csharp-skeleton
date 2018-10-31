using System;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            int n = machineToBeFixed.GetLength(0);
            int m = machineToBeFixed.GetLength(1);

            int[] t_arr = new int[m];

            int min = Int32.MaxValue;
            int t = 0;
            int nt = 0;

            for (int i = 0; i < n; i++)
            {
                t = 0;
                nt = 0;
           
                for (int j = 0; j < m; j++)
                {


                    if (machineToBeFixed[i, j][0] == 'X')
                    {
                        t = 0;
                        nt = 0;
                    }
                    else
                    {
                        int t_aux = Int32.Parse(machineToBeFixed[i, j]);
                        nt++;
                        t_arr[j] = t_aux;
                        t += t_aux;
                        if (nt == numOfConsecutiveMachines)
                        {
                            if (t < min)
                            {
                                min = t;

                            }
                            t -= t_arr[j - numOfConsecutiveMachines + 1];
                            nt--;
                        }
                    }
                }
            }
            if (min == Int32.MaxValue)
            {
                return 0;
            }
            else
            {
                return min;
            }
        }
    }
}