namespace Lab2
{
    class Progam
    {
        private static int InputIntMinMax(string text, int min, int max)
        {
            while (true)
            {
                Console.WriteLine("\n" + text);
                var input = Console.ReadLine();
                int output;
                if (!Int32.TryParse(input, out output))
                {
                    Console.WriteLine("Entered number is not an int");
                }
                else
                {
                    return output;
                }
            }
        }

        public static int InputIntMin(string text, int min)
        {
            return InputIntMinMax(text, min, Int32.MaxValue);
        }

        public static int InputIntMax(string text, int max)
        {
            return InputIntMinMax(text, Int32.MinValue, max);
        }

        public static int InputInt(string text)
        {
            return InputIntMinMax(text, Int32.MinValue, Int32.MaxValue);
        }

        public static void Main()
        {
            int[] dimensionSizes;
            int menu = 1, dimensionNumber, arrSize = 1;
            double[] arr;

            dimensionNumber = InputIntMin("Enter the desired number of dimensions:", 1);
            dimensionSizes = new int[dimensionNumber];
            for (int i = 0; i < dimensionNumber; i++)
            {
                dimensionSizes[i] = InputIntMin("Enter the " + (i + 1) + " dimension:", 1);
                arrSize *= dimensionSizes[i];
            }

            arr = new double[arrSize];
            ArrayOperations operations = new();

            while (menu != 0)
            {
                menu = InputIntMinMax(
                    "Enter:\n1 - Print the array\n2 - Find a value\n3 - Set a value\n4 - Clear a value\n5 - 1.3 Sort by growth\n6 - Fill the array,\n7 - 1.1 Calculate average" +
                    "\n8 - 1.2 Calculate sum of vectors\n9 - Sort even rows\n10 - Calculate not zero rows\n11 - Find max recurring number\n0 - Exit",
                    0, 11);
                switch (menu)
                {
                    case 1:
                        operations.PrintArray(arr, dimensionSizes);
                        break;
                    case 2:
                        int[] indexF = operations.FindIndex(arr, dimensionSizes, InputInt("Enter value:"));
                        Console.Write("[" + indexF[0]);
                        for (int i = 1; i < dimensionNumber; i++)
                        {
                            Console.Write("," + indexF[i]);
                        }

                        Console.WriteLine("]");
                        break;
                    case 3:
                        int[] indexS = new int[dimensionNumber];
                        for (int i = 0; i < dimensionNumber; i++)
                        {
                            indexS[i] = InputIntMinMax("Enter the index in " + (i + 1) + " dimension:", 0,
                                dimensionSizes[i] - 1);
                        }

                        operations.SetValue(arr, dimensionSizes, indexS, InputInt("Enter value:"));
                        break;
                    case 4:
                        int[] indexC = new int[dimensionNumber];
                        for (int i = 0; i < dimensionNumber; i++)
                        {
                            indexC[i] = InputIntMinMax("Enter the index in " + (i + 1) + " dimension:", 0,
                                dimensionSizes[i] - 1);
                        }

                        operations.ClearValue(arr, dimensionSizes, indexC);
                        break;
                    case 5:
                        operations.BubbleSort(arr);
                        break;
                    case 6:
                        operations.FillArray(arr, dimensionSizes);
                        break;
                    case 7:
                        operations.CalculateAverage(arr);
                        break;
                    case 8:
                        operations.CalculateSumVectors();
                        break;
                    case 9:
                        operations.SortEvenRows(arr);
                        break;
                    case 10:
                        Console.WriteLine("Not zero rows " + operations.CalculateNotZero(arr));
                        break;
                    case 11:
                        Console.WriteLine("Max reccuring number " + operations.FindMaxRecurringNumber(arr));
                        break;
                    case 0:
                        return;
                }
            }
        }
    }
}