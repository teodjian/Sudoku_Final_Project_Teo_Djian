using Sudoku_Final_Project.Exepction;
using Sudoku_Final_Project.Validation_input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    class Validation_Input: Ivalid
    {
        public void validation(string sudoku_string)
        {
            if (sudoku_string.Equals("") || sudoku_string.Equals(" "))
                throw new InvalidBoardInputException(sudoku_string);
            check_length(sudoku_string.Length);
            check_keys(sudoku_string, (int)Math.Pow(sudoku_string.Length, 0.5));
        }
        // function that check if the length of the input is suitable for sudoku sizes, if not throw Exception.
        public void check_length(int length)
        {
            double size = Math.Pow(length, 0.5);
            if (Math.Pow(size, 0.5) % 1 != 0)
            {
                Console.WriteLine("youre number is no valid, Not suitable for sudoku sizes");
                throw new InvalidBoardSizeException(length);
            }
        }
        // function that chack if all the keys in the string are numbers, if not throw Exception.  
        public void check_keys(string str, int size)
        {
            int value;
            foreach (char chr in str)
            {
                value = chr - '0';
                if (value < 0 || value > size)
                {
                    Console.WriteLine("in your input there is not only numbers");
                    throw new InvalidKeyException(chr, size);
                }
            }
        }

    }
}
