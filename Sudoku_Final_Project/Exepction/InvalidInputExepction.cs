using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Exepction
{
    class InvalidInputException : Exception
    {
        public InvalidInputException() : base(message())
        {
            Console.WriteLine(message());
        }
        public InvalidInputException(string s) : base(message(s))
        {
            Console.WriteLine(message(s));
        }
        public static string message()
        {
            return "Invalid Input Exception: found the same number twice in an element (row, column, box)";
        }
        public static string message(string s)
        {
            return "Invalid Input Exception: the string is null"+ s;
        }

    }
}
