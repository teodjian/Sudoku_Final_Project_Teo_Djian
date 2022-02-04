using System;
using System.Collections.Generic;

namespace Sudoku_Final_Project
{
    class Cell: ICloneable
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

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public int squareIndex
        {
            get { return _squareIndex; }
        }

        public int NumOfOptions
        {
            get { return _options.Count; }
        }

        public HashSet<int> GetOptions()
        {
            return _options;
        }

        public void RemoveOption(int num)
        {
            _options.Remove(num);
        }

        public bool HasThisOption(int option)
        {
            return _options.Contains(option);
        }

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

        public bool HasValue()
        {
            return _value != 0;
        }

        public object Clone()
        {
            Cell ClonedCell = new Cell(this._value);
            ClonedCell._options = new HashSet<int>(this._options);
            return ClonedCell;
        }
    }


}

