using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFieldCSharp
{
    internal class TicTacToe
    {
        public int[,] arr { get; set; }

        public TicTacToe()
        {
            arr = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = 0;
                }
            }
        }

        public void GameLoop()
        {
            bool turn = true;
            int x, y;

            while (!WinCheck(0, 0))
            {
                Graphics();

                Console.WriteLine($"Player {(turn ? "X" : "O")}'s turn:");

                do
                {
                    Console.WriteLine("Row:");
                    x = Console.ReadKey().KeyChar - 49;
                    Console.WriteLine();
                    Console.WriteLine("Column:");
                    y = Console.ReadKey().KeyChar - 49;
                    Console.WriteLine();
                } while ((arr[x, y] != 0) || (((x < 0 || x > 2)) || ((y < 0 || y > 2))));

                arr[x, y] = turn ? 1 : -1;
                turn = !turn;
            }
        }

        private void Graphics()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"[{(arr[i, j] == 0 ? " " : (arr[i, j] == 1 ? "X" : "O"))}]");
                }
                Console.WriteLine();
            }
        }

        public bool WinCheck(int x, int y)
        {
            // 0,0 0,1 0,2
            // 1,0 1,1 1,2
            // 2,0 2,1 2,2

            if (x + y % 2 != 0)
            {

            }

                return false;
        }
    }
}
