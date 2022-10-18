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

            int[][] Input = new int[rows][];
            int[][] Result = new int[rows][];

            // 各行の値を読み込み
            for (int i = 0; i < rows; i++)
            {
                input = Console.ReadLine();
                Input[i] = new int[columns];
                Result[i] = new int[columns];

                // 各列の値を読み込み
                for (int j = 0; j < columns; j++)
                {
                    Input[i][j] = int.Parse(input.Split(" ")[j]);
                }
            }

            // 遅い！
            //// 全てのマスについて、1行分の合計+1列分の合計-自分自身、を実行
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < columns; j++)
            //    {
            //        // 1行分の合計を加算
            //        for (int k = 0; k < rows; k++)
            //        {
            //            Sum[i][j] += A[k][j];
            //        }
            //        // 1列分の合計を加算
            //        for (int l = 0; l < columns; l++)
            //        {
            //            Sum[i][j] += A[i][l];
            //        }
            //        // 自分自身は2回計算しているので減算
            //        Sum[i][j] -= A[i][j];
            //    }
            //}

            // まず各行、各列の合計を先に計算しておく
            int[] SumRows = new int[rows];
            int[] SumColmns = new int[columns];

            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < columns; col++)
                {
                    SumRows[row] += Input[row][col];
                }
            }
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    SumColmns[col] += Input[row][col];
                }
            }

            // 次に全てのマスについて、1行分の合計+1列分の合計-自分自身、を実行
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    // 1行分の合計を加算
                    Result[row][col] += SumRows[row];
                    // 1列分の合計を加算
                    Result[row][col] += SumColmns[col];
                    // 自分自身は2回計算しているので減算
                    Result[row][col] -= Input[row][col];
                }
            }

            // 出力
            for (int i = 0; i < rows; i++)
            {
                string output = string.Join(" ", Result[i]);
                Console.WriteLine(output);
            }
            Console.ReadLine();
        }
    }
}
