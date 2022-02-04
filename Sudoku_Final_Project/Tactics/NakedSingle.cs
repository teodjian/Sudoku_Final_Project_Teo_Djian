using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Tactics
{
    class NakedSingle: Itactics
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

