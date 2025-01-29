using BoardGamePub.Model;

namespace BoardGamePub.Controller
{
    internal class BoardgameFactory
    {
        public Boardgame createBoardgame(Gametype gt, Complexity c)
        {
            if(gt == Gametype.PUZZLE)
            {
                return new Boardgame(1, 3, gt, c);
            }
            else if(gt == Gametype.CARDGAME)
            {
                return new Boardgame(3, 9, gt, c);
            }

            return new Boardgame(4, 15, gt, c);
        }
    }
}
