using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    class Board_Game_UI : Board_Game
    {

        public Board_Game_UI(string str,int length_of_row) :base(str,length_of_row)
        {
        }
        public Board_Game_UI()
        {

        }
        //sets the color of the text to white or green, used in displaying the board.
        private void color(bool flag)
        {
            if (flag)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.White;
        }

        // algorithm that print the board.
        public override void displayboard()
        {
            for (int i = 0; i < 3 * _length_of_row; i++)
            {

                for (int j = 0; j < 6 * _length_of_row; j++)
                {
                    color(false);
                    if (i % (_numberOfPlacesInSquare * 3) == 0 && (j % (_numberOfPlacesInSquare * 6) == 0 || j % 6 != 0))
                        color(true);
                    if (j % (_numberOfPlacesInSquare * 6) == 0)
                        color(true);
                    if (i == 0)
                    {
                        color(true);
                        if (j == 6 * _length_of_row - 1)
                        {
                            color(true);
                            Console.WriteLine("_");
                        }
                        else
                            Console.Write("_");
                    }
                    else if (j == 6 * _length_of_row - 1)
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
                                if (_Cell_board[i / 3, j / 6].Value!=0)
                                {
                                    if (_Cell_board[i / 3, j / 6].Value >= 10)
                                        Console.Write(_Cell_board[i / 3, j / 6].Value);
                                    else
                                        Console.Write(_Cell_board[i / 3, j / 6].Value + " ");
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
            for (int j = 0; j < _length_of_row * 6; j++)
            {
                color(false);
                if (j % 6 == 0)
                {
                    if (j % (6 * _numberOfPlacesInSquare) == 0)
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


