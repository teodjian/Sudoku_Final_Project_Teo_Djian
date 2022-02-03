using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Tactics
{
    class Options
    {
        Board_Game _board;

        public Options(Board_Game board)
        {
            _board = board;
        }

        public void RemoveOption(int num, int row, int col)
        {
            RemoveFromRow(num, row);
            RemoveFromCol(num, col);
            RemoveFromSquare(num, row, col);
        }

        private void RemoveFromRow(int option, int row)
        {
            for (int i = 0; i < _board._length_of_row; i++)
            {
                Cell thisCell = _board._Cell_board[row, i];
                if (!thisCell.HasValue())
                {
                    thisCell.RemoveOption(option);
                }
            }
        }
        private void RemoveFromCol(int option, int col)
        {
            for (int i = 0; i < _board._length_of_row; i++)
            {
                Cell thisCell = _board._Cell_board[i, col];
                if (!thisCell.HasValue())
                {
                    thisCell.RemoveOption(option);
                }
            }
        }

        private void RemoveFromSquare(int option, int row, int col)
        {
            int SquareRow = row - (row % _board._numberOfPlacesInSquare);
            int SquareCol = col - (col % _board._numberOfPlacesInSquare);
            for (int i = SquareRow; i < SquareRow + _board._numberOfPlacesInSquare; i++)
            {
                for (int j = SquareCol; j < SquareCol + _board._numberOfPlacesInSquare; j++)
                {
                    Cell thisCell = _board._Cell_board[i, j];
                    if (!thisCell.HasValue ())
                    {
                        thisCell.RemoveOption(option);
                    }
                }
            }
        }
        public void EnterOptionsToCell()
        {
            for (int i = 0; i < _board._length_of_row; i++)
            {
                for (int j = 0; j < _board._length_of_row; j++)
                {
                    Cell thisCell = _board._Cell_board[i, j];
                    if (thisCell.HasValue())
                    {
                        RemoveOption(thisCell.Value, i, j);
                    }
                }
            }
        }
    }
}
