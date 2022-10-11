using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderKyoupro90
{
    class _004_CrossSum
    {
        public void Run()
        {
            string input = Console.ReadLine();
            int rows = int.Parse(input.Split(" ")[0]);
            int columns = int.Parse(input.Split(" ")[1]);

            int[][] A = new int[rows][];
            int[][] B = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                input = Console.ReadLine();
                A[i] = new int[columns];
                B[i] = new int[columns];

                for (int j = 0; j < columns; j++)
                {
                    A[i][j] = int.Parse(input.Split(" ")[j]);
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int k = 0; k < rows; k++)
                    {
                        B[i][j] += A[k][j];
                    }
                    for (int l = 0; l < columns; l++)
                    {
                        B[i][j] += A[i][l];
                    }
                    B[i][j] -= A[i][j];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                string output = string.Join(" ", B[i]);
                Console.WriteLine(output);
            }
            Console.ReadLine();
        }
    }
}
