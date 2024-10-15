using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace sipiral_matris
{
    class Program
    {
        static void Main(string[] args)

        {
            #region
            int N = 4;
            int[,] matrix = new int[N, N];
            FillSpiralMatrix(matrix, N);
            PrintMatrix(matrix, N);
        }

        static void FillSpiralMatrix(int[,] matrix, int N)
        {
            int value = 1;
            int top = 0, bottom = N - 1, left = 0, right = N - 1;

            while (value <= N * N)
            {
                // Top row(left to right)
                for (int i = left; i <= right; i++)
                {
                    matrix[top, i] = value++;
                }
                    top++;


                // Right column (top to bottom)
                for (int i = top; i <= bottom; i++)
                {
                    matrix[i, right] = value++;
                }
                    right--;


                // Bottom row (right to left)
                for (int i = right; i >= left; i--)
                {
                    matrix[bottom, i] = value++;
                }
                    bottom--;


                // Left column (bottom to top)
                for (int i = bottom; i >= top; i--)
                {
                    matrix[i, left] = value++;
                }
                    left++;
                
            }
        }

        static void PrintMatrix(int[,] matrix, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(3) + " ");
                }
                Console.WriteLine();
            }
                Console.ReadKey();
                #endregion
            
        }
    }
}

