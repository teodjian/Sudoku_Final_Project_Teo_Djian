using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku_Final_Project.Validation;
using System;

namespace Sudoku_Final_Project.UnitTests
{

    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void check_length_ValidSize_ReturnsTrue()
        {
            // Arrange
            string sudoku = "300060070024000309050000040080104000000700000000005400000070000000340080900218000"; // 81
            Validation_Input validation = new Validation_Input();
            bool CheckResult = true;

            // Act 
            try
            {
                validation.check_length(sudoku.Length);
            }catch
            {
                CheckResult = false;
            }

            // Assert 
            finally { 
                Assert.IsTrue(CheckResult); 
            }
           
        }

        [TestMethod]
        public void check_length_InValidSize_ReturnsFalse()
        {
            // Arrange
            string sudoku = "896000000000103090070000200000400072007032009002009008038600407700904000020000"; // 78
            Validation_Input validation = new Validation_Input();
            bool CheckResult = true;

            // Act - Calling method (function)
            try
            {
                validation.check_length(sudoku.Length);
            }
            catch
            {
                CheckResult = false;
            }

            // Assert - Check if expected behavior was reached
            finally
            {
                Assert.IsFalse(CheckResult);
            }

        }

        [TestMethod]
        public void check_keys_ValidSize_ReturnsTrue()
        {
            // Arrange
            string sudoku = "000000000000000600200000000000000760000000030006000400000300000000070000030108000";
            Validation_Input validation = new Validation_Input();
            bool CheckResult = true;

            // Act 
            try
            {
                validation.check_keys(sudoku,sudoku.Length);
            }
            catch
            {
                CheckResult = false;
            }

            // Assert 
            finally
            {
                Assert.IsTrue(CheckResult);
            }

        }

        [TestMethod]
        public void check_keys_InValidSize_ReturnsFalse()
        {
            // Arrange
            string sudoku = "30050000000007000TEO000060000000006000600900070700000000170405000003020700048007";
            Validation_Input validation = new Validation_Input();
            bool CheckResult = true;

            // Act - Calling method (function)
            try
            {
                validation.check_length(sudoku.Length);
            }
            catch
            {
                CheckResult = false;
            }

            // Assert - Check if expected behavior was reached
            finally
            {
                Assert.IsFalse(CheckResult);
            }

        }

        [TestMethod]
        public void ValidationOfBoard_ValidSize_ReturnsTrue()
        {
            // Arrange
            string sudoku = "480020005001005400000000708000001000000000000000000257000264071000008390000000000";
            double size_of_row = Math.Pow(sudoku.Length, 0.5);
            Board_Game sudokuBoard = new Board_Game_UI(sudoku, (int)size_of_row);
            Validation_Of_Board validation = new Validation_Of_Board(sudokuBoard);
            // Act 
            bool CheckResult = validation.ValidationOfBoard(1);

            // Assert - Check if expected behavior was reached
            Assert.IsTrue(CheckResult);

        }

        [TestMethod]
        public void ValidationOfBoard_InValidSize_ReturnsFalse()
        {
            // Arrange
            string sudoku = "002000000000000000000008000550001406000000170601000090000000000000009000003600000";
            double size_of_row = Math.Pow(sudoku.Length, 0.5);
            bool CheckResult = true;

            // Act - Calling method (function)
            try
            {
                Board_Game sudokuBoard = new Board_Game_UI(sudoku, (int)size_of_row);
                Validation_Of_Board validation = new Validation_Of_Board(sudokuBoard);
                validation.ValidationOfBoard(1);
            }
            catch
            {
                CheckResult = false;
            }

            // Assert - Check if expected behavior was reached
            finally
            {
                Assert.IsFalse(CheckResult);
            }


        }
    }
}
