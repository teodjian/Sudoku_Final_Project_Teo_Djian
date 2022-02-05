using Sudoku_Final_Project.Tactics;
using Sudoku_Final_Project.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    abstract class Board_Game: ICloneable
    {  
        public int _length_of_row { get; set; }  // length of the row in the board
        public int _numberOfPlacesInSquare { get; set; } // length of the row in the square in the board
        public Cell[,] _Cell_board;
        public Options options;

        public Board_Game(string board_str,int size_of_row)
        {
            _length_of_row = size_of_row;
            _numberOfPlacesInSquare = (int)Math.Pow(size_of_row,0.5);
            _Cell_board = new Cell[_length_of_row, _length_of_row];
            init_board(board_str);
            options = new Options(this);
            InitTheOptions();
        }

        public Board_Game()
        {

        }

        // the dispaly will be in the board_game_ui.
        public abstract void displayboard();
        // the init board get a string and put every char of the string in his cell.
        public void init_board(string board_str)
        {
            Validation_Of_Board vob = new Validation_Of_Board(this);
            for (int i = 0; i < _length_of_row; i++)
            {
                for (int j = 0; j < _length_of_row; j++)
                {
                    int currValue = board_str[i * _length_of_row + j]-'0';
                    _Cell_board[i, j] = new Cell(currValue, _length_of_row,i,j,_numberOfPlacesInSquare); // create the cell with the the information of the char.
                }
            }
            displayboard(); // display the board that we get
            vob.Validate(0); // check that the board is valid, the 0 is if the board is not valid , an invalid board input exception is throw
                             // and dont continue to try slove the board
        }
        // the option is removed from the row, col the square of the cell
        public void RemoveTheOption(int option, int row, int col)
        {
            Options options = new Options(this);
            options.RemoveOption(option, row, col);
        }
        // put to every cell the options that he can have.
        public void InitTheOptions()
        {
            options.EnterOptionsToCell();
        }
        // the function call to the function from options that remove from the square the option, but dont change the row or the col depend in the string colOrrow,
        // if "row" dont change the row for the square if "col"  dont change the col for the square
        public bool RemoveFromSquareWithOut(int option, int row, int col,string colOrrow)
        {
            return options.RemoveFromSquareWithOut_(option, row, col, colOrrow);
        }
        
        // function that check if every cell has value, return true if yes, else return false.
        public bool isBoardSloved()
        {
            for (int i = 0; i < _length_of_row; i++)
            {
                for (int j = 0; j < _length_of_row; j++)
                {
                    if (! _Cell_board[i,j].HasValue())
                        return false;
                }
            }
            return true;
        }

        // the board is changed to string.
        public string board_to_string()
        {
            string str = "";
            for (int i = 0; i < _length_of_row; i++)
            {
                for (int j = 0; j < _length_of_row; j++)
                {
                    str += ((char)(this._Cell_board[i, j].Value + '0'));
                }
            }
            return str;
        }
        // copy this board to a new board with the same Properties.
        public object Clone()
        {
            Board_Game Cloned = new Board_Game_UI();
            Cloned._length_of_row = this._length_of_row;
            Cloned._Cell_board = new Cell[_length_of_row,_length_of_row];
            Cloned._numberOfPlacesInSquare = _numberOfPlacesInSquare;
            Cloned.options = this.options;
            for (int row = 0; row < _length_of_row; row++)
            {
                for (int col = 0; col < _length_of_row; col++)
                {
                    Cloned._Cell_board[row, col] = (Cell)this._Cell_board[row, col].Clone();
                }
            }
            return Cloned;
        }

    }
}
