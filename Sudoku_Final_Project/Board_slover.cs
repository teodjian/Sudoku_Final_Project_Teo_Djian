using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Final_Project
{
    class Board_slover
    {
        /* public bool Validate(int[,] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                bool[] row = new bool[10];
                bool[] col = new bool[10];

                for (int j = 0; j < 9; j++)
                {
                    if (row[grid[i, j]] & grid[i, j] > 0)
                    {
                        return false;
                    }
                    row[grid[i, j]] = true;

                    if (col[grid[j, i]] & grid[j, i] > 0)
                    {
                        return false;
                    }
                    col[grid[j, i]] = true;

                    if ((i + 3) % 3 == 0 && (j + 3) % 3 == 0)
                    {
                        bool[] sqr = new bool[10];
                        for (int m = i; m < i + 3; m++)
                        {
                            for (int n = j; n < j + 3; n++)
                            {
                                if (sqr[grid[m, n]] & grid[m, n] > 0)
                                {
                                    return false;
                                }
                                sqr[grid[m, n]] = true;
                            }
                        }
                    }

                }
            }
            return true;
        }
        */
    }
}
