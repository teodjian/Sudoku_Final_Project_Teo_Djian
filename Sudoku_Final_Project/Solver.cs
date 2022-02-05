using Sudoku_Final_Project.Exepction;
using Sudoku_Final_Project.Tactics;
using Sudoku_Final_Project.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    class Solver
    {
        private ICollection<Itactics> _Humantactics;
        private Board_Game _board;

        public Solver(Board_Game board)
        {
            _board = board;
            _Humantactics = new List<Itactics>(); // the list will have the most famous tactics that we use to solve sudoku board 
            _Humantactics.Add(new Intersections_Tactic(_board));// Intersections mean that If in a block all options of a certain number are confined to a row or column,
                                                                // that number cannot appear outside of that square in that row or col. or If in a row (or column)
                                                                // all options of a certain number are confined to one square, that option that be eliminated from all other cells in that square.
            _Humantactics.Add(new NakedSingle(_board)); //Naked Single means that in a specific cell only one option remains possible(the last remaining option
                                                        //has no other options to hide behind and is thus naked). The number must then go into that cell.
            _Humantactics.Add(new HiddenSingle(_board));// Hidden Single means that for a given number and square only one cell is left to place that digit.
                                                        // The cell itself has more than one option left, the correct number is thus hidden amongst the rest.
        }


        // call the solving algorithem and return the solution as string, if there is not solution will throw  Impossible Solving Exception
        public string SudokuSolution()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!SolveSudoku())
                throw new ImpossibleSolvingException();
            else
            {
                _board.displayboard(); // will display the board with the solution
                stopwatch.Stop();
                Console.WriteLine("Successful solving after: " + stopwatch.ElapsedMilliseconds + " milliseconds\n");
            }
            return _board.board_to_string();
        }

        // the function search the cell in the board with the least options and return by ref the row and col of this cell with the least of options.
        private int BestEmptyCell(ref int rowOfTheBestOption, ref int colOfTheBestOption)
        {
            int BestOption = -5; // init the variable with an illogical number
            Cell thisCell = null;
            for (int i = 0; i < _board._length_of_row; i++) // run on all the celles in the board
            {
                for (int j = 0; j < _board._length_of_row; j++)
                {
                    thisCell = _board._Cell_board[i, j]; 
                    if (!thisCell.HasValue()) // check that is cell is empty
                    {
                        if (BestOption == -5 || thisCell.NumOfOptions < BestOption)
                        {
                            BestOption = thisCell.NumOfOptions;
                            rowOfTheBestOption = i;
                            colOfTheBestOption = j;
                        }
                    }
                }
            }
            return BestOption;
        }

        // human tactics try to solve the board with fanous tactics and find the solution.
        private void HumanTactics()
        {
            List<bool> findPosiibleSlovedCell = new List<bool>();
            findPosiibleSlovedCell.Add(true);
            while (findPosiibleSlovedCell.Contains(true))
            {
                // while the tactics find celles that suitable with there meaning/ rules
                // the humans tactics will conitune to call if the board is stack, or sloved the loop will stop.
                findPosiibleSlovedCell = new List<bool>();
                foreach (Itactics tactic in _Humantactics)
                {
                    findPosiibleSlovedCell.Add(tactic.tryToSolve());
                }
            }
        }

        /* the main algorithem of the sudoku solver.
         * 1. if the board is 9x9 or smaller try to solve with BackTracking algorithem
         * 1.1 if return true, the board is solved
         * 2. try to solve the board with 3 human tactics, (NakedSingle, HiddenSingle and Intersections)
         * 3. if it stuck the algorithem will "guess" a number in the cell with the least of options if the bestOption is not to big
         * 3.11 do the number 2 again
         * 3.12 if the bestOption is too big try to find solution with backTracking
         * 3.121 find solution, return true else return false.
         * 3.2 if the board is solved return true
         * 3.3 try the next option (3)
         * 4. try number 3 again 
        */ 
        private bool SolveSudoku()
        {
            Board_Game ForBacktracking = (Board_Game)_board.Clone(); // because the BackTracking will may not find the solution
                                                                     // i dont want that that will change the main board 
            BackTracking backtracking = new BackTracking(ForBacktracking);
            
            if (_board._numberOfPlacesInSquare < 4 && backtracking.BacktrackingSolve(0, 0, 0,false))
            {
                // during the work on the sudoku i have seen that backtracking is faster for little boards. so for small and easy boars, 
                // the algorithem start by trying to solve the board with BackTracking, if it doesn't success the algorithem continue and try with the humans 
                // tactics that everyone use.
                _board = ForBacktracking;
                return true;
            }
            else
            {
                HumanTactics(); // try to solve the board with human tactics
                Validation_Of_Board validator = new Validation_Of_Board(_board);
                int thisRow = -1, thisCol = -1; // init the variable with an illogical number
                if (!validator.Validate(1)) // check that the board is valid, and Does not violate the rules of sudoku,
                                            // the one say that it is not the first board that is checked, to not throw  wrong exception
                    return false;
                if (_board.isBoardSloved()) // check if the board is sloved and there is not empty cells
                    return true;

                int bestOption=BestEmptyCell(ref thisRow, ref thisCol); // the sloving is stuck and the humans tactics can't do anything,
                                                                        // so the algorithem will search a empty cell with the less options and do a smart guess, and continue 
                                                                        // solving from there.
                if (bestOption > _board._length_of_row - 3) // if the bestOption is too big, the time complexity will be too big, so it is better to find solution with 
                                                            //Back tracking. if the best option for 9x9 board is 7 or more there is too much possibilities to check with human tactic
                {
                    if (backtracking.BacktrackingSolve(0, 0, 0,true))
                    {
                        _board = ForBacktracking;
                        return true;
                    }
                    else
                        return false;
                }
                if (thisRow == -1 || thisCol == -1) // there is no goods empty celles, so the algorithem can't continue, and board has not solution.
                    return false;
                Cell thisCell = _board._Cell_board[thisRow, thisCol];
                Board_Game clonedBoard = (Board_Game)_board.Clone(); // because not every guess is correct, we dont want to change the main board, so we copy him,
                                                                     // and do the changes on the cloned board
                foreach (int guess in thisCell.GetOptions())
                {
                    thisCell.Value = guess; // make a guess on the current board
                    _board.RemoveTheOption(guess, thisRow, thisCol); // update the options on the board according to the guess
                    if (SolveSudoku()) // for the recursive solution 
                        return true;
                    _board = (Board_Game)clonedBoard.Clone(); // the guess was correct so we can change the main board.  
                    thisCell = _board._Cell_board[thisRow, thisCol];
                }
            }
            return false; // can't solve this board
        }
    }
}
