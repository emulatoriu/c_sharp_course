using BoardGamePub.Model;

namespace BoardGamePub
{
    internal class Boardgame
    {
        public int MinPlayers { get; init; }
        public int MaxPlayers { get; init; }
        public Gametype Gt { get; init; }
        public Complexity Compl { get; init; }

        public bool Started { get; set; } = false;

        public List<String> Players { get; init; } = new List<String>();

        public Boardgame(int minPlayers, int maxPlayers, Gametype gt, Complexity compl)
        {
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            Gt = gt;
            Compl = compl;
        }
    }
}
