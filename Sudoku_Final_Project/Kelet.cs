using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    class Kelet
    {
        private int option_menu()
        {
            Console.WriteLine("enter 1 for sudoku from a file");
            Console.WriteLine("enter 2 for sudoku from a string");
            Console.WriteLine("enter 3 to exit");
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception Ie)
            {
                Console.WriteLine($"Generic Exception Handler: it is not a number");
                Console.WriteLine(Ie.Message);
            }
            return 0;
        }

        public void main_menu()
        {
            Slover slover = new Slover();
            int option = 1;
            while (option != 0)
            {
                option = option_menu();
                switch (option)
                {
                    case 1:
                        Console.WriteLine("enter the file name of the sudoku");
                        string sudoku_file_name = Console.ReadLine();
                        string[] lines = File.ReadAllLines(sudoku_file_name);
                        int[,] board_from_file = isValidSudoku(lines[0], lines[0].Length);
                        slover.solveSudoku(board_from_file);
                        break;
                    case 2:
                        Console.WriteLine("enter the string sudoku");
                        string sudoku = Console.ReadLine();
                        int[,] board = isValidSudoku(sudoku,sudoku.Length);
                        slover.solveSudoku(board);
                        break;
                    case 3:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("the number is not in the menu");
                        break;

                }
            }
        }


        private int[,] isValidSudoku(string sudoku, int length)
        {
            
            double size_of_row = Math.Pow(length, 0.5);
            check_length(length);
            check_keys(sudoku, (int)size_of_row);
            Board_Game board = new Board_Game((int)size_of_row);
            int[,] matrix = new int[(int)size_of_row, (int)size_of_row]; 
            board.init_board(matrix,(int)size_of_row, sudoku);
            return matrix;
        }
        private bool check_length(int length)
        {

            double size = Math.Pow(length, 0.5);
            if (Math.Pow(size, 0.5) % 1 != 0)
            {
                Console.WriteLine("youre number is no valid, Not suitable for sudoku sizes");
                throw new InputException(length);
                //return false;
            }
            return true;
        }
        private bool check_keys(string str, int size)
        {
            int value;
            foreach (char chr in str)
            {
                value = chr - '0';
                if (value < 0 || value > size)
                {
                    throw new InputException(chr, size);
                }
            }
            return true;
        }

        
        

    }

}
