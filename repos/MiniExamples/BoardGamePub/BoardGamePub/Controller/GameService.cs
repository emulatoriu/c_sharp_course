using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamePub.Controller
{
    internal class GameService
    {
        public bool startGame(Boardgame bg)
        {            
            if(bg.MinPlayers <= bg.Players.Count)
            {                
                bg.Started = true;
            }

            return bg.Started;
        }

        // Could be also in Boardgame
        public bool addPlayerToGame(Boardgame bg, String player)
        {
            if(bg.MaxPlayers > bg.Players.Count)
            {
                bg.Players.Add(player);
                return true;
            }

            return false;
            
        }
    }
}
