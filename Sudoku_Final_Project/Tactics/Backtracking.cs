using Sudoku_Final_Project.Tactics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    class BackTracking
    {

        public Board_Game _board;
        public BackTracking(Board_Game board)
        {
            _board = board;
        }
        // The Backtracking is an algorithem that generate all possible configurations of numbers from 1 to _length_of_row to fill the empty cells.
        // Try every configuration one by one until the correct configuration is found.
        // After filling all the position check if the matrix is safe or not. If safe return true else recurs for other cases.
        // because this algorithem can have a lot of possibilities if the "tree level"- the algorithem enter into him self 4 or more time return false
        // because in this case the human tactics are better In terms of Time complexity
        // if lastOption is true, given more possibilities to find the solution because the human tactics can't find the solution.
        public bool BacktrackingSolve(int row, int col,int treeLevel, bool lastOption)
        {
            if (treeLevel > 4 && !lastOption) 
                return false;
            if (treeLevel > _board._length_of_row+1 && lastOption)
                return false;
            if (row == _board._length_of_row - 1 && col == _board._length_of_row)
                return true;
            if (col == _board._length_of_row)
            {
                row++;
                col = 0;
            }
            if (_board._Cell_board[row, col].Value != 0)
                return BacktrackingSolve(row, col + 1,treeLevel++,lastOption);

            for (int num = 1; num < _board._length_of_row + 1; num++)
            {
                if (isSafe(row, col, num))
                {
                    _board._Cell_board[row, col].Value = num;
                    if (BacktrackingSolve(row, col + 1,treeLevel++, lastOption))
                        return true;
                }
                _board._Cell_board[row, col].Value = 0;
            }
            return false;
        }

        // is safe check that the board is not Violates sudoku rules, return true if it is ok. 
        private bool isSafe(int row, int col, int num)
        {
            for (int i = 0; i < _board._length_of_row; i++)
                if (_board._Cell_board[row, i].Value == num)
                    return false;
            for (int i = 0; i < _board._length_of_row; i++)
                if (_board._Cell_board[i, col].Value == num)
                    return false;
            int startRow = row - row % _board._numberOfPlacesInSquare, startCol
              = col - col % _board._numberOfPlacesInSquare;
            for (int i = 0; i < _board._numberOfPlacesInSquare; i++)
                for (int j = 0; j < _board._numberOfPlacesInSquare; j++)
                    if (_board._Cell_board[i + startRow, j + startCol].Value == num)
                        return false;
            return true;
        }
    }
}
