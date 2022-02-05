using Sudoku_Final_Project.Exepction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Validation
{
    public class Validation_Of_Board
    {
        private Board_Game _board;
        public Validation_Of_Board(Board_Game board)
        {
            _board = board;
        }

        // the function Validate check if the board is valid, according to the sudoku rules, if the "time" get the number 0- the examination 
        // is after getting the board from the user, so if the board is not valid, InvalidBoardInputException will be throw,
        // if this board is valid the function will return true. "time" not 0, is when i get a board after the solving algorithem "guess" a number,
        // so if its not correct will return false (because the board is correct but not the guess), and correct true.
        public bool ValidationOfBoard(int time)
        {
            for (int row = 0; row < _board._length_of_row; row++)
            {
                for (int col = 0; col < _board._length_of_row; col++)
                {
                    Cell thisCell = _board._Cell_board[row, col];
                    if (!thisCell.HasValue())
                    {
                        if (thisCell.NumOfOptions == 0)
                        {
                            if (time == 0) // in the first examination, after getting from the user the board
                                throw new InvalidBoardInputException();
                            else
                                return false;
                        }
                    }
                    else if (!(AppearIn_(thisCell.Value, row, "row") && AppearIn_(thisCell.Value, col, "col") &&
                                AppearInSquare(thisCell.Value, row, col))) // check if the value appear only once in the row, col the square
                    {
                        if (time == 0)
                            throw new InvalidBoardInputException();
                        else
                            return false;
                    }
                }
            }
            return true;
        }

        // AppearIn_ is a function that check if the number appear in the row/col that is given when the function is called,
        // if the number only once appaer the function return true, else return false, the differnt is when we call the function, 
        // the string colOrrow say if we are checking for specific row= the string will be "row", and if it is for col the string will be "col"
        public bool AppearIn_(int num, int i, string colOrrow)
        {
            int checkednum=-1;
            int count = 0;
            for (int j = 0; j < _board._length_of_row; j++)
            {
                if (colOrrow.Equals("row"))
                    checkednum = _board._Cell_board[i, j].Value;
                else if (colOrrow.Equals("col"))
                    checkednum = _board._Cell_board[j, i].Value;
                if (num ==checkednum)
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
        // the function check how much time the number appaer in his square if only once the function return true, if more or less return false 
        public bool AppearInSquare(int num, int row, int col)
        {
            int SquareRow = row - (row % _board._numberOfPlacesInSquare);
            int SquareCol = col - (col % _board._numberOfPlacesInSquare);
            int count = 0;
            for (int i = SquareRow; i < SquareRow + _board._numberOfPlacesInSquare; i++)
            {
                for (int j = SquareCol; j < SquareCol + _board._numberOfPlacesInSquare; j++)
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

        

    }
}
