using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Exepction
{
    class InvalidKeyException : Exception
    {
        public InvalidKeyException(char chr, int length) : base(message(chr, length))
        {
            Console.WriteLine(message(chr, length));


        }
        public static string message(char chr, int length)
        {
            return "Invalid Input Exception: " + chr + " is not a valid key for length " + length.ToString();
        }
    }
}
