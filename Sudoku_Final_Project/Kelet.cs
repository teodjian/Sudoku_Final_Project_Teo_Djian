using Sudoku_Final_Project.Exepction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    class Kelet
    {
        private int option_menu()
        {
            Console.WriteLine("enter 1 for sudoku from a file");
            Console.WriteLine("enter 2 for sudoku from a string");
            Console.WriteLine("enter 3 to exit");
            return Convert.ToInt32(Console.ReadKey().KeyChar)-'0';
        }

        public void main_menu()
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            Solver1 solver;
            Validation_Input validator = new Validation_Input();
            string[] lines= { };
            int option = 1;
            while (option != 3)
            {
                option = option_menu();
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nenter the file path of the sudoku");
                        string sudoku_file_name = Console.ReadLine();
                        try {
                             lines = File.ReadAllLines(sudoku_file_name);
                            validator.validation(lines[0]); // check that the string is valid for sudoku
                        }
                        catch (InvalidInputException)
                        {
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("file doesnt exist");
                            break;
                        }
                        Board_Game board_from_file = init_Sudoku(lines[0], lines[0].Length);
                        solver = new Solver1(board_from_file);
                        solver.solve();
                        break;
                    case 2:
                        Console.WriteLine("\nenter the string sudoku");
                        string sudoku = Console.ReadLine();
                        try
                        {
                          validator.validation(sudoku);
                          Board_Game board = init_Sudoku(sudoku, sudoku.Length);
                          solver = new Solver1(board);
                          solver.solve();
                        }
                        catch(Exception)
                        { break;}
                        
                        break;
                    case 3:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nthe key is not in the menu");
                        break;

                }
            }
        }
        private Board_Game init_Sudoku(string sudoku, int length)
        {
            double size_of_row = Math.Pow(length, 0.5);
            Board_Game board = new Board_Game_UI(sudoku,(int)size_of_row);
            return board;
        }        
    }

}
