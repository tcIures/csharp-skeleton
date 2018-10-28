using System;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {
        public static int Answer(int[] numOfShares, int totalValueOfShares)
        {
            int size = numOfShares.Length;

            int[] values = new int[totalValueOfShares + 1];

            values[0] = 0;

            int minValue = Int32.MaxValue;

            foreach (int num in numOfShares)
            {
                if (num < minValue)
                {
                    minValue = num;
                }
            }

            for (int i = 1; i <= totalValueOfShares; i++)
            {
                values[i] = int.MaxValue;
            }


            for (int i = minValue; i <= totalValueOfShares; i++)
            {
                for (int j = 0; j < size; j++)
                    if (numOfShares[j] <= i)
                    {
                        int sum = values[i - numOfShares[j]];
                        if (sum < int.MaxValue && sum + 1 < values[i])
                            values[i] = sum + 1;
                    }
            }
            if (values[totalValueOfShares] == int.MaxValue)
            {
                return 0;
            }
            return values[totalValueOfShares];
        }
    }
}


