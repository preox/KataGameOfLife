using System;

namespace KataGameOfLife
{
    public class LifeGrid
    {

        private char[,] grid;

        public char[,] Grid
        {
            get { return grid; }
            set { grid = value; }
        }


        public LifeGrid(char[,] LifeGrid)
        {
            this.grid = LifeGrid;
        }


        // check if point is alive. 
        public bool isCellAlive(int yVal, int xVal)
        {
            if (!isCellCoordinateValid(yVal, xVal))
                return false;

            if (grid[yVal, xVal].Equals('*'))
                return true;
            else
                return false;
        }

        // Kill or become living. It's all relative. Might as well just toggle. 
        public void toggleLifeOfCell(int yVal, int xVal)
        {
            if (!isCellCoordinateValid(yVal, xVal))
                return;

            if (grid[yVal, xVal].Equals('*'))
                grid[yVal, xVal] = '.';
            else
                grid[yVal, xVal] = '*';
        }

        // Used for sanity checks. 
        public bool isCellCoordinateValid(int yVal, int xVal)
        {
            if (xVal >= grid.GetLength(1) || xVal < 0)
                return false;
            else if (yVal >= grid.GetLength(0) || yVal < 0)
                return false;
            else
                return true;
        }

        public bool compareGrid(LifeGrid inputGrid)
        {
            for (int yVal = 0; yVal < Grid.GetLength(0); yVal++)
            {
                for (int xVal = 0; xVal < Grid.GetLength(1); xVal++)
                {
                    if (inputGrid.Grid[yVal, xVal] != this.grid[yVal, xVal])
                        return false;

                }
            }
            return true;

        }

    } // class
} // namespace