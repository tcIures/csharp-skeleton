namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {
        public static int Answer(int[] numOfShares, int totalValueOfShares)
        {
            int size = numOfShares.Length;

            int[] matrix = new int[totalValueOfShares + 1];

            matrix[0] = 0;

            for (int i = 1; i <= totalValueOfShares; i++)
                matrix[i] = int.MaxValue;

            for (int i = 1; i <= totalValueOfShares; i++)
            {
                for (int j = 0; j < size; j++)
                    if (numOfShares[j] <= i)
                    {
                        int sum = matrix[i - numOfShares[j]];
                        if (sum < int.MaxValue && sum + 1 < matrix[i])
                            matrix[i] = sum + 1;
                    }
            }
            return matrix[totalValueOfShares];
        }
    }
}