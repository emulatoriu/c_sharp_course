using System;

namespace Monopoly
{
    public class Monopoly
    {
        //const int limitPlayerPos = 6;
        //static Spieler sMatthias;
        //static Spieler sYa_Sin;
        //static Spieler sThomas;
        //static Spieler sJakob;
        //static Spieler sDanielT;
        //static Spieler sDanielR;
        //static Spieler sEmad;

        //static Feld fLos;
        //static Feld fFeld2;
        //static Feld fFeld3;
        //static Feld fFeld4;
        //static Feld fFeld5;

        //#region doPlayerMove

        //private static void doPlayerMove(Spieler spieler, int wuerfelErgebnis, ref int aktuellerUser)
        //{
            
        //    if (spieler.getIsActive() == false)
        //    {
        //        aktuellerUser++;
        //    }
        //    else // Ziehe Felder
        //    {
        //        for (int i = 0; i < wuerfelErgebnis; i++)
        //        {
        //            //Feld currentFeldOfMatthias = sMatthias.getCurrentFeld();
        //            //Feld nextFeldOfMatthias = currentFeldOfMatthias.getNext();

        //            spieler.setSpielerFeld(spieler.getCurrentFeld().getNext());
        //        }
        //        Console.WriteLine(spieler.getName() + " ist jetzt dran und muss " + wuerfelErgebnis + " Felder ziehen. " + aktuellerUser);
        //        Console.WriteLine(spieler.getName() + " steht jetzt auf Feld " + spieler.getCurrentFeld().getFeldNummer());
        //        Console.WriteLine();
        //        spieler.getCurrentFeld().printFeldInfo();
        //        Console.WriteLine();
        //        Console.WriteLine(spieler.getName() + ", dein Guthaben beträgt " + spieler.getCurrentMoney());

        //        int currentMoney = spieler.getCurrentMoney();

        //        if (spieler.getCurrentFeld().getKaufenMoeglich() == true)
        //        {
        //            // TODO - überprüfe ob das Feld auf dem du gelandet bist einem Spieler gehört, der nicht mehr aktiv ist
        //            // wenn ja, dann setz den besitzer des Feldes auf null

        //            if (spieler.getCurrentFeld().getBesitzer() == null)
        //            {
        //                int preisVomFeld = spieler.getCurrentFeld().getPreis();
        //                // Überprüfen ob der Spieler das Feld kaufen kann
        //                if (preisVomFeld > spieler.getCurrentMoney())
        //                {
        //                    Console.WriteLine("Leider übersteigt der Preis des Feldes dein Guthaben von " + spieler.getCurrentMoney() + "!");
        //                }
        //                else
        //                {
        //                    // Feld ist noch zu haben
        //                    Console.WriteLine(spieler.getName() + ", möchtest du das Feld kaufen? Schreib ja oder nein.");
        //                    string eingabe = Console.ReadLine();

        //                    if (eingabe.ToLower().Equals("ja") == true)
        //                    {
        //                        // Gib Geld aus und speichere den Spieler im Feld

        //                        //int newCurrentMoney = currentMoney - preisVomFeld;
        //                        //spieler.setCurrentMoney(newCurrentMoney);
        //                        spieler.modifyMoney(-preisVomFeld); // TODO: Geld muss an die Bank zurück gehen

        //                        spieler.getCurrentFeld().setBesitzer(spieler);                                
        //                    }

        //                }
        //            }
        //            else
        //            {
        //                // TODO: check if field is my own - if not then dont do anything
        //                Spieler besitzer = spieler.getCurrentFeld().getBesitzer();
        //                int mietPreis = spieler.getCurrentFeld().getMietPreis();
                        
        //                int paidMoney; // TODO: Brauchen wir das?

        //                bool bFullAmountPaied = spieler.tryPay(besitzer, mietPreis, out paidMoney);

        //                // is still active?
        //                if (spieler.getIsActive() == true)
        //                {
        //                    Console.WriteLine("Der neue Geldstand von " + spieler.getName() + " = " + spieler.getCurrentMoney());
        //                }
        //                else
        //                {
        //                    // TODO: Here I know that player is out - static counter to check if there is more than one player left
        //                    Console.WriteLine("Spieler " + spieler.getId() + " mit dem Namen " + spieler.getName() + " ist leider raus!");
        //                }

        //                Console.WriteLine(besitzer.getName() + " hat " + paidMoney + " erhalten. Der neue Geldstand von " + besitzer.getName() + " = " + besitzer.getCurrentMoney());
        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
            
        //}
        //#endregion

        //#region init
        //private static void initSpieler()
        //{
            
        //    sMatthias = new Spieler(0, "Matthias Lochner");
        //    sMatthias.setSpielerFeld(fLos);
        //    sYa_Sin = new Spieler(1, "Ya-Sin Trauner");
        //    sYa_Sin.setSpielerFeld(fLos);
        //    sThomas = new Spieler(2, "Thomas Winklehner");
        //    sThomas.setSpielerFeld(fLos);
        //    sJakob = new Spieler(3, "Jakob Zink");
        //    sJakob.setSpielerFeld(fLos);
        //    sDanielT = new Spieler(4, "Daniel Tuma");
        //    sDanielT.setSpielerFeld(fLos);
        //    sDanielR = new Spieler(5, "Daniel Rabenreither");
        //    sDanielR.setSpielerFeld(fLos);
        //    sEmad = new Spieler(6, "Emad Easa");
        //    sEmad.setSpielerFeld(fLos);

        //    sMatthias.setNextSpieler(sYa_Sin);
        //    sYa_Sin.setNextSpieler(sThomas);
        //    sThomas.setNextSpieler(sJakob);            
        //    sJakob.setNextSpieler(sDanielT);
        //    sDanielT.setNextSpieler(sDanielR);
        //    sDanielR.setNextSpieler(sEmad);
        //    sEmad.setNextSpieler(sMatthias);

        //}

        //private static void initFelder()
        //{

        //    fLos = new Feld(1, 0, 0);
        //    fLos.setKaufenMoeglich(false);
        //    fFeld2 = new Feld(2, 40, 10);
        //    fFeld3 = new Feld(3, 60, 50);
        //    fFeld4 = new Feld(4, 80, 20);
        //    fFeld5 = new Feld(5, 100,25);

        //    fLos.setNextFeld(fFeld2);
        //    fFeld2.setNextFeld(fFeld3);
        //    fFeld3.setNextFeld(fFeld4);
        //    fFeld4.setNextFeld(fFeld5);
        //    fFeld5.setNextFeld(fLos);      
            
        //    //TODO GEFÄNGNISFELD

        //}
        //#endregion

        public static void Main(string[] arguments)
        {
            // init game
            Spielplan.initFelder();
            Spielplan.initSpieler();
            //Spielplan.showActivePlayers();
            Spielplan.starteSpiel();

        }
    }
}
