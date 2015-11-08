using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataGameOfLife
{
    public class GameOfLife
    {

        private int[,] neighbours;

        private LifeGrid localGrid;

        public LifeGrid GameGrid
        {
            get { return localGrid; }
            set { localGrid = value; }
        }


        // Constructor
        public GameOfLife(LifeGrid grid)
        {
            this.localGrid = grid;
        }


        /*
         *the Next generation 
         * basically split into two separate operations: 
         * First: calculate, for each point in grid, amount of alive neighbours. 
         * Secondly: iterate over said list and apply the rules given in the 
         * task
         * 
         */
        public void produceNextGeneration()
        {
            this.calcNeighbours();
            for (int yVal = 0; yVal < localGrid.Grid.GetLength(0); yVal++)
            {
                for (int xVal = 0; xVal < localGrid.Grid.GetLength(1); xVal++)
                {
                    if (localGrid.isCellAlive(yVal, xVal))
                    {
                        //  1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
                        //  2. Any live cell with more than three live neighbours dies, as if by overcrowding.
                        if (neighbours[yVal, xVal] > 3 || neighbours[yVal, xVal] < 2)
                            localGrid.toggleLifeOfCell(yVal, xVal);
                        // 3. Any live cell with two or three live neighbours lives on to the next generation
                    }
                    else
                    {
                        //4. Any dead cell with exactly three live neighbours becomes a live cell.
                        if (neighbours[yVal, xVal] == 3)
                            localGrid.toggleLifeOfCell(yVal, xVal);
                    }
                }
            }
        }

        // Calculates, for each point, the number of (alive) neighbours. 
        private void calcNeighbours()
        {
            neighbours = new int[localGrid.Grid.GetLength(0), localGrid.Grid.GetLength(1)];
            for (int yVal = 0; yVal < localGrid.Grid.GetLength(0); yVal++)
            {
                for (int xVal = 0; xVal < localGrid.Grid.GetLength(1); xVal++)
                {
                    int neighbourCounter = 0;
                    // Okay. Time to check in all directions. 
                    // start by finding start and end checkpoints. 
                    int startX, startY, stopX, stopY;

                    // X vals. Find edges. 
                    if (xVal == 0)
                        startX = 0;
                    else
                        startX = xVal - 1;

                    if (xVal == localGrid.Grid.GetLength(1) - 1)
                        stopX = localGrid.Grid.GetLength(1) - 1;
                    else
                        stopX = xVal + 1;

                    // Y vals. Find edges. 
                    if (yVal == 0)
                        startY = 0;
                    else
                        startY = yVal - 1;

                    if (yVal == localGrid.Grid.GetLength(0) - 1)
                        stopY = localGrid.Grid.GetLength(0) - 1;
                    else
                        stopY = yVal + 1;

                    // Now we can do actual neighbour count. Diddly! 
                    for (int i = startY; i <= stopY; i++)
                    {
                        for (int j = startX; j <= stopX; j++)
                        {
                            if (j == xVal && i == yVal) // Skip "own cell"
                                continue;
                            if (localGrid.Grid[i, j].Equals('*'))
                                neighbourCounter++;
                        }
                    }
                    neighbours[yVal, xVal] = neighbourCounter;
                }
            }
        }


        #region Output to screen
        /*
         * Considered trying to make this more genereic and pretty for both grids, 
         * but didn't have the time really. And I simply wanted 1st iteration to work
         */
        public void printGrid()
        {
            Console.WriteLine("{0} {1}", localGrid.Grid.GetLength(0), localGrid.Grid.GetLength(1));
            for (int yVal = 0; yVal < localGrid.Grid.GetLength(0); yVal++)
            {
                for (int xVal = 0; xVal < localGrid.Grid.GetLength(1); xVal++)
                {
                    Console.Write("{0}", localGrid.Grid[yVal, xVal]);
                }
                Console.Write("\n");
            }
        }

        public void printNeighbours()
        {
            Console.WriteLine("{0} {1}", neighbours.GetLength(0), neighbours.GetLength(1));
            for (int yVal = 0; yVal < neighbours.GetLength(0); yVal++)
            {
                for (int xVal = 0; xVal < neighbours.GetLength(1); xVal++)
                {
                    if (localGrid.isCellAlive(yVal, xVal))
                        Console.Write("*");
                    else
                        Console.Write("{0}", neighbours[yVal, xVal]);
                }
                Console.Write("\n");
            }
        }
        #endregion

    }
}
