using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataGameOfLife;

namespace KataGameOfLifeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        LifeGrid sut = new LifeGrid(new char[,] {  
                { '*', '.', '.', '.'  }, 
                { '.', '.', '.', '.'  }, 
                { '.', '.', '.', '.'  }, 
                { '.', '.', '.', '.'  }
            });

        [TestMethod]
        public void TestisCellCoordinateValid()
        {

            for (int yVal = 0; yVal < sut.Grid.GetLength(0); yVal++)
            {
                for (int xVal = 0; xVal < sut.Grid.GetLength(1); xVal++)
                {
                    var result = sut.isCellCoordinateValid(yVal, xVal);
                    Assert.AreEqual(true, sut.isCellCoordinateValid(yVal, xVal));
                }
            }
            // Somewhat Crude
            Assert.AreEqual(false, sut.isCellCoordinateValid(-1, 1));
            Assert.AreEqual(false, sut.isCellCoordinateValid(-1, -1));
            Assert.AreEqual(false, sut.isCellCoordinateValid(1, -1));
            Assert.AreEqual(false, sut.isCellCoordinateValid(sut.Grid.GetLength(0) +1 , 1));
            Assert.AreEqual(false, sut.isCellCoordinateValid(1, sut.Grid.GetLength(0)+1));
        }


        [TestMethod]
        public void TestisCellAlive()
        {
            Assert.AreEqual(true, sut.isCellAlive(0, 0 ));
            Assert.AreEqual(false, sut.isCellAlive(1, 1));
            Assert.AreEqual(false, sut.isCellAlive(3, 1));
            Assert.AreEqual(false, sut.isCellAlive(-1, 3));
        }


        [TestMethod]
        public void TesttoggleLifeOfCell()
        {
            sut.toggleLifeOfCell(0, 0);
            Assert.AreEqual('.', sut.Grid[0, 0]);
            sut.toggleLifeOfCell(0, 0);
            Assert.AreEqual('*', sut.Grid[0, 0]);
        }

        [TestMethod]
        public void TestOutput1()
        {
            // Test input and output as given in task text
            GameOfLife localSut = new GameOfLife(new LifeGrid(new char[,] {    
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '.', '.', '.', '*', '.', '.', '.'  }, 
                    { '.', '.', '.', '*', '*', '.', '.', '.'  },
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }
                    }));

            LifeGrid expectedResult = new LifeGrid(  new char[,] {  
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '.', '.', '*', '*', '.', '.', '.'  }, 
                    { '.', '.', '.', '*', '*', '.', '.', '.'  },
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }
                    });

            localSut.produceNextGeneration();

            Assert.IsTrue(localSut.GameGrid.compareGrid(expectedResult));

        }
        
        [TestMethod]
        public void TestOutput2()
        {
            // Testing a few more patterns and expected results i found on the intertube. 
            GameOfLife localSut = new GameOfLife(new LifeGrid(new char[,] {    
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '*', '.', '.', '.', '.', '.', '.'  }, 
                    { '*', '*', '*', '.', '.', '.', '.', '.'  },
                    { '.', '*', '.', '.', '.', '.', '.', '.'  },
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '.', '.', '.', '*', '*', '.', '.'  }, 
                    { '.', '.', '.', '.', '*', '*', '.', '.'  },
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }
                    }));

            LifeGrid expectedResult = new LifeGrid(  new char[,] {    
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }, 
                    { '*', '*', '*', '.', '.', '.', '.', '.'  }, 
                    { '*', '.', '*', '.', '.', '.', '.', '.'  },
                    { '*', '*', '*', '.', '.', '.', '.', '.'  },
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '.', '.', '.', '*', '*', '.', '.'  }, 
                    { '.', '.', '.', '.', '*', '*', '.', '.'  },
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }
                    });

            localSut.produceNextGeneration();

            Assert.IsTrue(localSut.GameGrid.compareGrid(expectedResult));


        }


        [TestMethod]
        public void TestOutput3()
        {
            GameOfLife localSut = new GameOfLife(new LifeGrid(new char[,] { 
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }, 
                    { '*', '*', '*', '.', '.', '.', '.', '.'  }, 
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '.', '.', '.', '*', '*', '*', '.'  }, 
                    { '.', '.', '.', '*', '*', '*', '.', '.'  }, 
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }
                    }));

            LifeGrid expectedResult = new LifeGrid(new char[,] {   
                    { '.', '*', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '*', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '*', '.', '.', '.', '.', '.', '.'  }, 
                    { '.', '.', '.', '.', '.', '*', '.', '.'  }, 
                    { '.', '.', '.', '*', '.', '.', '*', '.'  }, 
                    { '.', '.', '.', '*', '.', '.', '*', '.'  }, 
                    { '.', '.', '.', '.', '*', '.', '.', '.'  }, 
                    { '.', '.', '.', '.', '.', '.', '.', '.'  }
                    });

            localSut.produceNextGeneration();

            Assert.IsTrue(localSut.GameGrid.compareGrid(expectedResult));


        }
        

    }
}
