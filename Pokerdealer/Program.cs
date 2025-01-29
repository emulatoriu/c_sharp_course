/*
 * Allgemeine Ideen:
 * Dealer - der hat karten - 52 Stück 
 * max 7 Spieler
 * erste runde - jeder bekommt 3 Karten
 * 
 * Karten - eigene Klasse: Farbe, Wertigkeit
 * Dealer:
 * Liste mit Kartenobjekten, shuffle Funktion für die Liste mit Karten, Funktion austeilen - dafür brauchen wir Spieler, die 3 Karten halten können
 * Man braucht eine Kopie des Kartendecks (der Liste - static). Wenn Karten ausgeteilt werden, werden diese vom Deck gelöscht und beim Spieler hinzugefügt.
 * Dealer braucht auch eine Liste aller Spieler (Bei 5 Spielern überprüfen ob jede 5.Karte die Gleiche ist)
 *
 * 
 * Spieler:
 * Spieler braucht ein Konto. Spieler braucht einen Status (dabei oder nicht). Spieler braucht Liste mit seinen Karten (2 Listen, verdeckt und nicht verdeckt)
 * Funktionen: bet, fold, setzeBlinds
 * 
 * 
 * 
 * 
 * 1. Karten mischen
 * 2. Karten austeilen
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * */

namespace Pokerdealer;
class Program
{

    private const int MAX_KARTEN = 7; // stud games

    public static void Main(string[] args)
    {
        for (int j = 0; j < 100000; j++)
        {
            Player player1 = new Player(200);
            Player player2 = new Player(300);

            List<Player> playerList = new List<Player>();
            playerList.Add(player1);
            playerList.Add(player2);

            Dealer dealerd = new Dealer();

            CardDeck cardDeck = new CardDeck();

            List<Cards> shuffeledCards = cardDeck.shuffleMyDeck();


            //int runde = 1;

            //while(true)
            //{
            //    switch(runde % MAX_KARTEN)
            //    {
            //        case 0:
            //            //shuffel cards
            //            break;
            //        case 1:
            //        case 2:
            //            foreach (Player p in playerList)
            //            {
            //                p.AddCardHidden(shuffeledCards.First());
            //                shuffeledCards.Remove(shuffeledCards.First());
            //            }
            //            runde++;
            //            break;
            //        case 3:
            //            foreach (Player p in playerList)
            //            {
            //                p.AddCardVisible(shuffeledCards.First());
            //                shuffeledCards.Remove(shuffeledCards.First());
            //            }
            //            runde++;
            //            break;
            //        case 4:
            //        case 5:
            //        case 6:
            //            foreach (Player p in playerList)
            //            {
            //                p.AddCardVisible(shuffeledCards.First());
            //                shuffeledCards.Remove(shuffeledCards.First());
            //            }
            //            //Setzrunde
            //            runde++;
            //            break;
            //        case 7:
            //            foreach (Player p in playerList)
            //            {
            //                p.
            //                p.AddCardHidden(shuffeledCards.First());
            //                shuffeledCards.Remove(shuffeledCards.First());
            //            }
            //            //Setzrunde
            //            runde++;
            //            break;
            //        default:
            //            break;

            //    }


            //}



        
            for (int i = 0; i < 2; i++)
            {

                foreach (Player p in playerList)
                {
                    p.AddCardHidden(shuffeledCards.First());
                    shuffeledCards.Remove(shuffeledCards.First());
                }
            }
            foreach (Player p in playerList)
            {
                p.AddCardVisible(shuffeledCards.First());
                shuffeledCards.Remove(shuffeledCards.First());
            }            

            //jeder spieler hat 3 Karten
            List<Cards> compareHand;

            bool areCardsEqual = true;
            foreach (Player p in playerList)
            {
                compareHand = new List<Cards>();
                compareHand.AddRange(p.getCardHidden());
                compareHand.AddRange(p.getCardVisible());

                if (compareHand[0].getCardValue() != compareHand[1].getCardValue() || compareHand[0].getCardValue() != compareHand[2].getCardValue() || compareHand[1].getCardValue() != compareHand[2].getCardValue())
                //if(compareHand.Distinct().Count() == 2)
                {
                    areCardsEqual = false;
                    break;
                }
                else
                {
                    //Console.ReadLine();
                    Console.WriteLine("Trilling gefunden!");
                    //Console.ReadLine();
                    
                }
            }

            //foreach (Player p in playerList)
            //{

            //    Console.WriteLine(p.getPlayerCards());
            //}

            if (areCardsEqual)
            {
                Console.WriteLine("Jeder startet mit einem Drilling.");                
                break;
            }

        }

    }

}
