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
            Console.WriteLine("Enter 1 for sudoku from a file");
            Console.WriteLine("Enter 2 for sudoku from a string");
            Console.WriteLine("Enter 3 to exit");
            return Convert.ToInt32(Console.ReadKey().KeyChar)-'0';
        }

        public void main_menu()
        {
            Solver solver;
            Validation_Input validator = new Validation_Input();
            string[] lines= { };
            int option = 1;
            while (option != 3)
            {
                option = option_menu();
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nEnter the file path of the sudoku");
                        string sudoku_file_name = Console.ReadLine();
                        try {
                            lines = File.ReadAllLines(sudoku_file_name);
                            validator.validation(lines[0]); // check that the string is valid for sudoku
                            Board_Game board_from_file = init_Sudoku(lines[0], lines[0].Length);
                            solver = new Solver(board_from_file);
                            string SloverString = solver.SudokuSolution();
                            Console.WriteLine("the string of the result: " + SloverString);
                            fileSolution(sudoku_file_name, SloverString);
                        }
                        catch(FileNotFoundException)
                        {
                            Console.WriteLine("Invalid File Path: Can't find the File");
                            break;
                        }
                        catch (Exception)
                        {
                            break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nEnter the string sudoku");
                        string sudoku = Console.ReadLine();
                        try
                        {
                          validator.validation(sudoku);
                          Board_Game board = init_Sudoku(sudoku, sudoku.Length);
                          solver = new Solver(board);
                          string solution=solver.SudokuSolution();
                          Console.WriteLine("the string of the result: " + solution);
                        }
                        catch(Exception)
                        { break;}
                        break;
                    case 3:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nThe key is not in the menu");
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

        private void fileSolution(string sudokuBoard_file_name, string SolutionBoard)
        {
            string fileSolutionName = sudokuBoard_file_name.Replace(".txt", "-Solution.txt");
            if (!File.Exists(fileSolutionName))
            {
                using (StreamWriter sw = File.CreateText(fileSolutionName))
                {
                    sw.WriteLine(SolutionBoard);
                    Console.WriteLine("The path of the solution file is " + fileSolutionName+"\n");
                }
            }
        }
    }

}
