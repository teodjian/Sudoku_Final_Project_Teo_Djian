using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
        class Program
        {
            static void Main(string[] args)
            {
                Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
                Kelet kelet = new Kelet();
                kelet.main_menu();
            }


        }
    }

