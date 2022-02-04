﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project.Tactics
{
    class HiddenSingle: Itactics
    {
        public Board_Game _board { get; set; }

        public HiddenSingle(Board_Game board)
        {
            _board = board;
        }
        public bool tryToSolve()
        {
            return HiddenSingleSolve();
        }

        private bool Single(int num, int row, int col)
        {
            return SingleIn_(num, row, "row") || SingleIn_(num, col, "col") || SingleInSquare(num, row, col);
        }
        private bool SingleInSquare(int num, int row, int col)
        {
            int counter = 0;
            int squareRow = row - (row % _board._numberOfPlacesInSquare);
            int squareCol = col - (col % _board._numberOfPlacesInSquare);
            for (int i = squareRow; i < squareRow + _board._numberOfPlacesInSquare; i++)
            {
                for (int j = squareCol; j < squareCol + _board._numberOfPlacesInSquare; j++)
                {
                    Cell thisCell = _board._Cell_board[i, j];
                    if (!thisCell.HasValue() && thisCell.HasThisOption(num))
                    {
                        counter++;
                        if (counter > 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }
        public bool HiddenSingleSolve()
        {
            int counter = 0;
            for (int i = 0; i < _board._length_of_row; i++)
            {
                for (int j = 0; j < _board._length_of_row; j++)
                {
                    Cell thisCell = _board._Cell_board[i, j];
                    if (!thisCell.HasValue())
                    {
                        if (thisCell.NumOfOptions == 0)
                            return false;
                        foreach (int item in thisCell.GetOptions())
                        {
                            if (Single(item, i, j))
                            {
                                counter++;
                                thisCell.Value = item;
                                _board.RemoveTheOption(item, i, j);
                                i = 0;
                                j = 0;
                                break;
                            }
                        }
                    }
                }
            }
            return (counter > 0);
        }

        // SingleIn_ depened in the string, if the string colOrrow is col so the function check if there is a single in col and if the string
        // is row so the function check if there is a single in row
        private bool SingleIn_(int num, int j, string colOrrow)
        {
            Cell thisCell = null;
            int counter = 0;
            for (int i = 0; i < _board._length_of_row; i++)
            {
                if (colOrrow.Equals("row"))
                    thisCell = _board._Cell_board[j, i];

                if (colOrrow.Equals("col"))
                    thisCell = _board._Cell_board[i, j];

                if (!thisCell.HasValue() && thisCell.HasThisOption(num))
                {
                    counter++;
                    if (counter > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
       
    }
}
