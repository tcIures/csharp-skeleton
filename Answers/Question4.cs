using System;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            int min = Int32.MaxValue;
            bool ok = false;
            int increment = numOfConsecutiveMachines - 1;
            for (int i = 0; i < machineToBeFixed.GetLength(0); i++)
            {
                for (int ii = 0; ii < machineToBeFixed.GetLength(1) - increment; ii += increment)
                {
                    if (!machineToBeFixed[i, ii].Equals("X") && !machineToBeFixed[i, ii + increment].Equals("X"))
                    {
                        int seenSoFar = Convert.ToInt32(machineToBeFixed[i, ii]) + Convert.ToInt32(machineToBeFixed[i, ii + increment]);
                        bool ok1 = true;
                        for (int j = ii + 1; j < ii + increment; j++)
                        {
                            if (machineToBeFixed[i, j].Equals("X"))
                            {
                                ok1 = false;
                                break;
                            }

                            seenSoFar += Convert.ToInt32(machineToBeFixed[i, j]);
                        }
                        if (ok1)
                        {
                            ok = true;
                            if (seenSoFar < min)
                            {
                                min = seenSoFar;
                            }
                        }
                    }
                }
            }
            if (!ok)
            {
                return 0;
            }
            return min;
        }
    }
}