using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Exepction
{
    public class InvalidBoardInputException : Exception
    {

        public InvalidBoardInputException() : base(message())
        {
            // custom Exception that used if found the same number twice in an element (row, column, square)
            Console.WriteLine(message());
        }
        public InvalidBoardInputException(string s) : base(message(s))
        {
            // custom Exception that used if the string is null
            Console.WriteLine(message(s));
        }
        public static string message()
        {
            return "Invalid Input Exception: found the same number twice in an element (row, column, box)";
        }
        public static string message(string s)
        {
            return "Invalid Input Exception: the string is null";
        }

    }
}
