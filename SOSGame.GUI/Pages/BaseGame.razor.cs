using Microsoft.AspNetCore.Components;
using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Data.Objects;
using SOSGame.Logic;

namespace SOSGame.GUI.Pages
{
    public partial class BaseGame
    {
        protected bool FirstPlayer = true;
        protected List<string> LetterOptions = new List<string> { "S", "O" };

        [Inject]
        protected IGameBoardFactory GameBoardFactory { get; set; } = null!;

        [Inject]
        protected IBaseGameLogic BaseGameLogic { get; set; } = null!;

        protected GameBoard GameBoard { get; set; }

        protected void TileClicked(int x, int y)
        {
            var selectedGameTile = GameBoard.Tiles[x, y];
            if (!selectedGameTile.FirstPlayerOwned.HasValue)
            {
                if (FirstPlayer)
                {
                    selectedGameTile.Letter = GameBoard.FirstPlayerLetter;
                }
                else
                {
                    selectedGameTile.Letter = GameBoard.SecondPlayerLetter;
                }
                selectedGameTile.FirstPlayerOwned = FirstPlayer;
                FirstPlayer = BaseGameLogic.ChangeTurn(FirstPlayer);
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            GameBoard = GameBoardFactory.CreateDefaultGameBoard();
        }

        protected void ResetBoard(int size)
        {
            GameBoard = GameBoardFactory.CreateGameBoard(size);
            FirstPlayer = true;
        }
    }
}
