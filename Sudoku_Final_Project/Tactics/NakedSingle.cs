using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Tactics
{
    public class NakedSingle: Itactics
    {
        Board_Game _board;
        public NakedSingle(Board_Game board)
        {
            _board = board;
        }
        public bool tryToSolve()
        {
            return NakedSingleSolver();
        }
        
        //Naked Single means that if in a specific cell only one option remains possible, The option must be the value of this cell.
        // the function run on all the celles and if there is a cell, with one option the option become the value, and the option is removed from his
        // row, col, and square, return true if there was more then one or more cell like that, else false.
        public bool NakedSingleSolver()
        {
            int counter = 0;
            for (int i = 0; i < _board._length_of_row; i++)
            {
                for (int j = 0; j < _board._length_of_row; j++)
                {
                    Cell thisCell= _board._Cell_board[i, j];
                    if (!thisCell.HasValue())
                    {
                        if (thisCell.NumOfOptions == 0)
                            return false;
                        if (thisCell.NumOfOptions == 1)
                        {
                            int ThisOption = thisCell.GetOption();
                            thisCell.Value=ThisOption;
                            _board.RemoveTheOption(ThisOption, i, j);
                            counter++;
                            i = 0;
                            j = 0;
                        }
                    }
                }
            }
            return counter > 0;
        }
    }
 }

