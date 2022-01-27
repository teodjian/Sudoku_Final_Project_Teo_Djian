using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
        class Slover
        {
            public void solveSudoku(int[,] board)
            {
                Boolean sloved = solve(board);
                if (!sloved)
                    Console.WriteLine("the board is not correct");

            }
            private static bool solve(int[,] board)
            {
               Board_Game class1 = new Board_Game(board.GetLength(0));
               //class1.displayboard(board);
               for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == '.' || board[i, j] == '0' || board[i, j] == 0)
                        {
                            //char x= (char)(board.GetLength(0) + '0');
                            for (char c = '1'; c <= (char)board.GetLength(0) + '0'; c++)
                            {
                                if (isValid(board, i, j, c))
                                {
                                    if (c > board.GetLength(0))
                                        board[i, j] = c - '0';
                                    else
                                        board[i, j] = c;
                                    if (solve(board))
                                    {
                                        return true;
                                    }
                                    else
                                        board[i, j] = '.';
                                }
                            }

                            return false;
                        }
                    }
                }
               
                class1.displayboard(board);
                return true;
            }
            private static bool isValid(int[,] board, int row, int col, char c)
            {
                int block = (int)Math.Pow(board.GetLength(0), 0.5);
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    //check row  
                    if ((board[i, col] != '.' || board[i, col] != 0) && (board[i, col] == c || board[row, i] + '0' == c))
                        return false;
                    //check column  
                    if ((board[i, col] != '.' || board[i, col] != 0) && (board[row, i] == c || board[row, i] + '0' == c))
                        return false;
                    //check block  
                    int num = board[block * (row / block) + i / block, block * (col / block) + i % block];
                    if ((num != '.' || num != 0) && (num == c || num + '0' == c))
                        return false;
                }
                return true;
            }
        }
    }



