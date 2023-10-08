namespace SOSGame.GUI.Tests.Pages
{
    public partial class BaseGameTests
    {
        [Fact]
        public void TileClickedFirstPlayerSTest()
        {
            var baseGameTest = new BaseGameTest();
            baseGameTest.TileClicked(0, 1);
            Assert.True(baseGameTest.ReturnGameBoard().Tiles[0, 1].FirstPlayerOwned);
            Assert.Equal("S", baseGameTest.ReturnGameBoard().Tiles[0, 1].Letter);
            Assert.False(baseGameTest.GetFirstPlayer());
        }

        [Fact]
        public void TileClickedAlreadyOwnedTile()
        {
            var baseGameTest = new BaseGameTest();
            baseGameTest.TileClicked(0, 1);
            Assert.True(baseGameTest.ReturnGameBoard().Tiles[0, 1].FirstPlayerOwned);
            Assert.Equal("S", baseGameTest.ReturnGameBoard().Tiles[0, 1].Letter);
            Assert.False(baseGameTest.GetFirstPlayer());
            baseGameTest.SetLetter("O", 2);
            baseGameTest.TileClicked(0, 1);
            Assert.False(baseGameTest.GetFirstPlayer());
            Assert.Equal("S", baseGameTest.ReturnGameBoard().Tiles[0, 1].Letter);
        }

        [Fact]
        public void TileClickedSecondPlayerSTest()
        {
            var baseGameTest = new BaseGameTest();
            baseGameTest.TileClicked(0, 1);
            Assert.True(baseGameTest.ReturnGameBoard().Tiles[0, 1].FirstPlayerOwned);
            Assert.Equal("S", baseGameTest.ReturnGameBoard().Tiles[0, 1].Letter);
            Assert.False(baseGameTest.GetFirstPlayer());
            baseGameTest.SetLetter("O", 2);
            baseGameTest.TileClicked(0, 2);
            Assert.True(baseGameTest.GetFirstPlayer());
            Assert.Equal("O", baseGameTest.ReturnGameBoard().Tiles[0, 2].Letter);
        }

        [Fact]
        public void ResetBoardTest()
        {
            var baseGameTest = new BaseGameTest();
            baseGameTest.TileClicked(0, 1);
            Assert.True(baseGameTest.ReturnGameBoard().Tiles[0, 1].FirstPlayerOwned);
            Assert.Equal("S", baseGameTest.ReturnGameBoard().Tiles[0, 1].Letter);
            Assert.False(baseGameTest.GetFirstPlayer());
            baseGameTest.SetLetter("O", 2);
            baseGameTest.TileClicked(0, 2);
            Assert.True(baseGameTest.GetFirstPlayer());
            Assert.Equal("O", baseGameTest.ReturnGameBoard().Tiles[0, 2].Letter);

            baseGameTest.ResetBoard(4);
            Assert.Equal(4, baseGameTest.ReturnGameBoard().Size);
            Assert.True(baseGameTest.GetFirstPlayer());
            Assert.True(string.IsNullOrEmpty(baseGameTest.ReturnGameBoard().Tiles[0, 1].Letter));
            Assert.Null(baseGameTest.ReturnGameBoard().Tiles[0, 1].FirstPlayerOwned);
            Assert.Null(baseGameTest.ReturnGameBoard().Tiles[0, 2].FirstPlayerOwned);
        }
    }
}
