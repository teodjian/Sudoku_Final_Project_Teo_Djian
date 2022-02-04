using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Exepction
{
    class ImpossibleSolvingException : Exception
    {
        public ImpossibleSolvingException() : base(message())
        {
            Console.WriteLine(message());
        }
        public static string message()
        {
            return "Impossible to slove this Sudoku Board";
        }
    }
}
