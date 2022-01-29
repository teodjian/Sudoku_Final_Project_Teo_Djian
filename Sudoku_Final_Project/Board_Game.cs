using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    abstract class Board_Game
    { 
        private int _length_of_board { get; set; }
        private int[,] _board_matrix { get; set; }

        public Board_Game(int length, int [,]matrix)
        {
            _length_of_board = length;
            _board_matrix = matrix;
        }
        public Board_Game()
        {

        }
    }
}
