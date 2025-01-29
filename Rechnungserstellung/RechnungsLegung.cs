
using System.Configuration;

namespace Rechnungserstellung
{
    class RechnungsLegung
    {        
        public static void Main(string[] args)
        {
            //Generieren 9 variablen mit readline für folgende Daten
            /*
                Rechnungssteller Name
                Rechnungssteller Anschrift
                Rechnungssteller UID Nummer
                Rechnungssteller Kontonummer
                Rechnungssteller Email
                Rechnungssteller Telefonnummer                

                Produktbeschreibung

                Rechnungsempfänger Name
                Rechnungsempfänger Anschrift
                Rechnungsempfänger UID Nummer                

                Der Betrag
             */


            //Rechtsklick auf Projekt und dort unter "NuGet Pakete..." dann nach ConfigurationManager suchen und installieren
            uint fortlaufendeNummer = Settings.Default.FortlaufendeNummer;


            DateTime thisDay = DateTime.Today;
            if (thisDay.ToString("d").Equals(Settings.Default.Day))
            {
                Settings.Default.FortlaufendeNummer = ++fortlaufendeNummer;
            }
            else
            {
                Settings.Default.Day = thisDay.ToString("d");
                fortlaufendeNummer = 1;
                Settings.Default.FortlaufendeNummer = fortlaufendeNummer;                
            }

            Settings.Default.Save();

            string path = $"C:\\tmp{thisDay.ToString().Replace("/", "").Replace(".", "").Replace("-", "")}-{fortlaufendeNummer}.txt";
            string stellerName = "Ich";

            /*
                Rechnungsempfänger Name								Rechnungssteller Name			
                Rechnungsempfänger Anschrift						Rechnungssteller Anschrift
                Rechnungsempfänger UID Nummer						Rechnungssteller UID Nummer
													                Heutiges Datum
													
                Rechnung: {Rechnungsnummer}

                Honorar für {Produkt} {aktuelles Monat}/{aktuelles Jahr}
                ------------------------------------------------------------------------------------
                Honorar						| {Nettobetrag}
                + 20% Ust.					| {berechnete Ust.}
                ------------------------------------------------------------------------------------
                Gesamt Brutto				| {Gesamtbetrag}


                Zu überweisen auf das Konto mit der Kontonummer {Rechnungssteller Kontonummer}, lautend auf {Rechnungssteller Name}. 
                Bitte die Rechnungsnummer als Verwendungszweck angeben.




                ------------------------------------------------------------------------------------
                Rechnungssteller Name - Rechnungssteller Anschrift - Rechnungssteller UID Nummer - 
                Rechnungssteller Kontonummer - Rechnungssteller Email - Rechnungssteller Telefonnummer
             
             */

            File.WriteAllText(path, stellerName);

            /*
             using(StreamWriter sr = new StreamWriter(path))
             {
                sr.WriteLine(...)
                sr....
                sr....
                sr....

             } 
             
             */

        }
    }
}