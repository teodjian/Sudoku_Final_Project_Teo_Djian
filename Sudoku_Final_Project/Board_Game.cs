using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    class Board_Game
    {

        private int _size { get; set; }
        public Board_Game(int size)
        {

            _size = size;
        }
        //sets the color of the text to white or green, used in displaying the board.
        private void color(bool flag)
        {
            if (flag)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.White;
        }
        public void displayboard(int[,] board)
        {
            int placeInCell = (int)Math.Pow(_size, 0.5);

            for (int i = 0; i < 3 * _size; i++)
            {

                for (int j = 0; j < 6 * _size; j++)
                {
                    color(false);
                    if (i % (placeInCell * 3) == 0 && (j % (placeInCell * 6) == 0 || j % 6 != 0))
                        color(true);
                    if (j % (placeInCell * 6) == 0)
                        color(true);
                    if (i == 0)
                    {
                        color(true);
                        if (j == 6 * _size - 1)
                        {
                            color(true);
                            Console.WriteLine("_");
                        }
                        else
                            Console.Write("_");
                    }
                    else if (j == 6 * _size - 1)
                    {

                        if (i % 3 == 0)
                        {
                            Console.Write("_");
                            color(true);
                            Console.WriteLine("|");
                        }
                        else
                        {
                            color(true);
                            Console.WriteLine(" |");
                        }
                    }
                    else if (i % 3 == 0)
                    {
                        if (j % 6 == 0)
                            Console.Write("|");
                        else
                            Console.Write("_");
                    }
                    else if (i % 3 == 1)
                    {
                        if (j % 6 == 0)
                            Console.Write("|");
                        else
                            Console.Write(" ");
                    }
                    else if (i % 3 == 2)
                    {
                        if (j % 6 == 0)
                            Console.Write("|");
                        else if (j % 6 == 3 || j % 6 == 4)

                        {
                            if (j % 6 == 3)
                            {
                                if (board[i / 3, j / 6] != null)
                                {
                                    if (board[i / 3, j / 6] >= 10)
                                        Console.Write(board[i / 3, j / 6]);
                                    else
                                        Console.Write(board[i / 3, j / 6] + " ");
                                }
                                else
                                    Console.Write("  ");
                            }
                        }
                        else
                            Console.Write(" ");
                    }

                }
            }
            for (int j = 0; j < _size * 6; j++)
            {
                color(false);
                if (j % 6 == 0)
                {
                    if (j % (6 * placeInCell) == 0)
                        color(true);
                    Console.Write("|");
                }
                else
                {
                    color(true);
                    Console.Write("_");
                }
            }
            Console.WriteLine("|\n\n");
            color(false);
        }
    }
}


