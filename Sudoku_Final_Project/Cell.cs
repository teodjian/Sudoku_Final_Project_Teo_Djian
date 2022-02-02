using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    class Cell: ICell,ICloneable
    {
        public int _row { get; set; }
        public int _col { get; set; }
        public int _value { get; set; }
        private HashSet<int> _options { get; set; }

        public Cell(int value, int boardSize)
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
        }

        public Cell(int value)
        {
            _value = value;
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
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

        public void SetValue(int num)
        {
            _value = num;
        }

        public int GetOption()
        {
            int num = 0;
            foreach (int item in _options)
            {
                num = item;
            }
            return num;
        }

        public bool HasValue()
        {
            return _value != 0;
        }

        public object Clone()
        {
            Cell sudokuCell = new Cell(this._value);
            sudokuCell._options = new HashSet<int>(this._options);
            return sudokuCell;
        }
    }


}

