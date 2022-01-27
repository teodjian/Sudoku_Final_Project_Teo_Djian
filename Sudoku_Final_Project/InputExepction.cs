using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    class InputException : Exception
    {
        public InputException() : base(modifymessage())
        {

        }
        public InputException(int length) : base(modifymessage(length))
        {

        }
        public InputException(Exception e) : base(message_menu())
        {

        }
        public InputException(char chr, int length) : base(modifymessage(chr, length))
        {

        }
        public static string modifymessage()
        {
            return "Invalid Input Exception: found the same number twice in an element (row, column, box)";
        }
        public static string message_menu()
        {
            return "Invalid Input Exception: it is not a number from 1 to 3";
        }
        public static string modifymessage(int length)
        {
            return "Invalid Input Exception: " + length.ToString() + " is not a valid length.";
        }
        public static string modifymessage(char chr, int length)
        {
            return "Invalid Input Exception: " + chr + " is not a valid key for length " + length.ToString();
        }

    }
}
