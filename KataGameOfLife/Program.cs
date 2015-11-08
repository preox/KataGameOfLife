using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Very, very simple tester. Mostly for the sake of visualization. 
             * 
             */
            Console.WriteLine("===================");

            LifeGrid grid = new LifeGrid(new char[,] {    
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '.', '.', '.', '*', '.', '.', '.'  }, 
                    { '.', '.', '.', '*', '*', '.', '.', '.'  },
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }
                    });

            GameOfLife test = new GameOfLife(grid);

            test.printGrid();
            test.produceNextGeneration();
            test.printGrid();

            Console.WriteLine("===================");
            
            grid = new LifeGrid(new char[,] {    
                { '*', '.', '.', '.'  }, 
                { '.', '.', '.', '.'  }, 
                { '.', '*', '.', '.'  }, 
                { '.', '.', '.', '.'  }
            }) ;

            test.GameGrid = grid;

            test.printGrid();
            test.produceNextGeneration();
            test.printGrid();

            Console.WriteLine("===================");

            grid = new LifeGrid(new char[,] {    
                { '*', '*', '.', '.' , '.' }, 
                { '.', '.', '.', '.' , '.' }, 
                { '.', '*', '.', '.' , '.' }
            });

            test.GameGrid = grid;
            test.printGrid();
            test.produceNextGeneration();
            test.printGrid();
            
        }
    }
}
