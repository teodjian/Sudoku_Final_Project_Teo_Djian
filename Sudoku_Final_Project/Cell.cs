using System;
using System.Collections.Generic;

namespace Sudoku_Final_Project
{
    public class Cell: ICloneable
    {
        private int _row { get; set; }
        private int _value;
        private HashSet<int> _options { get; set; }
        private int _squareIndex;

        public Cell(int value, int boardSize,int row,int col,int SquareSize)
        {
            _value = value;
            _options = new HashSet<int>();
            if (_value == 0)
            {
                for (int num = 1; num <=boardSize; num++)
                {
                    if (num != value)
                    {
                        _options.Add(num);
                    }
                }
            }
            _row = row;
            _squareIndex = SquareSize * (row / SquareSize) + col / SquareSize;
        }

        private Cell(int value)
        {
            _value = value;
        }
        // get and set of the value of the cell
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        // return the index of the square that the cell is in
        public int squareIndex
        {
            get { return _squareIndex; }
        }

        // return the number of elements that are in the hash set 
        public int NumOfOptions
        {
            get { return _options.Count; }
        }
        // return a hash set with all the options that the cell have.
        public HashSet<int> GetOptions()
        {
            return _options;
        }

        // get a number and remove it from the hash set with the options for this cell
        public void RemoveOption(int num)
        {
            _options.Remove(num);
        }
        // get a number and return true if the option is in the hash set, else return false
        public bool HasThisOption(int option)
        {
            return _options.Contains(option);
        }
        // get the first option in the hash set 
        public int GetOption()
        {
            int num = 0;
            foreach (int item in _options)
            {
                num = item;
                break;

            }
            return num;
        }

        // check if the cell has value that is not 0, return true if yes
        public bool HasValue()
        {
            return _value != 0;
        }

        // copy this cell to a new cell with the same Properties.
        public object Clone()
        {
            Cell ClonedCell = new Cell(this._value);
            ClonedCell._options = new HashSet<int>(this._options);
            return ClonedCell;
        }
    }


}

