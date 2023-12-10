using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSGame.GUI.Tests.Logic {
    public class BaseGameLogicTestClass : BaseGameLogic {
        public override bool CheckForGameOver(int firstPlayerScore, int SecondPlayerScore,
            GameBoard board) {
            return false;
        }

        public string GetRandomLetterFromStringTest(string testString) {
            Random random = new Random();
            return GetRandomLetterFromString(testString, random);
        }

        public AIMove MiniMaxAlphaBetaTest(int depth, bool maximizingPlayer, int alpha, int beta,
            GameBoard gameBoard, int x = -1, int y = -1) {
            return base.MiniMaxAlphaBeta(depth, maximizingPlayer, alpha, beta, gameBoard, x, y);
        }
    }
}

