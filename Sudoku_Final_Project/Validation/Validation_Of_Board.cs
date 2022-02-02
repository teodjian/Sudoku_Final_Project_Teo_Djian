using Sudoku_Final_Project.Exepction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Validation
{
    class Validation_Of_Board
    {
        private Board_Game _board;
        public Validation_Of_Board(Board_Game board)
        {
            _board = board;
        }
        public bool AppearInRow(int num, int row)
        {
            int count = 0;
            for (int col = 0; col < _board._length_of_row; col++)
            {
                if (num == _board._Cell_board[row, col].Value)
                {
                    count++;
                    if (count > 1)
                    {
                        return false;
                    }
                }
            }
            return count == 1;
        }

        public bool AppearInCol(int num, int col)
        {
            int count = 0;
            for (int row = 0; row < _board._length_of_row; row++)
            {
                if (num == _board._Cell_board[row, col].Value)
                {
                    count++;
                    if (count > 1)
                    {
                        return false;
                    }
                }
            }
            return count == 1;
        }

        public bool AppearInBox(int num, int row, int col)
        {
            int boxSize = (int)Math.Sqrt(_board._length_of_row);
            int boxRow = row - (row % boxSize);
            int boxCol = col - (col % boxSize);
            int count = 0;
            for (int i = boxRow; i < boxRow + boxSize; i++)
            {
                for (int j = boxCol; j < boxCol + boxSize; j++)
                {
                    if (num == _board._Cell_board[i, j].Value)
                    {
                        count++;
                        if (count > 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return count == 1;
        }

        private bool ValidInPlace(int num, int row, int col)
        {
            return AppearInRow(num, row) && AppearInCol(num, col) &&
                   AppearInBox(num, row, col);
        }

        public bool Validate()
        {
            for (int row = 0; row < _board._length_of_row; row++)
            {
                for (int col = 0; col < _board._length_of_row; col++)
                {
                    Cell current = _board._Cell_board[row, col];
                    if (!current.IsSolved())
                    {
                        if (current.NumOfOptions == 0)
                        {
                            throw new InvalidInputException();
                        }
                    }
                    else if (!ValidInPlace(current.Value, row, col))
                    {
                        throw new InvalidInputException();
                    }
                }
            }
            return true;
        }

        public bool IsValidPlace(int num, int row, int col)
        {
            _board._Cell_board[row, col].Value = num;
            if (ValidInPlace(num, row, col))
            {
                return true;
            }
            _board._Cell_board[row, col].Value= 0;
            return false;
        }
    }
}
