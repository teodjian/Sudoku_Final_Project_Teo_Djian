using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Tactics
{
    class HiddenSingle
    {
        Board_Game _board;

        public HiddenSingle(Board_Game board)
        {
            _board = board;
        }
        
        public bool HiddenSingleSolve()
        {
            int cnt = 0;
            for (int i = 0; i < _board._length_of_row; i++)
            {
                for (int j = 0; j < _board._length_of_row; j++)
                {
                    Cell thisCell = _board._Cell_board[i, j];
                    if (!thisCell.HasValue())
                    {
                        if (thisCell.NumOfOptions == 0)
                        {
                            return false;
                        }
                        foreach (int item in thisCell.GetOptions())
                        {
                            if (IsSingle(item, i, j))
                            {
                                cnt++;
                                thisCell.SetValue(item);
                                _board.RemoveAllOption(item, i, j);
                                i = 0;
                                j = 0;
                                break;
                            }
                        }
                    }
                }
            }
            return cnt > 0;
        }

        private bool IsSingle(int num, int row, int col)
        {
            return SingleInRow(num, row) || SingleInCol(num, col) || SingleInSquare(num, row, col);
        }

        private bool SingleInRow(int num, int row)
        {
            int cnt = 0;
            for (int i = 0; i < _board._length_of_row; i++)
            {
                Cell thisCell = _board._Cell_board[row, i];
                if (!thisCell.HasValue() && thisCell.GetOptions().Contains(num))
                {
                    cnt++;
                    if (cnt > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool SingleInCol(int num, int col)
        {
            int cnt = 0;
            for (int i = 0; i < _board._length_of_row; i++)
            {
                Cell thisCell = _board._Cell_board[i, col];
                if (!thisCell.HasValue() && thisCell.GetOptions().Contains(num))
                {
                    cnt++;
                    if (cnt > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool SingleInSquare(int num, int row, int col)
        {
            int cnt = 0;
            int squareRow = row - (row % _board._numberOfPlacesInSquare);
            int squareCol = col - (col % _board._numberOfPlacesInSquare);
            for (int i = squareRow; i < squareRow + _board._numberOfPlacesInSquare; i++)
            {
                for (int j = squareCol; j < squareCol + _board._numberOfPlacesInSquare; j++)
                {
                    Cell thisCell = _board._Cell_board[i, j];
                    if (!thisCell.HasValue() && thisCell.GetOptions().Contains(num))
                    {
                        cnt++;
                        if (cnt > 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }
    }
}
