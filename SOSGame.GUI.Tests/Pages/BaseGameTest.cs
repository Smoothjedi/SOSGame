﻿using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Pages;
using SOSGame.GUI.Logic;
using Microsoft.AspNetCore.Components.Web;
using Blazor.Extensions;

namespace SOSGame.GUI.Tests.Pages {
    public partial class BaseGameTests {
        // Mock 
        public class BaseGameTest : BaseGame {
            public BaseGameTest(IGameBoardFactory factory, IGameLogic logic) {
                base.GameBoardFactory = factory;
                base.GameLogic = logic;
                GameBoard = GameBoardFactory.CreateDefaultGameBoard();
            }
            public async void ModifyCanvasTest(Move move) {
                await base.ModifyCanvas(move);
            }
            public void SetCanvasLogic(ICanvasLogic canvasLogic) {
                base.CanvasLogic = canvasLogic;
            }
            protected override void StartNewGame(string size) {
                throw new NotImplementedException();
            }
            public void SetGameBoard(GameBoard gameBoard) {
                base.GameBoard = gameBoard;
            }
            public void SetGameOver(bool gameOver) {
                base.GameOver = gameOver;
            }
            protected override void StartNewGame(string size, string moves) {
                throw new NotImplementedException();
            }
            protected override Task LogGameStartInformation() {
                throw new NotImplementedException();
            }
            public void SetLogging(IGameLogger logging) {
                GameLogger = logging;
            }
        }
    }
}