using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    class InvalidInputException : Exception
    {
        public InvalidInputException() : base(message())
        {
            Console.WriteLine(message());
        }
        public InvalidInputException(char chr, int length) : base(message(chr, length))
        {
            Console.WriteLine(message(chr, length));
            

        }
        public InvalidInputException(int length) : base(message(length))
        {
        }
        public InvalidInputException(Exception e) : base(message_menu())
        {
            
        }
        public static string message()
        {
            return "Invalid Input Exception: found the same number twice in an element (row, column, box)";
        }
        public static string message_menu()
        {
            return "Invalid Input Exception: it is not a number from 1 to 3";
        }
        public static string message(int length)
        {
            return "Invalid Input Exception: " + length.ToString() + " is not a valid length.";
        }
        public static string message(char chr, int length)
        {
            return "Invalid Input Exception: " + chr + " is not a valid key for length " + length.ToString();
        }

    }
}
