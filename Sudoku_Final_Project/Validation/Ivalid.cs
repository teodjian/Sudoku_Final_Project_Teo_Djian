using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Validation_input
{
    interface Ivalid
    {
        void check_length(int length);
        void check_keys(string str, int size);
    }
}
