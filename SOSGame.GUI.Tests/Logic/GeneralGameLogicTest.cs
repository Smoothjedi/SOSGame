using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSGame.GUI.Tests.Logic
{
    public class GeneralGameLogicTest
    {
        [Fact]
        public void CheckForGameOverDrawTest()
        {
            IGameLogic gameLogic = new GeneralGameLogic();
            var gameBoard = new GameBoard();
            gameBoard.Tiles = new GameTile[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gameBoard.Tiles[i, j] = new GameTile() { Letter = "S" };
                }
            }
            Assert.True(gameLogic.CheckForGameOver(0, 0, gameBoard));
        }

        [Fact]
        public void CheckForGameOverFalseTest()
        {
            IGameLogic gameLogic = new GeneralGameLogic();
            var gameBoard = new GameBoard();
            gameBoard.Tiles = new GameTile[10, 10];
            gameBoard.Tiles[0, 0] = new GameTile();
            for (int i = 1; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gameBoard.Tiles[i, j] = new GameTile() { Letter = "S" };
                }
            }
            Assert.False(gameLogic.CheckForGameOver(0, 0, gameBoard));
        }

    }
}
