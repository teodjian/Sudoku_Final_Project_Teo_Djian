using Sudoku_Final_Project.Tactics;
using Sudoku_Final_Project.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
     class  Solver1
    {
        public Board_Game _board;

        public Solver1(Board_Game board)
        {
            _board = board;
        }
        public void solve()
        {
            _board.InitTheOptions();
            HiddenSingle hiddenSingle = new HiddenSingle(_board);
            Backtracking backtracking = new Backtracking(_board);
            if (hiddenSingle.HiddenSingleSolve())
                _board.displayboard();
            else if (backtracking.BacktrackingSolve(0, 0))
                _board.displayboard();
            else
            {
                _board.displayboard();
                Console.WriteLine("can't solve this sudoku");
            }
                
            //Backtracking backtracking=new Backtracking(_board);

        }
        public bool solveSudoku(int row, int col)
        {
            Validation_Of_Board bs = new Validation_Of_Board(_board);
            /*if we have reached the 8th
                   row and 9th column (0
                   indexed matrix) ,
                   we are returning true to avoid further
                   backtracking       */
            if (row == _board._length_of_row - 1 && col == _board._length_of_row)
            { 
                return true;
            }
                

            // Check if column value  becomes 9 ,
            // we move to next row
            // and column start from 0
            if (col == _board._length_of_row)
            {
                row++;
                col = 0;
            }

            // Check if the current position
            // of the grid already
            // contains value >0, we iterate
            // for next column
            if (_board._Cell_board[row, col].Value != 0)
                return solveSudoku(row, col + 1);

            for (int num = 1; num < _board._length_of_row + 1; num++)
            {

                // Check if it is safe to place
                // the num (1-9)  in the
                // given row ,col ->we move to next column
                if (isSafe(row, col, num))
                {

                    /*  assigning the num in the current
                            (row,col)  position of the grid and
                            assuming our assigned num in the position
                            is correct */
                    _board._Cell_board[row, col].Value = num;

                    // Checking for next
                    // possibility with next column
                    if (solveSudoku(row, col + 1))
                        return true;
                }
                /* removing the assigned num , since our
                         assumption was wrong , and we go for next
                         assumption with diff num value   */
                _board._Cell_board[row, col].Value = 0;
            }
            return false;
        }
        // Check whether it will be legal
        // to assign num to the
        // given row, col
        private bool isSafe(int row, int col,
                           int num)
        {
            
            // Check if we find the same num
            // in the similar row , we
            // return false
            for (int x = 0; x < _board._length_of_row; x++)
                if (_board._Cell_board[row, x].Value == num)
                    return false;

            // Check if we find the same num
            // in the similar column ,
            // we return false
            for (int x = 0; x < _board._length_of_row; x++)
                if (_board._Cell_board[x, col].Value == num)
                    return false;

            // Check if we find the same num
            // in the particular 3*3
            // matrix, we return false
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
