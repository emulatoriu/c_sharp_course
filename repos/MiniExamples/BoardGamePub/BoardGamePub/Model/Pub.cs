using BoardGamePub.Controller;

namespace BoardGamePub.Model
{
    internal class Pub
    {
        public const int MAX_PUZZLES = 5;
        public const int MAX_SORYTELLING = 1;
        public const int MAX_CARDGAME = 2;

        public List<Boardgame> Games { get; init; } = new List<Boardgame>();

        public GameService GService { get; init; } = new GameService();

        public BoardgameFactory Bgf { get; init; } = new();


    }
}
