using Sudoku_Final_Project.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    abstract class Board_Game
    {  
        public int _length_of_row { get; set; }
        public int _numberOfPlacesInSquare { get; set; }

        public Cell[,] _Cell_board;

        public Board_Game(string board_str,int size_of_row)
        {
            _length_of_row = size_of_row;
            _numberOfPlacesInSquare = (int)Math.Pow(size_of_row,0.5);
            _Cell_board = new Cell[_length_of_row, _length_of_row];
            init_board(board_str);
        }
        public Board_Game()
        {

        }

        public void init_board(string board_str)
        {
            Validation_Of_Board bs = new Validation_Of_Board(this);
            for (int i = 0; i < _length_of_row; i++)
            {
                for (int j = 0; j < _length_of_row; j++)
                {
                    int currValue = board_str[i * _length_of_row + j]-'0';
                    _Cell_board[i, j] = new Cell(currValue, _length_of_row);
                }
            }
            displayboard();
            bs.Validate();
        }

        public abstract void displayboard();
    }
}
