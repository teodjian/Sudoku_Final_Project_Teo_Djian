using System;
using System.Collections.Generic;
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
            return Convert.ToInt32(Console.ReadLine());
        }

        public void main_menu()
        {
            int option = 1;
            while (option != 0)
            {
                option = option_menu();
                switch (option)
                {
                    case 1:
                        Console.WriteLine("enter the file name of the sudoku");
                        string sudoku_file = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("enter the string sudoku");
                        string sudoku = Console.ReadLine();

                        break;
                    default:
                        Console.WriteLine("the number is not in the menu");
                        break;

                }
            }
        }


        private bool isValid(string sudoku, int length)
        {
            double size = Math.Pow(length, 0.5);
            if (Math.Pow(size, 0.5) % 1 != 0)
            {
                Console.WriteLine("youre number is no valid, Not suitable for sudoku sizes");
                throw new InputException(length);
                return false;
            }
            check_keys(sudoku, (int)size);
            int[,] matrix_board;

            return true;
        }
        public void check_keys(string str, int size)
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
        }
        /*private int[,] init_matrix(int[,] matrix_board, int size_board, string sudoku)
        {
            for (int i = 0; i < size_board; i++)
            {
                for (int j = 0; j < size_board; j++)
                {

                }
            }
        }
        */

    }

}
