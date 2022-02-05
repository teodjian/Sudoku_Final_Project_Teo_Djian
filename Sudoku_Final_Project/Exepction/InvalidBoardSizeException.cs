using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Exepction
{
    public class InvalidBoardSizeException : Exception
    {
        // custom Exception that used if the length of the board is not suitable for sudoku sizes
        public InvalidBoardSizeException(int length) : base(message(length))
        {
            Console.WriteLine(message(length));
        }
        public static string message(int length)
        {
            return "Invalid Input Exception: " + length.ToString() + " is not a valid length.";
        }
    }

   
}
