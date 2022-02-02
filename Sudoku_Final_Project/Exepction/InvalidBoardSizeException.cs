using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Exepction
{
    class InvalidBoardSizeException : Exception
    {
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
