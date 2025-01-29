using BoardGamePub.Model;

namespace BoardGamePub.Controller
{
    internal class PubService
    {
        public bool addGameToPub(Pub p, Boardgame bg)
        {
            int currentAmountOfGames = p.Games.Where(g=>g.Gt == bg.Gt).Count();
            
            if((bg.Gt == Gametype.PUZZLE && currentAmountOfGames < Pub.MAX_PUZZLES) ||
               (bg.Gt == Gametype.STORYTELLING && currentAmountOfGames < Pub.MAX_SORYTELLING) ||
               (bg.Gt == Gametype.CARDGAME && currentAmountOfGames < Pub.MAX_CARDGAME))
            {
                p.Games.Add(bg);
                return true;
            }
            return false;

        }
    }
}
