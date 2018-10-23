namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            /*int min = Int32.MaxValue;
            bool ok = false;
            for (int i = 0; i < machineToBeFixed.GetLength(0); i++)
            {
                ushort seenSoFar = 0;
                for (int ii = 0; ii < machineToBeFixed.GetLength(1); ii++)
                {
                    if (machineToBeFixed[i, ii].Equals("X"))
                    {
                        seenSoFar = 0;
                    }
                    else
                    {
                        if (seenSoFar == numOfConsecutiveMachines - 1)
                        {
                            ok = true;

                            int time = 0;
                            for (int k = 0; k < numOfConsecutiveMachines; k++)
                            {
                                time += Convert.ToInt32(machineToBeFixed[i, ii - k]);
                            }
                            if (time < min)
                            {
                                min = time;
                            }
                        }
                        else
                        {

                            seenSoFar += 1;
                        }
                    }
                }
            }
            if (!ok)
            {
                return 0;
            }
            return min;*/
        }
    }
}