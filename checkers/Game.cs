using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace checkers
{
    public class Game
    {
        private Item[] checkersList;
        private State currentState;
        private Item pickedUpItem;
        public class Item
        {
            public bool IsKing { get; set; }
            public int posX { get; set; }
            public int posY { get; set; }
            public Color Color { get; set; }
        }

        public Game()
        {
            checkersList = new Item[24]
;           currentState = State.NotStarted;
            pickedUpItem = null;
            InitializeCheckers();
        }

        private enum State
        {
            NotStarted,
            WhiteTurn,
            WhiteTurnItemPickedUp,
            BlackTurn,
            BlackTurnItemPickedUp,
            GameOver
        }

        private void InitializeCheckers()
        {
            for (int i = 0; i < 12; i++)
            {
                Item cheker = new Item();
                cheker.IsKing = false;
                cheker.Color = Color.White;

                int row = i / 4;
                int col = i % 4;

                cheker.posX = col * 50;
                cheker.posY = row * 50;

                checkersList[i] = cheker;
            }

            for (int i = 0;i < 24; i++)
            {
                Item cheker = new Item();
                cheker.IsKing = false;
                cheker.Color = Color.Black;

                int row = (i - 20) / 4;
                int col = (i - 20) % 4;
                cheker.posX = col * 50;
                cheker.posY = (7 - row) * 50;

                checkersList[i] = cheker;
            }
        }

        private Item GetCheckerAtPosition(int fromX, int fromY)
        {
            foreach (Item item in checkersList)
            {
                if (item != null && item.posX == fromX && item.posY == fromY)
                {
                    return item;
                }
            }

            return null;
        }

        private bool IsValidMove(int fromX, int fromY, int toX, int toY, Color color)
        {
            if (fromX < 0 || fromX >= 8 || fromY < 0 || fromY >= 8 || toX < 0 || toX >= 8 || toY < 0 || toY >= 8)
            {
                return false;
            }

            if (fromX == toX && fromY == toY)
            {
                return false;
            }

            Item fromPositionChecker = GetCheckerAtPosition(fromX, fromY);
            if (fromPositionChecker == null && fromPositionChecker.Color != color)
            {
                return false;
            }

            Item checkerAtPos = GetCheckerAtPosition(toX, toY);
            if (checkerAtPos != null)
            {
                return false;
            }

            if (Math.Abs(toX - fromX) != Math.Abs(toY - fromY))
            {
                return false;
            }

            if (color == Color.White && fromY > toY)
            {
                return false;
            }
            if (color == Color.Black && fromY < toY)
            {
                return false;
            }

            if (Math.Abs(toX - fromX) == 2)
            {
                int midX = (fromX + toX) / 2;
                int midY = (fromY + toY) / 2;
                Item midPiece = GetCheckerAtPosition(midX, midY);
                if (midPiece == null || midPiece.Color == color)
                {
                    return false;
                }
            }

            return true;
        }

        private void MakeMove()
        {
            switch (currentState)
            {
                case State.NotStarted:
                    break;

                case State.WhiteTurn:

                    break;
            }
        }
    }
}



