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
            this._board = board;
            _Humantactics = new List<Itactics>();
            _Humantactics.Add(new NakedSingle(_board));
            _Humantactics.Add(new HiddenSingle(_board));
            _Humantactics.Add(new Intersections_Tactic(_board));
        }

        private void BestEmptyCell(ref int rowOfTheBestOption, ref int colOfTheBestOption)
        {
            int BestOption = -1;
            rowOfTheBestOption = -1;
            colOfTheBestOption = -1;
            for (int i = 0; i < _board._length_of_row; i++)
            {
                for (int j = 0; j < _board._length_of_row; j++)
                {
                    Cell thisCell = _board._Cell_board[i, j];
                    if (!thisCell.HasValue())
                    {
                        if (BestOption == -1 || thisCell.NumOfOptions < BestOption)
                        {
                            BestOption = thisCell.NumOfOptions;
                            rowOfTheBestOption = i;
                            colOfTheBestOption = j;
                        }
                    }
                }
            }
        }
        
        private void SolveWithHumanTactics()
        {
            List<bool> solved;
            do
            {
                solved = new List<bool>();
                foreach (Itactics tactic in _Humantactics)
                {
                    solved.Add(tactic.tryToSolve());
                }
            } while (solved.Contains(true));
        }
        private bool SolveSudoku()
        {
            Board_Game ForBacktracking = (Board_Game)_board.Clone();
            BackTracking backtracking = new BackTracking(ForBacktracking);
            if (_board._numberOfPlacesInSquare < 4 && backtracking.BacktrackingSolve(0, 0, 0))
            {
                _board = ForBacktracking;
                return true;
            }
            else
            {
                SolveWithHumanTactics();
                Validation_Of_Board validator = new Validation_Of_Board(_board);
                int thisRow = -1, thisCol = -1;
                if (!validator.Validate(1))
                    return false;
                if (_board.isBoardSloved())
                    return true;

                BestEmptyCell(ref thisRow, ref thisCol);
                if (thisRow == -1 || thisCol == -1)
                    return false;
                Cell thisCell = _board._Cell_board[thisRow, thisCol];
                Board_Game clonedBoard = (Board_Game)_board.Clone();
                foreach (int guessToTry in thisCell.GetOptions())
                {
                    thisCell.Value = guessToTry; // make a guess on the current board
                    _board.RemoveTheOption(guessToTry, thisRow, thisCol); // update the options on the board according to the guess
                    if (SolveSudoku())
                    {
                        return true;
                    }
                    _board = (Board_Game)clonedBoard.Clone();
                    thisCell = _board._Cell_board[thisRow, thisCol];
                }
            }
            return false; // can't solve this board
        }
        public string SudokuSolution()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!SolveSudoku())
            {
                throw new ImpossibleSolvingException();
            }
            else
            {
                _board.displayboard();
                stopwatch.Stop();
                Console.WriteLine("Successful solving after: " + stopwatch.ElapsedMilliseconds + " milliseconds\n");
            }
            return _board.board_to_string();
        }
    }
}
