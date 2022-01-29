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
                return Convert.ToInt32(Console.ReadKey().KeyChar)-'0';
            }
            catch (Exception Ie)
            {
                Console.WriteLine($"Generic Exception Handler: it is not a number");
                System.Environment.Exit(0);
            }
            return 0;
        }

        public void main_menu()
        {
            Slover slover = new Slover();
            string[] lines= { };
            int option = 1;
            while (option != 3)
            {
                option = option_menu();
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nenter the file path of the sudoku");
                        string sudoku_file_name = Console.ReadLine();
                        try {
                             lines = File.ReadAllLines(sudoku_file_name);
                            validation(lines[0]);
                        }
                        catch (InvalidInputException Ie)
                        {
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("file doesnt exist");
                            break;
                        }
                        int[,] board_from_file = init_Sudoku(lines[0], lines[0].Length);
                        slover.solveSudoku(board_from_file);
                        break;
                    case 2:
                        Console.WriteLine("\nenter the string sudoku");
                        string sudoku = Console.ReadLine();
                        try
                        { validation(sudoku); }
                        catch(Exception e)
                        { break;}
                        int[,] board = init_Sudoku(sudoku, sudoku.Length);
                        slover.solveSudoku(board);
                        break;
                    case 3:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nthe number is not in the menu");
                        break;

                }
            }
        }


        private int[,] init_Sudoku(string sudoku, int length)
        {
            double size_of_row = Math.Pow(length, 0.5);
            int[,] matrix = new int[(int)size_of_row, (int)size_of_row];
            Board_Game_UI board = new Board_Game_UI(sudoku.Length,matrix,(int)size_of_row);
            board.init_board(matrix,(int)size_of_row, sudoku);
            return matrix;
        }
        public void validation(string sudoku_string)
        {
                check_length(sudoku_string.Length);
                check_keys(sudoku_string, (int)Math.Pow(sudoku_string.Length, 0.5));
        }
        private void check_length(int length)
        {
            double size = Math.Pow(length, 0.5);
            if (Math.Pow(size, 0.5) % 1 != 0)
            {
                Console.WriteLine("youre number is no valid, Not suitable for sudoku sizes");
                throw new InvalidInputException(length);
            }
        }
        private void check_keys(string str, int size)
        {
            int value;
            foreach (char chr in str)
            {
                value = chr - '0';
                if (value < 0 || value > size)
                {
                    Console.WriteLine("in your input there is not only numbers");
                    throw new InvalidInputException(chr, size);
                }
            }
        }
    }

}
