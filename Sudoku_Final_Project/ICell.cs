using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    interface ICell
    {
            int _row { get; set; }
            int _col { get; set; }
            int _value { get; set; }

    }
}
