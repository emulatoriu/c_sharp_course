

using BoardGamePub.Model;
using BoardGamePub;
using BoardGamePub.Controller;

class MainClass
{
    public static void Main(String[] args)
    {
        Pub p = new Pub();        

        PubService ps = new PubService();

        Boardgame bgCard1 = p.Bgf.createBoardgame(Gametype.CARDGAME, Complexity.EASY);

        Boardgame stor1 = p.Bgf.createBoardgame(Gametype.STORYTELLING, Complexity.HARD);

        p.GService.addPlayerToGame(stor1, "Hansi");

        if(p.GService.startGame(stor1))
        {
            Console.WriteLine("Game Started");
        }
        else
        {
            Console.WriteLine("Game could not be started");
        }

        p.GService.addPlayerToGame(stor1, "Peter");
        p.GService.addPlayerToGame(stor1, "Susi");
        p.GService.addPlayerToGame(stor1, "Bibi");

        if (p.GService.startGame(stor1))
        {
            Console.WriteLine("Game Started");
        }
        else
        {
            Console.WriteLine("Game could not be started");
        }



        Boardgame stor2 = p.Bgf.createBoardgame(Gametype.STORYTELLING, Complexity.HARD);

        ps.addGameToPub(p, bgCard1);
        ps.addGameToPub(p, stor1);

        if(ps.addGameToPub(p, stor2))
        {
            Console.WriteLine("Second story game could be added");
        }
        else
        {
            Console.WriteLine("Second story game could NOT(!!!) be added");
        }

        
    }
}