﻿using Sudoku_Final_Project.Tactics;
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
        public bool BacktrackingSolve(int row, int col,int treeLevel)
        {
            if (treeLevel > 4)
                return false;
            if (row == _board._length_of_row - 1 && col == _board._length_of_row)
                return true;
            if (col == _board._length_of_row)
            {
                row++;
                col = 0;
            }
            if (_board._Cell_board[row, col].Value != 0)
                return BacktrackingSolve(row, col + 1,treeLevel++);

            for (int num = 1; num < _board._length_of_row + 1; num++)
            {
                if (isSafe(row, col, num))
                {
                    _board._Cell_board[row, col].Value = num;
                    if (BacktrackingSolve(row, col + 1,treeLevel++))
                        return true;
                }
                _board._Cell_board[row, col].Value = 0;
            }
            return false;
        }
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
