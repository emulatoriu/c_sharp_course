using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

class Weihnachtsgeschichte
{

    static string[] sFavoriteHoliday = { "Halloween", "Ostern", "Thanksgiving" };
    static string sName = "";

    private const int CHARACTER_PAUSE = 30; // in ms
    public static void storyAusgabe(String ausgabe)
    {
        for(int i=0; i<ausgabe.Length; i++)
        {
            Console.Write(ausgabe.ElementAt(i));
            Thread.Sleep(CHARACTER_PAUSE);
        }
        Console.WriteLine();
    }

    private static void printSmiley()
    {
        Console.WriteLine("                                    `.-:://////++++++//////::-.`                                    ");
        Console.WriteLine("                              `-://+///::::::::::::::::::::::///+//:-`                              ");
        Console.WriteLine("                          .-////::::::::::::::::::::::::::::::::::::////-.                          ");
        Console.WriteLine("                      `-:///:::::::::---....`````````````....---::::::::///:-`                      ");
        Console.WriteLine("                   `-///::::::::--..``````````````````````````````.--:::::::///-`                   ");
        Console.WriteLine("                 .://:::::::-.`````````````````````````````````````````.-:::::///:.                 ");
        Console.WriteLine("               .///:::::--.```````````````````````````````````````````````.--::::///.               ");
        Console.WriteLine("             .///:::::-.`````````````````````````````````````````````````````.-::::/+/.             ");
        Console.WriteLine("           ./+/::::-.```````````````````````````````````````````````````````````.-:::/+/.           ");
        Console.WriteLine("         `:+/::::-.```````````````````````````````````````````````````````````````.-:::/+:`         ");
        Console.WriteLine("        .+/::::-.```````````````````````````````````````````````````````````````````.-:::/+.        ");
        Console.WriteLine("       :+/::::..````````````````````````````````````````````````````````...............:::/+:       ");
        Console.WriteLine("     `/+::::-...........................................................................-::/+/`     ");
        Console.WriteLine("    `/+::::-.............................................................................-:::+/`    ");
        Console.WriteLine("    /+::::-...............-:/+osso/...............................:+ooo+/-................-:::+/    ");
        Console.WriteLine("   /+::::-..............:osyyso/-...................................:+syyso:...............-:::+/   ");
        Console.WriteLine("  -+:::::.............-shhso/-........................................-:+syyo...............::::+-  ");
        Console.WriteLine(" `o/::::-............-shs/-..............................................-/oys..............-:::/o` ");
        Console.WriteLine(" :+:::::-............oo:-...------.........................................-:o+.............-::::+: ");
        Console.WriteLine("`o/:::::-............----:+ossyyyyso+:---.................-----:/++++/:----------------------::::/o`");
        Console.WriteLine("-+:::::::-------------+shdmmmmmmmmmmmmds/-.................:+ydmmmmmmmmdhs+:----------------::::::+-");
        Console.WriteLine("/+::::::::--:::::---/hdhyhyyyssooossyhdmmh/..............-sdmdhhyyyyhhhddhdds/------::::::::::::::+/");
        Console.WriteLine("+/:::::::://///////+ss+/s/:------------:/o+..............-/::--------:::+o/osy+/::::////////::::::/+");
        Console.WriteLine("o/::::::///////:/+o//::/o----------------................----------------+o:::/+o+:----:://///::::/o");
        Console.WriteLine("o/:::://////:--/+/:::::o/------------------.............------------------o+:::::/++/--..-:////:::/o");
        Console.WriteLine("o/::://///:..:o/:::::::s:-------------------------------------------------:s:::::::::o/:----:/::::/o");
        Console.WriteLine("+/:::::/:---++:::::::::yo+/:::----------------------------------------:::/+y+:::::::..+o/:::::::::/+");
        Console.WriteLine("/+:::::::--++.-::::::-:yddhy//////:::::::::::::::::::::::::::::::///////hhdds::::::::--os/::::::::+/");
        Console.WriteLine("-+:::::::::y..:::::::`.ydddd:----:::////////////////////////////:::----+ddddh::::::::::+os::::::::+-");
        Console.WriteLine("`o/:::::::/s::::::::-`-yddddy...............------------..............-hddddd+``::::::/++y:::::::/o`");
        Console.WriteLine(" :+:::::::/y++/::::-``/hdddddy-``````````````````````````````````````:hddddddy-``-:::/++os:::::::+: ");
        Console.WriteLine(" `o/:::::::oo++/-.```:ydddddddd+```````````````````````````````````.odddddddddy:``.:/++os/:::::-/o` ");
        Console.WriteLine("  -+:-::::::+oo+:--:oydddddddddmdo:`                            `:sdddddddddddyso+//ooo+::::::-:+-  ");
        Console.WriteLine("   /+:--::::::/+ooo+/odddddddddmmmmmyo/:-...````    ````...-:+ohmmmddddddddddho:::///::::::::--+/   ");
        Console.WriteLine("    /+:.-::::::::::::/odddddddddmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmdddddddddho::::::::::::::--+/    ");
        Console.WriteLine("    `/+-.-::::::::::::/ohdddddddmmmmmmNNNmmddddmmNNNmmddhhddmmmmmmdddddddddho::::::::::::::--+/`    ");
        Console.WriteLine("     `/+:..:::::::::::::+ydddddddmmmmmmmhs++//++syddyo+///+oyhmmmmddddddddy+::::::::::::::.-+/      ");
        Console.WriteLine("       :+:..-::::::::::::/ohddddddmmmmdyo////++++oshs+++++++oshmmdddddddho/:::::::::::::-.-+:       ");
        Console.WriteLine("        .+/-..:::::::::::::+shdddddmmmdysoooooooossyyssssssssyddddddddyo/::::::::::::::../+.        ");
        Console.WriteLine("         `:+:..-:::::::::::://oydddddmmdyysssssssyyyyyyyyyyyyhdddddhs+/::::::::::::::-.:+:`         ");
        Console.WriteLine("           .//:..-:::::::::::::/+syhdddddhhyyyyyyyyyyyyyyyhhddddhs+/:::::::::::::::-.-//.           ");
        Console.WriteLine("             .//:.--::::::::::::::/+osyhddddddhhhhhhhhhddddhyso/:::::::::::::::::---//.             ");
        Console.WriteLine("               .//:---::::::::::::::::///+oossyyyyyyyssoo+/::::::::::::::::::::--://.               ");
        Console.WriteLine("                 .://:-:::::::::::::::::::::::::::-------:::::::::::::::::::::://:.                 ");
        Console.WriteLine("                   `-///::::::::::::::::::::::::::::::::::::::::::::::::::::///-`                   ");
        Console.WriteLine("                      `-:+///::::::::::::::::::::::::::::::::::::::::::///+:-`                      ");
        Console.WriteLine("                          .-/+////::::::::::::::::::::::::::::::::////+/-.                          ");
        Console.WriteLine("                              `-://+////:/::::::::::::::::::////+//:-`                              ");
        Console.WriteLine("                                    `.-::////++++++++++////::-.`  ");
    }

    private static void printMerryXMas()
    {
        Console.WriteLine("                                 oMo`-mdo.yMy`      ``     ``                                       ");
        Console.WriteLine("                                 -y:`myh:hdh`   ..` y/s...`y++..`   .`  .`                          ");
        Console.WriteLine("                                    omsyd+M.  -yo/h.:ddsmo +dhsN: `sy` +d.                          ");
        Console.WriteLine("                                   -N+NN/dd  .No:/h`:d.ys  .d.d/  sd` /N.                           ");
        Console.WriteLine("                             -+   .md.Nm`Md``yN----sh.:M:`:d-oM``+Mo`+N/                            ");
        Console.WriteLine("                             mN+:oNm. --`mNmdomNdmd/  :Nmdy. oNmmyNNdNm-://+/-`                     ");
        Console.WriteLine("                  -/oo:      :hNNdo`     `-.  `--`     .-`    .-``ohyMs::::/omm-                    ");
        Console.WriteLine("       :-       +mh/.-md   /h-                         `os`    .ss-`dN`      -m-                    ");
        Console.WriteLine("      /Ny`    .mN:    dM` +N:                /o++ooso:-dy`  -s d/ .hN:                              ");
        Console.WriteLine("      `+hmysooNMdoho+dMs /N-             .h:./ `.   -sMmmmmmh/ :sydy-              .`               ");
        Console.WriteLine("        `.:/+NMy``:sys- .N/    -++.      .+` /hood+  hy````.`   ```              oyood:             ");
        Console.WriteLine("            -MM-       `hNssm: -sdhym. `hs  `M. /do om`  `hmssd++shy   .ssysd:  -N` +d/             ");
        Console.WriteLine("            /MM-      :mMh.-M-  /d-m:  yh   -Ns``` .No   sMy.`dd:`yd  :m:`-Mo   +N+ ``              ");
        Console.WriteLine("            -MMy`  ./hymM` hd  +m.yd  /M+ `+y-hd+oohM: `oNy  +N. -M/ `my `yM. .so-dy/+oosyyo-       ");
        Console.WriteLine("             +NMmdddh/.MN  dNhdh. mNyhhMmyhyosohM/`+MdyhhM:  md  /MmyhmNyhmMhyysoo+mN:....:hN:      ");
        Console.WriteLine("              ./++:.   ++  .++-`  .++-`:+:/d:` yMs  :+:..o.  ++  `:+/..++-`/+:od-  dM+     .s.      ");
        Console.WriteLine("                                          /m::oNN:                            sd::sMm-              ");
        Console.WriteLine("                                          `/yhyo-                             `+yhy+. ");
    }

    private static void printXMasTree()
    {
        Console.WriteLine("                                      #%%                                       ");
        Console.WriteLine("                                     %%&%%                                      ");
        Console.WriteLine("                              *#%%%%%%(./%%%%%%#/                               ");
        Console.WriteLine("                               /%&%,.......,%%%(                                ");
        Console.WriteLine("                                  %%#.....(%%.                                  ");
        Console.WriteLine("                                  %%(#%%%#/%%                                   ");
        Console.WriteLine("                                .%%%%(///(%%%&,                                 ");
        Console.WriteLine("                              /&%%///////////%%%(                               ");
        Console.WriteLine("                           (%%%#///////////////(%%%#.                           ");
        Console.WriteLine("                        *%%%///////////////////((//#%%/                         ");
        Console.WriteLine("                         /%%%%%%%/%%%%*/%%%%#%%%%%%%%/                          ");
        Console.WriteLine("                              %&#////#%%(/*////%%.                              ");
        Console.WriteLine("                            ,%%(/////////////*/(%%*                             ");
        Console.WriteLine("                           %%%/*/////////////////%%%                            ");
        Console.WriteLine("                         %%%(//////////////////////%%%.                         ");
        Console.WriteLine("                      (%%%///////////////////////////%%%#                       ");
        Console.WriteLine("                  /%%%%/**//////////////////////////////%%%%(                   ");
        Console.WriteLine("                 .%%%#%%%%////%%*/*/*//////*%%/////%%%(///%%%,                  ");
        Console.WriteLine("                       *%%%%%%%%%%#%%%%%//(%%%%%%%%%(%%%%%(                     ");
        Console.WriteLine("                      /%%/*/*//////////(###///*///////%%(                       ");
        Console.WriteLine("                     %%%///////////////////////////////%%%                      ");
        Console.WriteLine("                   (%%#/////////////////////////////////(%%#                    ");
        Console.WriteLine("                 %%%#/////////////////////////////////////(%%%.                 ");
        Console.WriteLine("             .%%%%///////////////////////////////////////////%%%%,              ");
        Console.WriteLine("          .%%%#//*///////////////////////////////*/(/*///(%#/*//#%%%,           ");
        Console.WriteLine("           %%%*//////%%%////*///%%//////*%%%//*/*%%%%%/(%%%%%%##%%%(            ");
        Console.WriteLine("            /%%%%%%%%%(%%%#//%%%%%%(///(%%%%%%%%%%//////////%%%.                ");
        Console.WriteLine("               %%%///////*////*////%%%%%(////////////////////#%%                ");
        Console.WriteLine("             /%%(//////////////////////////////////////////////%&(              ");
        Console.WriteLine("           /%%%///////////////////////////////////////////////*/%%%(            ");
        Console.WriteLine("        .%%%#**///////////////////////////////////////////////////#%%%.         ");
        Console.WriteLine("     (%%&%///////////////////////////////////////////////////////////%%&%(      ");
        Console.WriteLine("    %&%////*//%%%/////////%%%////////////(%(/////////%%//////////%%#*//*#%&,    ");
        Console.WriteLine("      /%%%%%%&#,%%%#/**(%%%#%%%#//*////%%%%%%#*////%%%%%%#////(%%%(%%%%%%*      ");
        Console.WriteLine("                  ./###(,     .%%%%%%%%(/////%%%&&%/     *(###/.                ");
        Console.WriteLine("                               %%(///////////%%*                                ");
        Console.WriteLine("                               &%/////////////%%                                ");
        Console.WriteLine("                              %&#/////////////#%%                               ");
        Console.WriteLine("                              %%%(((((((((((((%%% ");
    }

    private static void giveAnotherChanceMessage()
    {
        Random rand = new Random();
        int iRandom;

        iRandom = rand.Next(1, 4);
        storyAusgabe(sName + ", du bist wohl eher der " + sFavoriteHoliday[iRandom] + " Typ gell? Du bekommst noch eine Chance.");
    }

    public static bool convertUserNumberInput(string umrechnungswert, out float fUmrechnungswert)
    {
        bool hatEsFunktioniert = Single.TryParse(umrechnungswert, out fUmrechnungswert);

        if (hatEsFunktioniert == false)
        {
            umrechnungswert = umrechnungswert.Replace(',', '.');

            hatEsFunktioniert = Single.TryParse(umrechnungswert, out fUmrechnungswert);

            if (hatEsFunktioniert == false)
            {
                umrechnungswert = umrechnungswert.Replace('.', ',');
                hatEsFunktioniert = Single.TryParse(umrechnungswert, out fUmrechnungswert);
                if (hatEsFunktioniert == false)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static void giveThinkingTime()
    {
        Console.WriteLine();
        Thread.Sleep(2000);
    }

    private static void checkIfFileExists(string sFilename)
    {
        if(File.Exists(sFilename))
        {
            File.Delete(sFilename);
        }
    }

    private static void generateTreeClass(string sClassName)
    {
        string sFilename = sClassName + ".cs";
        checkIfFileExists(sFilename);
        //TODO setSchumck Funktion und var und von main aufrufen
        using (StreamWriter w = File.AppendText(sFilename))
        {            
            w.WriteLine("class " + sClassName);
            w.WriteLine("{");
            w.WriteLine();
            w.WriteLine("private string sTannenArt = \"\";");
            w.WriteLine("private float treeSize = 0;");
            w.WriteLine("private string sPlaceForTree = \"\";");
            w.WriteLine("private bool bSetSchmuck = true;");
            w.WriteLine("private List<Geschenke> gGeschenksListe = new List<Geschenke>();");
            w.WriteLine();
            w.WriteLine("public void setSchmuck(bool bSetSchmuck)");
            w.WriteLine("{");           
            w.WriteLine("this.bSetSchmuck = bSetSchmuck;");
            w.WriteLine("}");
            w.WriteLine();
            w.WriteLine("public bool getSetSchmuck()");
            w.WriteLine("{");            
            w.WriteLine("return bSetSchmuck;");
            w.WriteLine("}");
            w.WriteLine();
            w.WriteLine("public void setTannenArt(string sTannenArt)");
            w.WriteLine("{");            
            w.WriteLine("this.sTannenArt = sTannenArt;");
            w.WriteLine("}");
            w.WriteLine();
            w.WriteLine("public string getTannenArt()");
            w.WriteLine("{");            
            w.WriteLine("return sTannenArt;");
            w.WriteLine("}");
            w.WriteLine("public void setPlaceForTree(string sPlaceForTree)");
            w.WriteLine("{");            
            w.WriteLine("this.sPlaceForTree = sPlaceForTree;");
            w.WriteLine("}");
            w.WriteLine();
            w.WriteLine("public string getPlaceForTree()");
            w.WriteLine("{");            
            w.WriteLine("return sPlaceForTree;");
            w.WriteLine("}");
            w.WriteLine();
            w.WriteLine("public void setTreeSize(float treeSize)");
            w.WriteLine("{");            
            w.WriteLine("this.treeSize = treeSize;");
            w.WriteLine("}");
            w.WriteLine("public float getTreeSize()");
            w.WriteLine("{");            
            w.WriteLine("return treeSize;");
            w.WriteLine("}");
            w.WriteLine();
            w.WriteLine("public void putPresentUnderTree(Geschenk geschenk)");
            w.WriteLine("{");            
            w.WriteLine("gGeschenksListe.Add(geschenk);");
            w.WriteLine("}");            
            w.WriteLine();            
            w.WriteLine("}");
        }
    }

    private static void generateGeschenkClass()
    {
        string sFilename = "Geschenke.cs";
        checkIfFileExists(sFilename);
        using (StreamWriter w = File.AppendText(sFilename))
        {
            w.WriteLine("class Geschenk");
            w.WriteLine("{");
            w.WriteLine();
            w.WriteLine("private string sGeschenkTyp = \"\";");
            w.WriteLine();
            w.WriteLine("public void setGeschenkTyp(string sGeschenkTyp)");
            w.WriteLine("{");            
            w.WriteLine("this.sGeschenkTyp = sGeschenkTyp;");
            w.WriteLine("}");
            w.WriteLine("public void getGeschenkTyp()");
            w.WriteLine("{");
            w.WriteLine("return sGeschenkTyp;");
            w.WriteLine("}");
            w.WriteLine();
            w.WriteLine("}");
        }
    }

    private static void generateMainClass(string sFirstType, string sSecondType, string sThirdType,
        string sTannenArt, float treeSize, string sPlaceForTree, string sClassName, int amountPresents)
    {
        string sFilename = "MainClass.cs";
        checkIfFileExists(sFilename);
        using (StreamWriter w = File.AppendText(sFilename)) // not Program.cs ;)
        {
            w.WriteLine("using System;");
            w.WriteLine();
            w.WriteLine("class MainClass");
            w.WriteLine("{");            
            w.WriteLine("public static void Main(string[] args)");
            w.WriteLine("{");
            w.WriteLine(sClassName + " myTree = new " + sClassName + "();");
            w.WriteLine("myTree.setTannenArt(\"" + sTannenArt + "\");");
            w.WriteLine("myTree.setPlaceForTree(\"" + sPlaceForTree + "\");");
            w.WriteLine("myTree.setTreeSize(" + treeSize+ ");");
            w.WriteLine("myTree.setSchmuck(true);");
            w.WriteLine("string[] sPresentTypes = {\""+sFirstType+ "\", \"" + sSecondType + "\", \"" + sThirdType + "\"};");
            w.WriteLine("Random rand = new Random();");
            w.WriteLine("int iRandom;");
            w.WriteLine();
            w.WriteLine("for(int i=0; i<" + amountPresents + "; i++)");
            w.WriteLine("{");
            w.WriteLine("iRandom = rand.Next(0, 3);");
            w.WriteLine("myTree.putPresentUnderTree(new Geschenk().setGeschenkTyp(sPresentTypes[iRandom]));");
            w.WriteLine("}");
            w.WriteLine("}");
            w.WriteLine("}");
        }
    }

    private static void generateXMasCode(string sFirstType, string sSecondType, string sThirdType,
        string sTannenArt, float treeSize, string sPlaceForTree, string sClassName, int amountPresents)
    {

        generateTreeClass(sClassName);
        generateGeschenkClass();
        generateMainClass(sFirstType, sSecondType, sThirdType, sTannenArt, treeSize, sPlaceForTree, sClassName, amountPresents);

        

    }

    private static void wishAHappyNewYear()
    {
        var p = new Process();
        p.StartInfo = new ProcessStartInfo(@"..\..\..\..\hny_2022.gif")
        {
            UseShellExecute = true
        };
        p.Start();
    }

    public static void Main(string[] args)
    {
        String sAwnser = "";
        storyAusgabe("Hallo.......ähhh........wie darf ich dich nennen?");
        sName = Console.ReadLine();
        storyAusgabe("Alles klar, hallo " + sName);
        Console.WriteLine();
        storyAusgabe("Hast du Lust auf eine weihnachtliche Geschichte?");
        Console.WriteLine();
        

        while ((sAwnser = Console.ReadLine().ToLower()).Equals("ja") == false)
        {
            if(sAwnser.Equals("nein"))
            {
                giveAnotherChanceMessage();
                storyAusgabe("Ich empfehle die Antwort 'ja' :D");
                Console.WriteLine();                

            }
            else
            {                
                storyAusgabe("Es ist dir Wahrscheinlich entfallen, aber das war eine ja/nein Frage.");
                Console.WriteLine();
            }
            
        }

        storyAusgabe("Das freut mich. Ich habe eine kleine Überraschung für dich.");
        storyAusgabe("Du musst die Geschichte mitgestalten.");

        Console.WriteLine();

        storyAusgabe("Es war einmal vor langer Zeit ein Weihnachtself namens Buggy.");
        storyAusgabe("Buggy war auf einer Mission. Er wollte einen Weihnachtsbaum aufstellen, der so groß war, dass ihn die ganze Welt sehen könnte.");
        giveThinkingTime();
        storyAusgabe("Er wollte unter diesem so viele Geschenke platzieren, dass alle armen Menschen die keine Geschenke bekamen eines bekommen würden.");
        giveThinkingTime();
        storyAusgabe("Möchtest du Buggy helfen?");
        while ((sAwnser = Console.ReadLine().ToLower()).Equals("ja") == false)
        {
            if (sAwnser.Equals("nein"))
            {
                giveAnotherChanceMessage();
                storyAusgabe("Jetzt komm schon. Möchtest du Buggy helfen?");
                Console.WriteLine();

            }
            else
            {
                storyAusgabe("Es ist dir Wahrscheinlich entfallen, aber das war eine ja/nein Frage.");
                Console.WriteLine();
            }

        }

        storyAusgabe("Fantastisch, Buggy freut sich sehr!");

        int failCount = 0;

        storyAusgabe("Was meinst du benötigt Buggy, um einen Weihnachtsbaum erzeugen zu können?");

        while ((sAwnser = Console.ReadLine().ToLower()).Equals("klasse") == false)
        {
            failCount++;
            switch(failCount)
            {
                case 1:
                    storyAusgabe("Das wars nicht ganz. Probier es noch einmal.");
                    Console.WriteLine();
                    break;
                case 2:
                    storyAusgabe("Ich gebe dir einen Tipp. Es reimt sich auf Masse.");
                    Console.WriteLine();
                    break;
                case 3:
                    storyAusgabe("Ich gebe dir noch einen Tipp. Ich brauche es damit ich daraus ein Objekt mit 'new' bilden kann.");
                    Console.WriteLine();
                    break;
                case 4:
                    storyAusgabe("Ich weiß, dass du weißt, dass die richtige Antwort 'Klasse' ist :D");
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        } // end while

        storyAusgabe("Ok, erzeugen wir eine Klasse, wie nennen wir Sie?");
        string sClassName = Console.ReadLine();
        while (Regex.IsMatch(sClassName, @"^[a-zA-Z]+$") == false)
        {
            storyAusgabe("Bitte verwende nur Buchstaben.");
            sClassName = Console.ReadLine();
        }

        bool setSchmuecken = false;
        float treeSize = 0; // in m
        string sEingeleseneTreeSize = "";
        string sTannenArt = "";
        string sPlaceForTree = "";

        storyAusgabe("Große Klasse!");
        storyAusgabe("Ich bin so frei und schmücke diesen Baum mit einem wunderschönen Stern an der Spitze.");
        Console.WriteLine();
        storyAusgabe("Sag, wie groß soll der Baum eigentlich werden (in Meter)?");

        bool bKorrekteEingabe = false;
        while(!bKorrekteEingabe)
        {
            sEingeleseneTreeSize = Console.ReadLine();
            if(convertUserNumberInput(sEingeleseneTreeSize, out treeSize) && treeSize > 0)
            {
                bKorrekteEingabe = true;
                if(treeSize < 100)
                {
                    storyAusgabe("Ob man diesen Baum von der ganzen Welt aus sehen kann? Na gut.");
                }
            }
            else
            {
                if(treeSize < 0)
                {
                    storyAusgabe("Wachsen bei dir Bäume nach unten in die Erde?");
                }
                storyAusgabe("Bitte gib eine gültige Zahl ein! Darf auch gerne eine Kommazahl sein ;)");
            }
        }

        storyAusgabe("Sag, wo soll dein Baum eigentlich stehen?");
        sPlaceForTree = Console.ReadLine();
        string sCheckForContent = sPlaceForTree.ToLower();
        if(sCheckForContent.Contains("mond") || sCheckForContent.Contains("hier") || sCheckForContent.Contains("mars") || sCheckForContent.Contains("hause")
            || sCheckForContent.Contains("venus") || sCheckForContent.Contains("vegas") || sCheckForContent.Contains("matrix"))
        {
            printSmiley();
        }
        Console.WriteLine("Buggy meint, du hast wahrscheinlich den besten Platz für diesen Baum gefunden!");

        storyAusgabe("Wähle bitte noch eine Baumart aus:");
        Console.WriteLine("1.Nordmanntanne");
        Console.WriteLine("2.Edeltanne");
        Console.WriteLine("3.Korktanne");
        Console.WriteLine("4.Weißtanne");
        Console.WriteLine("5.Coloradotanne");
        Console.WriteLine("6.Blaufichte");
        Console.WriteLine("7.Weißfichte");
        Console.WriteLine("8.Rotfichte");

        bool bParsingWorked = false;
        int iChosenMenu = 0;
        while (!bParsingWorked)
        {
            sAwnser = Console.ReadLine();
            bParsingWorked = int.TryParse(sAwnser, out iChosenMenu) && iChosenMenu > 0 && iChosenMenu <= 8;
            if(!bParsingWorked)
            {
                storyAusgabe("Du brauchst mich nicht zu testen, ich funktioniere schon richtig :D");
                Console.WriteLine();
                storyAusgabe("Wähle von 1-8");
            }
        }

        string[] baumArt = { "Nordmanntanne", "Edeltanne", "Korktanne" , "Weißtanne", "Coloradotanne", "Blaufichte",
                            "Weißfichte", "Rotfichte"};

        sTannenArt = baumArt[iChosenMenu - 1];

        storyAusgabe("Buggy freut sich sehr über die " + sTannenArt + ", eine gute Wahl!");        
        storyAusgabe("Es ist ein wirklich schöner Baum geworden.");
        giveThinkingTime();
        printXMasTree();
        storyAusgabe("Last but not least möchte Buggy noch Geschenke unter den Baum legen.");
        storyAusgabe("Würdest du 3 Kategorien von Geschenken definieren? Nach jeder Kategorie drücke einfach 'Enter'");
        string sFirstType = Console.ReadLine();
        string sSecondType = Console.ReadLine();
        string sThirdType = Console.ReadLine();
        Console.WriteLine();
        storyAusgabe("Wunderbar, und wieviele Geschenke sollen es werden?");
        
        string sGeschenkAmount = Console.ReadLine();
        int iGeschenkAmount = 0;
        
        while(int.TryParse(sGeschenkAmount, out iGeschenkAmount) == false || iGeschenkAmount<0)
        {
            storyAusgabe("Ich kann es nicht glauben, dass du mich jetzt noch auf die Probe stellst.");
            storyAusgabe("Bitte wähle eine Zahl, die wenn möglich positiv und kleiner als der maximale Integer Bereich ist :D");
            sGeschenkAmount = Console.ReadLine();
        }

        storyAusgabe("Toll, Buggy freut sich, dass du " + iGeschenkAmount + " Geschenke unter den Baum stellst.");
        giveThinkingTime();
        storyAusgabe("Buggy bedankt sich, dass du so toll mitgearbeitet hast und hinterlässt dir deinen persönlichen Weihnachtscode unter diesem Pfad: " + Directory.GetCurrentDirectory());
        Console.WriteLine();
        generateXMasCode(sFirstType, sSecondType, sThirdType, sTannenArt, treeSize, sPlaceForTree, sClassName, iGeschenkAmount);
        giveThinkingTime();
        storyAusgabe("Vergiss nicht, das schönste Geschenk, dass man bekommen kann, ist die Freude eines Beschenkten.");
        storyAusgabe("Also was ich damit sagen will ist, dass geben seliger ist als nehmen.");
        giveThinkingTime();
        storyAusgabe("Deswegen gebe ich dir über die Feiertage folgende Aufgabe. Spiele mindestens einmal eine Partie Monopoly und lass dich von dem Spiel für unser Programm inspirieren :D");
        storyAusgabe("In diesem Sinne wünscht dir Buggy:");
        printMerryXMas();
        storyAusgabe("...und...............................................................................");
        giveThinkingTime();
        wishAHappyNewYear();
    }

}