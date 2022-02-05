using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Sudoku_Final_Project;

namespace Sudoku_Final_Project.UnitTests
{
    [TestClass]
    public class SolverTests
    {
        Solver solver;
        [TestMethod]
        public void SolveSudoku_4x4_ReturnsTrue()
        {
            // Arrange
            string board = "0010204003000004";
            double size_of_row = Math.Pow(board.Length, 0.5);
            Board_Game sudokuBoard = new Board_Game_UI(board, (int)size_of_row);
            solver = new Solver(sudokuBoard);

            // Act
            bool solved = solver.SolveSudoku();
            // Assert 
            Assert.IsTrue(solved);

           
        }

        [TestMethod]
        public void SolveSudoku_9x9_ReturnsTrue()
        {
            // Arrange 
            string board = "007000000500000030000000000000900000800304010010000000000000001000007000000000003";
            double size_of_row = Math.Pow(board.Length, 0.5);
            Board_Game sudokuBoard = new Board_Game_UI(board, (int)size_of_row);
            solver = new Solver(sudokuBoard);

            // Act 
            bool solved = solver.SolveSudoku();

            // Assert 
            Assert.IsTrue(solved);

            
        }

        [TestMethod]
        public void SolveSudoku_16x16_ReturnsTrue()
        {
            // Arrange 
            string board = "00<00010020008000003?=<001:4500000@>;007500=?30020=706800?>0410;000000?>23000000<02;=90@:05>1?07>50000000000003600180002;0009=0000?:00014000@<004;000000000000?8107<240;=0?83:0500000063<:000000@09?0<200;70=5030031500?>0027;0000057>;00<13800000;000@004000900";
            double size_of_row = Math.Pow(board.Length, 0.5);
            Board_Game sudokuBoard = new Board_Game_UI(board, (int)size_of_row);
            solver = new Solver(sudokuBoard);

            // Act 
            bool solved = solver.SolveSudoku();

            // Assert 
            Assert.IsTrue(solved);

            
        }

        [TestMethod]
        public void SolveSudoku_16x16_2_ReturnsTrue()
        {
            // Arrange 
            string board = "000000;000000:200000?000000000;00:0@0000?000<0000080010:000000?0000000003100000000000000=000000000000000000000000000000000000<000000000000500000020000000000000;00>00000000000800000000000000000000000?00000000080000000000000000000000=000000400?0000000=000000";
            double size_of_row = Math.Pow(board.Length, 0.5);
            Board_Game sudokuBoard = new Board_Game_UI(board, (int)size_of_row);
            solver = new Solver(sudokuBoard);

            // Act 
            bool solved = solver.SolveSudoku();

            // Assert 
            Assert.IsTrue(solved);


        }

        [TestMethod]
        public void SolveSudoku_Empty1x1_ReturnsTrue()
        {
            // Arrange
            string board = "0";
            double size_of_row = Math.Pow(board.Length, 0.5);
            Board_Game sudokuBoard = new Board_Game_UI(board,(int)size_of_row);
            solver = new Solver(sudokuBoard);
            
            // Act 
            bool solved = solver.SolveSudoku();
           
            // Assert 
            Assert.IsTrue(solved);

            
        }

        [TestMethod]
        public void SolveSudoku_Empty4x4_ReturnsTrue()
        {
            // Arrange
            string board = "0000000000000000";
            double size_of_row = Math.Pow(board.Length, 0.5);
            Board_Game sudokuBoard = new Board_Game_UI(board, (int)size_of_row);
            solver = new Solver(sudokuBoard);

            // Act 
            bool solved = solver.SolveSudoku();

            // Assert 
            Assert.IsTrue(solved);

            
        }

        [TestMethod]
        public void SolveSudoku_Empty9x9_ReturnsTrue()
        {
            // Arrange 
            string board = "000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            double size_of_row = Math.Pow(board.Length, 0.5);
            Board_Game sudokuBoard = new Board_Game_UI(board, (int)size_of_row);
            solver = new Solver(sudokuBoard);
           
            // Act 
            bool solved = solver.SolveSudoku();
            
            // Assert 
            Assert.IsTrue(solved);

        }

        [TestMethod]
        public void SolveSudoku_Empty16x16_ReturnsTrue()
        {
            // Arrange 
            string board = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            double size_of_row = Math.Pow(board.Length, 0.5);
            Board_Game sudokuBoard = new Board_Game_UI(board, (int)size_of_row);
            solver = new Solver(sudokuBoard);

            // Act
            bool solved = solver.SolveSudoku();

            // Assert 
            Assert.IsTrue(solved);

        }

        [TestMethod]
        public void SolveSudoku_Unsolvable4x4_ReturnFalse()
        {
            // Arrange 
            string board = "0010230000000400";
            double size_of_row = Math.Pow(board.Length, 0.5);
            Board_Game sudokuBoard = new Board_Game_UI(board, (int)size_of_row);
            solver = new Solver(sudokuBoard);

            // Act 
            bool solved = solver.SolveSudoku();

            // Assert 
            Assert.IsFalse(solved);

        }

        [TestMethod]
        public void SolveSudoku_Unsolvable9x9_ReturnsFalse()
        {
            // Arrange
            string board = "100000000000100000000000005000000100000000000000000000000000000000000010000000000";
            double size_of_row = Math.Pow(board.Length, 0.5);
            Board_Game sudokuBoard = new Board_Game_UI(board, (int)size_of_row);
            solver = new Solver(sudokuBoard);

            // Act 
            bool solved = solver.SolveSudoku();
            
            // Assert 
            Assert.IsFalse(solved);
        }

    }
}
