using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    /*class Board_Solver : Board_Game
    {
        public Board_Solver(string str,int length_of_row) : base(length_of_row)
        {
        }
        public bool notInRow(int row)
        { // Set to store characters seen so far.
            HashSet<int> st = new HashSet<int>();

            for (int i = 0; i < _length_of_row; i++)
            {

                // If already encountered before,
                // return false
                if (st.Contains(_board_matrix[row, i]))
                    return false;

                // If it is not an empty cell, insert value
                // at the current cell in the set
                if (_board_matrix[row, i] != 0)
                    st.Add(_board_matrix[row, i]);
            }
            return true;
        }

        // Checks whether there is any duplicate
        // in current column or not.
        public bool notInCol(int col)
        {
            HashSet<int> st = new HashSet<int>();

            for (int i = 0; i < _length_of_row; i++)
            {

                // If already encountered before,
                // return false
                if (st.Contains(_board_matrix[i, col]))
                    return false;

                // If it is not an empty cell,
                // insert value at the current
                // cell in the set
                if (_board_matrix[i, col] != 0)
                    st.Add(_board_matrix[i, col]);
            }
            return true;
        }

        // Checks whether there is any duplicate
        // in current 3x3 box or not.
        public bool notInBox(int startRow, int startCol)
        {
            HashSet<int> st = new HashSet<int>();

            for (int row = 0; row < _numberOfPlacesInSquare; row++)
            {
                for (int col = 0; col < _numberOfPlacesInSquare; col++)
                {
                    int curr
                        = _board_matrix[row + startRow, col + startCol];

                    // If already encountered before, return
                    // false
                    if (st.Contains(curr))
                        return false;

                    // If it is not an empty cell,
                    // insert value at current cell in set
                    if (curr != 0)
                        st.Add(curr);
                }
            }
            return true;
        }

        // Checks whether current row and current column and
        // current 3x3 box is valid or not
        public bool isValid(int row,int col)
        {
            return notInRow(row) && notInCol(col)
                && notInBox(row - row % _numberOfPlacesInSquare, col - col % _numberOfPlacesInSquare);
        }

        public void isValidConfig()
        {
            for (int i = 0; i < _length_of_row; i++)
            {
                for (int j = 0; j < _length_of_row; j++)
                {
                    if (!isValid(i, j))
                        throw new InvalidInputException();
                }
            }
            //return true;
        }



    }
    */
}
