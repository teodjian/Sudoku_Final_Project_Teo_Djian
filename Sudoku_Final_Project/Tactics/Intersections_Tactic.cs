using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Tactics
{
    public class Intersections_Tactic: Itactics
    {
           private Board_Game _board;
        public Intersections_Tactic(Board_Game board)
        {
            _board = board;
        }
        public bool tryToSolve()
        {
            return Intersections_Solve();
        }

        // Intersections mean that If in a block all options of a certain number are confined to a row or column,
        // that number cannot appear outside of that square in that row or col. or If in a row (or column)
        // all options of a certain number are confined to one square, that option that be eliminated from all other cells in that square.
        // the function for every cell check for every option if a case like that can happed,
        // if yes the function update the options for the cell and return true
        public bool Intersections_Solve()
            {
                for (int i = 0; i < _board._length_of_row; i++)
                {
                    for (int j = 0; j < _board._length_of_row; j++)
                    {
                        Cell thisCell= _board._Cell_board[i, j];
                        if (!thisCell.HasValue())
                        {
                            if (thisCell.NumOfOptions == 0)
                                return false;
                            foreach (int option in thisCell.GetOptions())
                            {
                                if (IntersectionIn_(option, i,"row"))
                                    if (_board.RemoveFromSquareWithOut(option, i, j,"row"))
                                        return true;
                                if (IntersectionIn_(option, j,"col"))
                                    if (_board.RemoveFromSquareWithOut(option, i, j,"col"))
                                        return true;
                            }
                        }
                    }
                }
                return false;
            }

        // IntersectionIn_ depened in the string, if the string colOrrow is col so the function check if there is intersection in col and if the string
        // is row so the function check if there is intersection in row. function check if the option was more than once in the col/row and all was in the 
        // same square, if yes return true else false.
        public bool IntersectionIn_(int option, int j,string colOrrow)
            {
                Cell thisCell=null;
                int counter = 0;
                int squareIndexFound = -1;
                for (int i = 0; i < _board._length_of_row; i++)
                {
                    if (colOrrow.Equals("row"))
                        thisCell = _board._Cell_board[j, i];
                    
                    if (colOrrow.Equals("col"))
                        thisCell = _board._Cell_board[i, j];

                    if (!thisCell.HasValue())
                    {
                        if (thisCell.HasThisOption(option))
                        {
                            counter++;
                            if (squareIndexFound == -1)
                                squareIndexFound = thisCell.squareIndex;
                            else
                                if (thisCell.squareIndex != squareIndexFound)
                                    return false;
                        }
                    }
                }
                return (counter > 1);
            }


        }
    }
