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
            RemoveFrom_(num, row,"row");
            RemoveFrom_(num, col,"col");
            RemoveFromSquare(num, row, col);
        }
        private void RemoveFromSquare(int option, int row, int col)
        {
            int SquareCol = col - (col % _board._numberOfPlacesInSquare);
            int SquareRow = row - (row % _board._numberOfPlacesInSquare);
            for (int i = SquareRow; i < SquareRow + _board._numberOfPlacesInSquare; i++)
            {
                for (int j = SquareCol; j < SquareCol + _board._numberOfPlacesInSquare; j++)
                {
                    Cell thisCell = _board._Cell_board[i, j];
                    if (!thisCell.HasValue())
                    {
                        thisCell.RemoveOption(option);
                    }
                }
            }
        }
        private void RemoveFrom_(int option, int j,string colOrrow)
        {
            Cell thisCell = null;
            for (int i = 0; i < _board._length_of_row; i++)
            {
                if (colOrrow.Equals("row"))
                    thisCell = _board._Cell_board[j, i];

                if (colOrrow.Equals("col"))
                    thisCell = _board._Cell_board[i, j];
                if (!thisCell.HasValue())
                {
                    thisCell.RemoveOption(option);
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
        public bool RemoveFromSquareWithOut_(int option, int row, int col, string forColOrRow)
        {
            bool removeOption = false;
            int squareRow = row - (row % _board._numberOfPlacesInSquare);
            int squareCol = col - (col % _board._numberOfPlacesInSquare);
            for (int i = squareRow; i < squareRow + _board._numberOfPlacesInSquare; i++)
            {
                for (int j = squareCol; j < squareCol + _board._numberOfPlacesInSquare; j++)
                {
                    if (forColOrRow.Equals("row"))
                    {
                        if (i != row)
                        {
                            Cell thisCell = _board._Cell_board[i, j];
                            if (!thisCell.HasValue())
                            {
                                if (thisCell.HasThisOption(option))
                                {
                                    thisCell.RemoveOption(option);
                                    removeOption = true;
                                }
                            }
                        }
                    }
                    if(forColOrRow.Equals("col"))
                    {
                        if (j != col)
                        {
                            Cell thisCell = _board._Cell_board[i, j];
                            if (!thisCell.HasValue())
                            {
                                if (thisCell.HasThisOption(option))
                                {
                                    thisCell.RemoveOption(option);
                                    removeOption = true;
                                }
                            }
                        }
                    }
                }
            }
            return removeOption;
        }
    }
}
