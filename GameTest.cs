using System;
using _2048;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2048Test
{
    [TestClass]
    public class GameTest
    {
        private Game game = new Game();
        [TestMethod]
        public void TestMoveDown()
        {
            int[,] testTiles = new int[4, 4];
            testTiles[0, 0] = 2;
            testTiles[0, 1] = 0;
            testTiles[0, 2] = 0;
            testTiles[0, 3] = 0;
            testTiles[1, 0] = 0;
            testTiles[1, 1] = 2;
            testTiles[1, 2] = 0;
            testTiles[1, 3] = 0;
            testTiles[2, 0] = 0;
            testTiles[2, 1] = 0;
            testTiles[2, 2] = 2;
            testTiles[2, 3] = 0;
            testTiles[3, 0] = 0;
            testTiles[3, 1] = 0;
            testTiles[3, 2] = 0;
            testTiles[3, 3] = 2;
            MoveResponse response = game.RegisterDirection(Direction.DOWN);
            Assert.AreEqual(MoveResponse.CAN_MOVE, response);
            Assert.AreEqual(2,testTiles[0,3]);
            Assert.AreEqual(2,testTiles[1,3]);
            Assert.AreEqual(2,testTiles[2,3]);
            Assert.AreEqual(2,testTiles[3,3]);
            
        }
        /**
        [TestMethod]
        public void TestMoveDown()
        {
            int[,] testTiles = new int[4, 4];
            testTiles[0, 0] = 2;
            testTiles[0, 1] = 0;
            testTiles[0, 2] = 2;
            testTiles[0, 3] = 0;
            testTiles[1, 0] = 2;
            testTiles[1, 1] = 2;
            testTiles[1, 2] = 2;
            testTiles[1, 3] = 2;
            testTiles[2, 0] = 2;
            testTiles[2, 1] = 2;
            testTiles[2, 2] = 2;
            testTiles[2, 3] = 2;
            testTiles[3, 0] = 2;
            testTiles[3, 1] = 2;
            testTiles[3, 2] = 0;
            testTiles[3, 3] = 0;
            game.Tiles = testTiles;
            MoveResponse response = game.RegisterDirection(_2048.Direction.DOWN);
            testTiles = game.Tiles;
            Assert.AreEqual(testTiles[0, 0], 2);
            Assert.AreEqual(testTiles[0, 1], 2); 
            Assert.AreEqual(testTiles[0, 2], 2);
            Assert.AreEqual(testTiles[0, 3], 2);
            Assert.AreEqual(testTiles[1, 0], 2);
            Assert.AreEqual(testTiles[1, 1], 2);
            Assert.AreEqual(testTiles[1, 2], 2);
            Assert.AreEqual(testTiles[1, 3], 2);
            Assert.AreEqual(testTiles[2, 0], 2);
            Assert.AreEqual(testTiles[2, 1], 2);
            Assert.AreEqual(testTiles[2, 2], 2);
            Assert.AreEqual(testTiles[2, 3], 2);
            Assert.AreEqual(testTiles[3, 0], 2);
            Assert.AreEqual(testTiles[3, 1], 2);
            Assert.AreEqual(testTiles[3, 2], 2);
            Assert.AreEqual(testTiles[3, 3], 2);
        }

        [TestMethod]
        public void TestMoveUp()
        {
            int[,] testTiles = new int[4, 4];
            testTiles[0, 0] = 0;
            testTiles[0, 1] = 0;
            testTiles[0, 2] = 0;
            testTiles[0, 3] = 0;
            testTiles[1, 0] = 0;
            testTiles[1, 1] = 0;
            testTiles[1, 2] = 0;
            testTiles[1, 3] = 0;
            testTiles[2, 0] = 0;
            testTiles[2, 1] = 0;
            testTiles[2, 2] = 0;
            testTiles[2, 3] = 0;
            testTiles[3, 0] = 0;
            testTiles[3, 1] = 0;
            testTiles[3, 2] = 0;
            testTiles[3, 3] = 0;


            game.Tiles = testTiles;
            MoveResponse response = game.RegisterDirection(_2048.Direction.DOWN);
            testTiles = game.Tiles;
            Assert.AreEqual(testTiles[3, 3], 2);
            Assert.AreEqual(testTiles[2, 3], 2);
            Assert.AreEqual(testTiles[2, 3], 2);
        }

        [TestMethod]
        public void TestMoveLeft()
        {
            int[,] testTiles = new int[4, 4];
            testTiles[3, 3] = 2;
            testTiles[2, 3] = 2;
            testTiles[2, 0] = 2;
            game.Tiles = testTiles;
            MoveResponse response = game.RegisterDirection(_2048.Direction.DOWN);
            testTiles = game.Tiles;
            Assert.AreEqual(testTiles[3, 3], 2);
            Assert.AreEqual(testTiles[2, 3], 2);
            Assert.AreEqual(testTiles[2, 3], 2);
        }

        [TestMethod]
        public void TestMoveRight()
        {
            int[,] testTiles = new int[4, 4];
            testTiles[3, 3] = 2;
            testTiles[2, 3] = 2;
            testTiles[2, 0] = 2;
            game.Tiles = testTiles;
            MoveResponse response = game.RegisterDirection(_2048.Direction.DOWN);
            testTiles = game.Tiles;
            Assert.AreEqual(testTiles[3, 3], 2);
            Assert.AreEqual(testTiles[2, 3], 2);
            Assert.AreEqual(testTiles[2, 3], 2);
        }
    **/
    }
}
