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
        // function that propose to the user the options of the code, and return the number of the key that the user put.
        private int option_menu()
        {
            Console.WriteLine("Enter 1 for sudoku from a file");
            Console.WriteLine("Enter 2 for sudoku from a string");
            Console.WriteLine("Enter 3 to exit");
            return Convert.ToInt32(Console.ReadKey().KeyChar)-'0';
        }


        // main menu is the function that continue to work  until the user want to stop, send to the functions the inputs of the user for solve the boards
        public void main_menu()
        {
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
                            lines = File.ReadAllLines(sudoku_file_name); // gets into lines all the lines of the file and take only the first
                            string SloverString = sudokuManager(lines[0]); // call the function that will call the solving and validation functions
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
                          string solution=sudokuManager(sudoku); //call the function that will call the solving and validation functions
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

        // create board with the string input and, length of row, and return board.  
        private Board_Game init_Sudoku(string sudoku, int length)
        {
            double size_of_row = Math.Pow(length, 0.5);
            Board_Game board = new Board_Game_UI(sudoku,(int)size_of_row);
            return board;
        }        

        // this function get the board as string and return the solution of the board as string.
        private string sudokuManager(string sudoku)
        {
            Solver solver;
            Validation_Input validator = new Validation_Input();
            validator.validation(sudoku); //check that the boars string given is valid for sudoku
            Board_Game board = init_Sudoku(sudoku, sudoku.Length); // init the board
            solver = new Solver(board);
            return solver.SudokuSolution(); // return the result of the board as string
        }
        // if the user gave sudoku board from a file this function will create new file with the solution if is not already exist
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
            else
                Console.WriteLine("this path file: " + fileSolutionName + " is alreay exist\n");
        }
    }

}
