using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Exepction
{
    public class ImpossibleSolvingException : Exception
    {
        // custom Exception that used if the solving algorithem can't find a solution.
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
