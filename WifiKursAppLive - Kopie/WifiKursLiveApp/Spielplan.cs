using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Spielplan
    {
        public static List<Option> options;
        // initialisiere Spiel
        public const int startBetrag = 200;
        public const int losGeld = 20;
        //public const int genauAufLosMultiplikator = 2;
        
        private static int iWuerfelRunden = 0; // zählt die Anzahl der Runden für die Statistik
        private static int anzahlZuege = 0; // zählt die Anzahl an Zügen für die Statistik

        private const int ID_LOS = 1;
        private const int ID_FIRST_PLAYER = 0;

        private static int idCounter;

        const int limitPlayerPos = 6;
        static Spieler sMatthias;
        static Spieler sYa_Sin;
        static Spieler sThomas;
        static Spieler sJakob;
        static Spieler sDanielT;
        static Spieler sDanielR;
        static Spieler sEmad;

        static Bank bank;

        static Feld fLos;
        static Feld fFeld2;
        static Feld fFeld3;
        static Feld fFeld4;
        static Feld fFeld5;

        static Spieler[] meinSpielerArray;

        public static void erhoeheZuege()
        {
            anzahlZuege++;
        }

        // gib zurück wie oft gewürfelt wurde
        public static int getAnzahlZuege()
        {
            return anzahlZuege;
        }

        // wie viele würfelrunden hat es gegeben
        public static void erhoeheRunde()
        {
            iWuerfelRunden++;
        }

        public static int wieVieleRunden()
        {
            return iWuerfelRunden;
        }

        #region init
        public static void initSpieler()
        {
            int iSpielerID = ID_FIRST_PLAYER;
            sMatthias = new Spieler(ref iSpielerID, "Matthias Lochner", startBetrag);            
            sMatthias.setSpielerFeld(fLos);
            sYa_Sin = new Spieler(ref iSpielerID, "Ya-Sin Trauner", startBetrag);
            sYa_Sin.setSpielerFeld(fLos);
            sThomas = new Spieler(ref iSpielerID, "Thomas Winklehner", startBetrag);
            sThomas.setSpielerFeld(fLos);
            sJakob = new Spieler(ref iSpielerID, "Jakob Zink", startBetrag);
            sJakob.setSpielerFeld(fLos);
            sDanielT = new Spieler(ref iSpielerID, "Daniel Tuma", startBetrag);
            sDanielT.setSpielerFeld(fLos);
            sDanielR = new Spieler(ref iSpielerID, "Daniel Rabenreither", startBetrag);
            sDanielR.setSpielerFeld(fLos);
            sEmad = new Spieler(ref iSpielerID, "Emad Easa", startBetrag);
            sEmad.setSpielerFeld(fLos);

            sMatthias.setNextSpieler(sYa_Sin);
            sYa_Sin.setNextSpieler(sThomas);
            sThomas.setNextSpieler(sJakob);
            sJakob.setNextSpieler(sDanielT);
            sDanielT.setNextSpieler(sDanielR);
            sDanielR.setNextSpieler(sEmad);
            sEmad.setNextSpieler(sMatthias);

            meinSpielerArray = new Spieler[7];

            meinSpielerArray[sMatthias.getId()] = sMatthias;
            meinSpielerArray[sYa_Sin.getId()] = sYa_Sin;
            meinSpielerArray[sThomas.getId()] = sThomas;
            meinSpielerArray[sJakob.getId()] = sJakob;
            meinSpielerArray[sDanielT.getId()] = sDanielT;
            meinSpielerArray[sDanielR.getId()] = sDanielR;
            meinSpielerArray[sEmad.getId()] = sEmad;

            bank = new Bank(5000);

        }

        public static void initFelder()
        {
            idCounter = ID_LOS;
            fLos = new Feld(0, 0, ref idCounter);
            fLos.setKaufenMoeglich(false);
            fFeld2 = new Feld(40, 10, ref idCounter);
            fFeld3 = new Feld(60, 50, ref idCounter);
            fFeld4 = new Feld(80, 20, ref idCounter);
            fFeld5 = new Feld(100, 25, ref idCounter);

            fLos.setNextFeld(fFeld2);
            fFeld2.setNextFeld(fFeld3);
            fFeld3.setNextFeld(fFeld4);
            fFeld4.setNextFeld(fFeld5);
            fFeld5.setNextFeld(fLos);            

            //TODO GEFÄNGNISFELD

        }
        #endregion

        private static void playerExit(Spieler spieler, Spieler besitzer)
        {            
            spieler.payToAccount(besitzer, spieler.getBalance());            
            playerExit(spieler);

        }

        private static void playerExit(Spieler spieler)
        {
            spieler.setPlayerActive(false);
            Console.WriteLine(spieler.getName() + ", du bist leider raus!");
            Console.WriteLine("Hier ist deine Spielstatistik: ");
            spieler.showSpielerStatistik();
            //TODO: spieler.releaseProperty() and money if he has;
        }

        

        #region doPlayerMove

        private static void doPlayerMove(Spieler spieler, int wuerfelErgebnis, ref int aktuellerUser)
        {

            if (spieler.getIsActive() == false)
            {
                aktuellerUser++;
            }
            else // Ziehe Felder
            {
                spieler.addFeldCount(wuerfelErgebnis);
                for (int i = 0; i < wuerfelErgebnis; i++)
                {
                    //Feld currentFeldOfMatthias = sMatthias.getCurrentFeld();
                    //Feld nextFeldOfMatthias = currentFeldOfMatthias.getNext();                    
                    spieler.setSpielerFeld(spieler.getCurrentFeld().getNext());                    
                    if (spieler.getCurrentFeld().getFeldNummer() == Spielplan.ID_LOS)
                    {
                        spieler.increaseLosCounter();                        
                        if (i == wuerfelErgebnis - 1)
                        {
                            //spieler.getAndMakePayment(losGeld * genauAufLosMultiplikator);
                            int iLosMoneyPaid = bank.payLosMoney(spieler, true);
                            Console.WriteLine("Hey, du bist genau auf Los gekommen und erhälst " + iLosMoneyPaid + " Euro.");
                        }
                        else
                        {
                            int iLosMoneyPaid = bank.payLosMoney(spieler, false);
                            Console.WriteLine("Hey, du bist über Los gekommen und erhälst " + iLosMoneyPaid + " Euro.");
                        }
                    }


                }
                Console.WriteLine(spieler.getName() + " ist jetzt dran und muss " + wuerfelErgebnis + " Felder ziehen. " + aktuellerUser);
                Console.WriteLine(spieler.getName() + " steht jetzt auf Feld " + spieler.getCurrentFeld().getFeldNummer());
                Console.WriteLine();
                spieler.getCurrentFeld().printFeldInfo();
                Console.WriteLine();
                Console.WriteLine(spieler.getName() + ", dein Guthaben beträgt " + spieler.getBalance());

                int currentMoney = spieler.getBalance();

                if (spieler.getCurrentFeld().getKaufenMoeglich() == true)
                {
                    // TODO - überprüfe ob das Feld auf dem du gelandet bist einem Spieler gehört, der nicht mehr aktiv ist
                    // wenn ja, dann setz den besitzer des Feldes auf null

                    if (spieler.getCurrentFeld().getBesitzer() == null)
                    { // Feld ist noch zu haben

                        int preisVomFeld = spieler.getCurrentFeld().getPreis();
                        // Überprüfen ob der Spieler das Feld kaufen kann
                        //if (preisVomFeld > spieler.getBalance())
                        if (spieler.isBalanceEnough(preisVomFeld) == false)
                        {
                            Console.WriteLine("Leider übersteigt der Preis des Feldes dein Guthaben von " + spieler.getBalance() + "!");
                        }
                        else
                        {
                            // Feld ist noch zu haben
                            Console.WriteLine(spieler.getName() + ", möchtest du das Feld kaufen? Schreib ja oder nein.");
                            string eingabe = "";

                            while (eingabe.ToLower().Equals("ja") == false && eingabe.ToLower().Equals("nein") == false)
                            {
                                eingabe = Console.ReadLine();
                                
                                if (eingabe.ToLower().Equals("ja") == true)
                                {
                                    // Gib Geld aus und speichere den Spieler im Feld

                                    //int newCurrentMoney = currentMoney - preisVomFeld;
                                    //spieler.setCurrentMoney(newCurrentMoney);
                                    //spieler.modifyMoney(-preisVomFeld); // TODO: Geld muss an die Bank zurück gehen
                                    //spieler.kaufeGrundstück(preisVomFeld);
                                    spieler.payToAccount(bank, preisVomFeld);

                                    spieler.getCurrentFeld().setBesitzer(spieler);
                                }
                                else if (eingabe.ToLower().Equals("nein") == false)
                                {
                                    Console.WriteLine("Bitte gib nur ja oder nein ein!");
                                    
                                }
                            }
                            

                        }
                    }
                    else if(spieler.getId() != spieler.getCurrentFeld().getBesitzer().getId())
                    {// Feld gehört nicht dem Spieler, der auf das Feld gekommen ist                        
                        
                        Spieler besitzer = spieler.getCurrentFeld().getBesitzer();
                        int mietPreis = spieler.getCurrentFeld().getMietPreis();

                        int paidMoney = 0;


                        // spieler

                        if (spieler.isBalanceEnough(mietPreis) == true && spieler.getCurrentFeld().getMortgaged() == false)
                        {// Zahle die Miete
                            // Fall Spieler hat genug Geld und Feld ist nicht belehnt
                            spieler.payToAccount(besitzer, mietPreis);
                            paidMoney = mietPreis;
                        }
                        //else if(spieler.isBalanceEnough(mietPreis) == false && spieler.getCurrentFeld().getMortgaged() == false) // aber das feld ist belehnt
                        else if(spieler.getCurrentFeld().getMortgaged() == false)
                        {                        
                            // Fall: Spieler hat nicht genug Geld und Feld ist nicht belehnt
                            if(spieler.getHowManyFieldsDoIHave() > 0)
                            {
                                //TODO:
                                //Hier müssten wir den spieler fragen, ob er ein Grundstück belehnen möchte
                                // Wenn er nicht belehnen will -> Grundstücke freigeben
                                // spieler.setPlayerActive(false);--> gib seine Statistik aus
                                Console.WriteLine(spieler.getName() + "_" + spieler.getId() + ", möchtest du eine Hypothek aufnehmen?");

                                string eingabe = Console.ReadLine();

                                
                                // sag ob du belehnen möchtest
                                while (eingabe.ToLower().Equals("ja") == false && eingabe.ToLower().Equals("nein") == false)
                                {
                                    Console.WriteLine("Bitte gib nur ja oder nein ein!");
                                    eingabe = Console.ReadLine();                                    
                                }


                                if (eingabe.ToLower().Equals("ja") == true)
                                {//belehne ein oder mehrere Felder
                                    while (mietPreis > spieler.getBalance())
                                    {
                                        string myFieldIds = ",";
                                        //1.string myFieldIds = ",1,3,5,";
                                        Feld aktuellesFeld = fLos;
                                        for (int i = ID_LOS; i < idCounter; i++)
                                        {
                                            // aktuellesFeld.getMortgaged() == false muss überprüft werden, weil ein Feld, dass bereits belehnt
                                            // wurde, nicht noch einmal belehnt werden darf.
                                            if (aktuellesFeld.getBesitzer() != null && (aktuellesFeld.getBesitzer().getId() == spieler.getId())
                                                && bank.isBalanceEnough(aktuellesFeld.getMortageAmount()) && aktuellesFeld.getMortgaged() == false)
                                            {
                                                myFieldIds += aktuellesFeld.getFeldNummer() + ",";
                                                aktuellesFeld.printFeldInfo();
                                                Console.WriteLine();
                                                Console.WriteLine("*****************************");
                                                Console.WriteLine();
                                                // 1 + Statistik
                                                // 3
                                                // 5
                                                // welche möchtest du?
                                            }
                                            aktuellesFeld = aktuellesFeld.getNext();
                                        }
                                        if (myFieldIds.Equals(",")) // gabs Felder, für die ich von der Bank Geld bekomme und die noch nicht belehnt waren?
                                        {
                                            playerExit(spieler, besitzer);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Welches Feld möchtest du belehnen? Bitte gib die Id ein.");
                                            //2.readline("welches feld")
                                            string sGewaehltesFeld = Console.ReadLine();
                                            while (myFieldIds.Contains("," + sGewaehltesFeld + ",") == false)
                                            {
                                                Console.WriteLine("Bitte wähle ein Feld, dass dir gehört.");
                                                sGewaehltesFeld = Console.ReadLine();
                                            }

                                            int iGewaehltesFeld = int.Parse(sGewaehltesFeld);
                                            bank.mortgageField(getFieldWithId(iGewaehltesFeld));

                                            //spieler.payToAccount(besitzer, mietPreis);
                                        }
                                        if(mietPreis > spieler.getBalance())
                                        {
                                            Console.WriteLine(spieler.getName() + ", du hast noch nicht genügend Geld und musst noch ein Feld belehnen");
                                        }

                                    }// end while
                                    
                                    if(spieler.getIsActive() == true)
                                    {//Spieler ist noch nicht rausgeflogen und hat genug Geld durch Belehnungen erhalten
                                        spieler.payToAccount(besitzer, mietPreis);
                                    }
                                }
                                else //if (eingabe.ToLower().Equals("nein") == true)
                                {
                                    playerExit(spieler, besitzer);                                    
                                }
                            }
                            else
                            {
                                playerExit(spieler, besitzer);
                                //paidMoney = spieler.getBalance();
                                //spieler.payToAccount(besitzer, spieler.getBalance());                                
                                //spieler.setPlayerActive(false);                                
                            }
                        }
                        else
                        {
                            Console.WriteLine(spieler.getName() + ", du hattest Glück, das Feld auf dem du stehst ist belehnt.");
                        }

                        // is still active?
                        if (spieler.getIsActive() == true)
                        {
                            Console.WriteLine("Der neue Geldstand von " + spieler.getName() + " = " + spieler.getBalance());
                        }
                        else
                        {
                            // TODO: Here I know that player is out - static counter to check if there is more than one player left
                            Console.WriteLine("Spieler " + spieler.getId() + " mit dem Namen " + spieler.getName() + " ist leider raus!");
                        }

                        Console.WriteLine(besitzer.getName() + " hat " + paidMoney + " erhalten. Der neue Geldstand von " + besitzer.getName() + " = " + besitzer.getBalance());
                    }
                }
                else
                {

                }
            }

        }
        #endregion

        public static void starteSpiel()
        {
            int iMenu = 0;
            string sEingabe = "";
            int wuerfelErgebnis = 0;
            Random wuerfel = new Random();

            int aktuellerUser = 0;

            // Start the game
            //TODO: Menü anpassen sodass ein Spieler auch Hypotheken zurückzahlen kann und Hypotheken nehmen kann
            Console.WriteLine("1...Roll Dices\n2...Player Statistics\n3...End Game");

            while (/*getPlayerCount() > 1 &&*/ (sEingabe = Console.ReadLine()).Equals("3") == false)
            {
                //TODO: Menupunkt sodass ein Spieler aussteigen kann
                if (sEingabe.Equals("1"))
                {
                    wuerfelErgebnis = wuerfel.Next(1, 7); // TODO: Überlegen ob der Würfel noch intelligenter wird und man den in eine Klasse auslagert                    
                    Spielplan.erhoeheZuege();


                    doPlayerMove(meinSpielerArray[aktuellerUser], wuerfelErgebnis, ref aktuellerUser);
                    // sMatthias.getId() == (aktuellerUser % limitPlayerPos)                                   

                    if (aktuellerUser >= limitPlayerPos)
                    {
                        aktuellerUser = 0;
                        Spielplan.erhoeheRunde();
                    }
                    else
                    {
                        aktuellerUser++;
                    }

                    //if(getPlayerCount() <= 1 == true)
                    //{
                    //    //mach Ausgabe und return;
                    //}

                }
                else if (sEingabe.Equals("2"))
                {
                    // TODO: Menu für Spielerstatistik
                    showSpielStatistik();

                    Console.WriteLine("Gib bitte an, von welchem Spieler du die Statistik sehen möchtest?");
                    String sSpielerId = Console.ReadLine();
                    int iSpielerId = 1;
                    int.TryParse(sSpielerId, out iSpielerId);

                    Spieler startSpieler = sMatthias;
                    do
                    {
                        if (startSpieler.getId() == iSpielerId)
                        {
                            startSpieler.showSpielerStatistik();
                            break;
                        }
                        startSpieler = startSpieler.getNextSpieler();


                    }
                    while (sMatthias.getId() != startSpieler.getId());
                    bank.showStatistics();



                }
                else
                {
                    Console.WriteLine("Bitte die Eingabe auf Menüpunkte 1-3 beschränken.");
                }
                Console.WriteLine("1...Roll Dices\n2...Player Statistics\n3...End Game");
            }
        }

        // FÜr die Statistik werden alle aktiven Spieler ausgegeben
        public static void showActivePlayers()
        {
            //Spieler firstPlayerToCheck = sMatthias;//getSpielerWithId(0);
            Spieler player = sMatthias;
            //while (firstPlayerToCheck.Equals() == false)
            //for(; sMatthias.getId() != player.getId(); player = player.getNextSpieler())
            do
            {
                //Spieler nextPlayer = sMatthias.getNextSpieler();
                if (player.getIsActive() == true)
                {
                    Console.WriteLine(player.getName() + " ist noch im Spiel!");
                }
                //else
                //{
                //    Console.WriteLine(player.getName() + " ist nicht mehr im Spiel!");
                //}
                player = player.getNextSpieler();
            }
            while (sMatthias.getId() != player.getId());
        }

        public static Feld getFieldWithId(int iGewaehltesFeld)
        {
            Feld startFeld = fLos;

            for (int i = ID_LOS; i < idCounter; i++) // TODO: Test if output is correct
            {
                //Spieler nextPlayer = sMatthias.getNextSpieler();
                if (startFeld.getFeldNummer() == iGewaehltesFeld)
                {
                    return startFeld;
                }
                startFeld = startFeld.getNext();
            }

            return null; // can not reach here
        }

        public static void showBuyableFields()
        {
            Feld startFeld = fLos;

            for(int i = ID_LOS; i < idCounter; i++) // TODO: Test if output is correct
            {
                //Spieler nextPlayer = sMatthias.getNextSpieler();
                if (startFeld.darfIchDasFeldKaufen())
                {
                    Console.WriteLine(startFeld.getFeldNummer() + " ist noch zu haben!");                    
                }
                startFeld = startFeld.getNext();
            }            
        }

        public static Spieler getLastSpieler()
        {
            return null;
        }

        public static void showSpielStatistik()
        {

            //1.Welche Spieler sind noch dabei
            showActivePlayers();
            //2. Anzahl der Spielzüge            
            Console.WriteLine("Anzahl der Züge: " + getAnzahlZuege());
            ////9. Wie oft hat ein Spieler gewürfelt - iteriere über jeden SPieler und addiere
            //Console.WriteLine("Gesamte Würfe im Spiel: " + getAnzahlZuege());
            //(11. Wie lange läuft das Spiel schon)
            //12. Welche Felder sind noch frei
            showBuyableFields();
            //13. Wie oft wurde über Los gegangen - iteriere über jeden SPieler und addiere



            //WÜRFELKLASSE!
            //14. Welcher Würfel ist am öftesten gefallen? - Eigene Würfelstatistik?
            //10. Wie groß war der Durschnittsweg pro Wurf = Was war die Durschnitts Augenzahl die gewürfet wurde

            //
            //iWuerfelRunden
            //anzahlZuege

        }

        //TODO: function that evaluates that the game finished and a function that ends the game and shows the statistics
        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            try
            {
                ClearOptions();
            }
            catch
            {

            }

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write(">");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }

        }
        public class Option
        {
            public string Name { get; }
            public Action Selected { get; }

            public Option(string name, Action selected)
            {
                Name = name;
                Selected = selected;
            }
        }

        static void ClearOptions()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 3);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.SetCursorPosition(0, currentLineCursor);
        }

    }

}
