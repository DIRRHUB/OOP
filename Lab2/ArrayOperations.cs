using static System.Double;

namespace Lab2
{
    public class ArrayOperations
    {
        private Random random = new Random();

        public void PrintArray(double[] arr, int[] dimensionSizes)
        {
            string text = "";

            if (dimensionSizes.Length == 1)
            {
                text += arr[0];
                for (int i = 1; i < dimensionSizes[0]; i++)
                {
                    text += ", " + arr[i];
                }
            }
            else if (dimensionSizes.Length == 2)
            {
                for (int i = 0; i < dimensionSizes[0]; i++)
                {
                    text += arr[i * dimensionSizes[1]];
                    for (int j = 1; j < dimensionSizes[1]; j++)
                    {
                        text += "\t" + arr[i * dimensionSizes[1] + j];
                    }

                    text += "\n\n\n\n";
                }
            }
            else text = PrintArrayRecursion(arr, dimensionSizes, 0, arr.Length, 0);

            Console.WriteLine(text);
        }

        public void SetValue(double[] arr, int[] dimensionSizes, int[] fullIndex, double val)
        {
            try
            {
                arr[indexFromFullIndex(arr, dimensionSizes, fullIndex)] = val;
            }
            catch (IndexOutOfRangeException ignored)
            {
            }
        }

        public void FillArray(double[] arr, int[] dimensionSizes)
        {
            int lowLevelLen = dimensionSizes[dimensionSizes.Length - 1];
            double[] lowLevelArr = new double[lowLevelLen];

            for (int i = 0; i < arr.Length; i += lowLevelLen)
            {
                for (int j = 0; j < lowLevelLen; j++)
                {
                    lowLevelArr[j] = arr[i + j];
                }

                ChosenFillingFunction(lowLevelArr, i / lowLevelLen + 1);
                lowLevelArr.CopyTo(arr, i);
            }
        }

        public void ClearValue(double[] arr, int[] dimensionSizes, int[] fullIndex)
        {
            Array.Clear(arr, indexFromFullIndex(arr, dimensionSizes, fullIndex), 1);
        }

        private static double[][] getMatrixBasedFromArray(double[] arr)
        {
            int size = (int)Math.Sqrt(arr.Length);

            if (size * size != arr.Length)
            {
                Console.WriteLine("The array cannot be converted to a square matrix");
                return Array.Empty<double[]>();
            }

            double[][] matrix = new double[size][];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = new double[size];
                for (int j = 0; j < size; j++)
                {
                    matrix[i][j] = arr[i * size + j];
                }
            }

            return matrix;
        }

        public int[] FindIndex(double[] arr, int[] dimensionSizes, double val)
        {
            int[] output = new int[dimensionSizes.Length];
            int index = Array.IndexOf(arr, val);

            for (int i = output.Length - 1; i >= 0; i--)
            {
                output[i] = index % dimensionSizes[i];
                index /= dimensionSizes[i];
            }

            return output;
        }

        private void ChosenFillingFunction(double[] lowLevelArr, int input)
        {
            for (int i = 0; i < lowLevelArr.Length; i++)
            {
                lowLevelArr[i] = (double)Convert.ChangeType(random.Next(-10, 10) * input, typeof(double));
            }
        }

        private string PrintArrayRecursion(double[] arr, int[] dimensionSizes, int depth, int step, int index)
        {
            string output = "{";
            int lowLevelLen = dimensionSizes[dimensionSizes.Length - 1];

            if (depth == dimensionSizes.Length - 1)
            {
                output += arr[index];
                for (int i = 1; i < lowLevelLen; i++)
                {
                    output += ", " + arr[index + i];
                }
            }
            else
            {
                step /= dimensionSizes[depth];
                output += PrintArrayRecursion(arr, dimensionSizes, depth + 1, step, index);
                for (int i = 1; i < dimensionSizes[depth]; i++)
                {
                    output += ", " + PrintArrayRecursion(arr, dimensionSizes, depth + 1, step, index + step * i);
                }
            }

            return output + "}";
        }


        private int indexFromFullIndex(double[] arr, int[] dimensionSizes, int[] fullIndex)
        {
            int index = 0, step = arr.Length;

            for (int i = 0; i < fullIndex.Length; i++)
            {
                step /= dimensionSizes[i];
                index += fullIndex[i] * step;
            }

            return index;
        }

        //1.1
        public void CalculateAverage(double[] arr)
        {
            if (arr.Rank != 1)
            {
                Console.WriteLine("Array should be 1 rank");
                return;
            }

            Console.WriteLine(arr.Rank);
            double sum = 0;
            foreach (var t in arr)
            {
                sum += t;
            }

            double average = sum / arr.Length;
            Console.WriteLine($"Average: {average}");
        }

        // 1.2
        public void CalculateSumVectors()
        {
            Console.Write("Enter vector dimension: ");
            int n = int.Parse(Console.ReadLine());

            double[] x = new double[n];
            double[] y = new double[n];
            double[] sum = new double[n];

            Console.WriteLine("Vector x:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter {i + 1}-coordinate: ");
                x[i] = Parse(Console.ReadLine());
            }

            Console.WriteLine("Vector y:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter {i + 1}-coordinate: ");
                y[i] = Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                sum[i] = x[i] + y[i];
            }

            Console.WriteLine("Sum of vectors:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(sum[i] + " ");
            }
        }


        //1.3
        public void BubbleSort(double[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    double temp = arr[j];
                    if (arr[j] > arr[j + 1])
                    {
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        //2.1
        public void SortEvenRows(double[] arr)
        {
            int size = (int)Math.Sqrt(arr.Length);
            double[][] matrix = getMatrixBasedFromArray(arr);
            if(matrix.Length==0) return;
            for (int i = 1; i < size; i += 2)
            {
                Array.Sort(matrix[i]);
            }

            int index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    arr[index] = matrix[i][j];
                    index++;
                }
            }
        }

        //2.2
        public int CalculateNotZero(double[] arr)
        {
            double[][] matrix = getMatrixBasedFromArray(arr);
            if(matrix.Length==0) return 0;
            int count = 0;
            foreach (var t in matrix)
            {
                bool hasZero = false;
                foreach (var j in t)
                {
                    if (j == 0)
                    {
                        hasZero = true;
                    }
                }

                if (!hasZero)
                {
                    count++;
                }
            }

            return count;
        }

        //2.3
        public double FindMaxRecurringNumber(double[] arr)
        {
            double[][] matrix = getMatrixBasedFromArray(arr);
            if(matrix.Length==0) return 0;
            int size = matrix.Length;
            double max = MinValue;
            Dictionary<double, int> freq = new Dictionary<double, int>();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    double current = matrix[i][j];

                    if (freq.ContainsKey(current))
                    {
                        freq[current]++;
                        if (freq[current] > 1 && current > max)
                        {
                            max = current;
                        }
                    }
                    else
                    {
                        freq[current] = 1;
                    }
                }
            }

            if (max == MinValue)
            {
                Console.WriteLine("There is no recurring number in the matrix");
            }

            return max;
        }
    }
}
