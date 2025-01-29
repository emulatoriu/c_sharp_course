class BedTimeStory
{
    private delegate bool thingsTheBabyWillDo(int sleepTime);
    private delegate string BTS(out string story);

    private static string HaenselUndGraetel(out string story)
    {
        story = @"Es war einmal ein armer Holzfäller, der mit seinen Kindern, Hänsel und Gretel, am Rande eines großen Waldes lebte. Ihre Mutter war gestorben und der Vater hatte wieder geheiratet.
Eines Nachts hörten die Kinder wie die Stiefmutter heimlich zum Vater sprach: “All unsere Vorräte sind leer, wir haben nur noch einen halben Laib Brot. Die Kinder müssen fort, wir sollten sie tief in den Wald führen, damit sie den Weg nicht wieder heraus finden; sonst müssen wir alle verhungern.' Dem Vater wurde es schwer ums Herz.Doch er gab nach und willigte ein.

Als die Alten schliefen, begann Gretel zu weinen.Hänsel tröstete sie: “Weine nicht!Versuch zu schlafen, der liebe Gott wird uns schon helfen.”

Am frühen Morgen bekam jedes der Kinder ein Stückchen Brot. Auf dem Weg in den Wald bröckelte es Hänsel in der Tasche und warf nach und nach unbemerkt einen Brotkrumen auf die Erde.

Die Kinder wurden tief in den Wald geführt und der Vater entzündete ein großes Feuer. Die Stiefmutter sprach: “Bleibt hier sitzen, wenn ihr müde seid, könnt ihr schlafen. Wir gehen Holz hacken, und heute Abend holen wir euch wieder ab.”

Als es Mittag war, schliefen sie ein. Der Abend verging, aber niemand kam.Sie erwachten erst in der finsteren Nacht.Hänsel sagte: “Lass uns warten bis der Mond aufgeht, dann werden wir die Brotkrumen sehen, die ich ausgestreut habe, die zeigen uns den Weg nach Haus.” Als der Mond kam, machten sie sich auf, aber sie fanden keinen Krumen mehr, denn die vielen Vögel, die in Wald und Feld umher flogen, hatten sie weggepickt.So gerieten sie immer tiefer in den Wald.

Als es hell wurde, kamen sie an ein Häuschen, dass aus Brot gebaut war, und mit Kuchen gedeckt.Die Fenster waren aus hellem Zucker. “Da wollen wir uns dran machen,” sprach Hänsel, griff in die Höhe und brach etwas vom Dach ab. Gretel stellte sich an die Scheiben und knusperte daran.Da rief eine dünne Stimme aus der Stube heraus:

“Knusper, knusper, Knäusschen, wer knuspert an meinem Häuschen ?”

Die Kinder antworteten:

“Der Wind, der Wind, das himmlische Kind,”

und aßen weiter.Da ging auf einmal die Türe auf, und eine steinalte Frau, die sich auf einen Stock stützte, kam heraus. Hänsel und Gretel erschraken so sehr, dass sie alles fallen ließen was sie in den Händen hielten.Die Alte wackelte mit dem Kopf und sprach: “Ei, ihr lieben Kinder, kommt nur herein, es geschieht euch nichts.” Sie fasste beide an der Hand und führte sie in ihr Häuschen. Dort gab es Milch und Pfannkuchen mit Apfelbrei. Danach wurden zwei schöne Bettchen gemacht. Hänsel und Gretel legten sich hinein und fühlten sich wie im Himmel.

Früh Morgens, ehe die Kinder erwacht waren, packte die Alte Hänsel und sperrte ihn hinter einer Gittertür ein. Dann ging sie zu Gretel, rüttelte sie wach und rief: “Steh auf, hol Wasser und koch deinem Bruder etwas Gutes, der sitzt draußen im Stall und soll fett werden.” Gretel begann bitterlich zu weinen, aber es war alles vergebens, sie musste tun was die böse Hexe verlangte.

Nun wurde dem armen Hänsel das beste Essen gekocht.Jeden Morgen rief die Alte: “Hänsel, streck einen Finger heraus, damit ich fühle ob du fett bist.” Hänsel streckte ihr aber nur ein Knöchelchen heraus, und die Alte, die trübe Augen hatte, konnte es nicht sehen, und meinte es sei Hänsels Finger.Sie wunderte sich, dass er gar nicht fetter wurde. Als vier Wochen um waren und Hänsel weiter mager blieb, überkam sie die Ungeduld.

Die Hexe stieß Gretel hinaus zum Backofen, aus dem die Flammen schon herausschlugen. “Kriech hinein,” sagte die Hexe, “und schau ob genug vorgeheizt ist.” Wenn Gretel drin war, wollte sie den Ofen zumachen. Aber Gretel merkte was sie im Sinn hatte und sprach: “Ich weiß nicht wie ich’s machen soll; wie komm ich da hinein ?” Die Alte entgegnete: ”Die Öffnung ist groß genug, siehst du, ich könnte selbst hinein,' bückte sich und steckte den Kopf in den Backofen. Da gab ihr Gretel einen Stoß, dass sie hinein flog, knallte die eiserne Tür zu und schob den Riegel vor.

Gretel rannte schnurstracks zu Hänsel, öffnete den Stall und rief “Hänsel, wir sind erlöst, die alte Hexe ist tot.” Da sprang Hänsel heraus und umarmte Gretel vor Freude! Dann verließen Sie den unheiligen Ort und schlugen sich in den Wald.

Als sie ein paar Stunden gegangen waren, kam ihnen die Umgebung immer bekannter vor, und endlich erblickten sie von weitem das Haus ihres Vaters. Da begannen sie zu laufen, stürzten in die Stube hinein und fielen ihrem Vater um den Hals. Der Mann hatte keine frohe Stunde gehabt, seit er die Kinder im Wald gelassen hatte und die Stiefmutter hatte ihn verlassen.

Er war sehr glücklich, dass er seine lieben Kinder wieder hatte und sie lebten in lauter Freude zusammen.";

        return "Hänsel und Grätl";
    }

    private static string Rotkaeppchen(out string story)
    {
        story = @"Es war einmal ein süßes Mädchen, das mit seiner Mutter auf dem Dorf lebte. Seine Großmutter schenkte ihm ein rotes Käppchen, das ihm so gut stand, dass es nichts anderes mehr tragen wollte. So nannte jeder das Mädchen 'Rotkäppchen'.

Eines Tages sagte ihm seine Mutter: 'Rotkäppchen, hier ist ein Stück Kuchen und eine Flasche Wein.Bring das der Großmutter hinaus.Sie ist krank und schwach, sie wird sich daran erfrischen.Wenn du hinaus kommst, geh sittsam und lauf nicht vom Weg ab.Sonst fällst du und zerbrichst die Flasche und die arme Großmutter hat nichts.'

Rotkäppchen nickte und machte sich auf den Weg. Im Wald traf sie auf den großen bösen Wolf. 'Guten Tag Rotkäppchen!' sagte der Wolf, „Schönen Dank!“ antwortete das Rotkäppchen, denn es kannte den Wolf noch nicht und wusste nicht, dass er so ein böses Tier ist. Der Wolf fragte, wo das Rotkäppchen hingehe. Es antwortete: „Ich bringe meiner Großmutter Wein und Kuchen, denn sie ist ganz krank und sie schenken ihr Kraft.“

„Gut!“, dachte sich der Wolf. „Die Großmutter und das Rotkäppchen, die schnappe ich mir beide!“ Der Wolf riet dem Rotkäppchen sich die wunderschönen Blumen ringsumher anzuschauen.Das Rotkäppchen schaute sich um und dachte sich, dass frische Blumen der Großmutter sicher gut tun würden. Das Mädchen sah eine schöne Blume nach der Anderen und so kam es immer weiter vom Weg ab und ging immer tiefer in den Wald. Der Wolf lief zum Haus der Großmutter und klopfte an ihre Tür: „Großmutter, hier ist das Rotkäppchen!Ich bringe dir Wein und Kuchen, mach auf!“ Die Großmutter antwortete: „Ich bin zu schwach aufzustehen, drück nur auf die Klinke!“ Der böse Wolf drückte die Klinke, lief schnell zum Bett der Großmutter und aß sie auf.

Der Wolf zog sich die Kleider der Großmutter an, setzte ihre Haube auf, legte sich ins Bett und wartete auf das Rotkäppchen. Als Rotkäppchen am Haus der Großmutter angekommen war, wunderte sie sich, dass die Haustür offen stand. Sie ging an das Bett der Großmutter und sagte: „Großmutter, was hast du für große Ohren!“ – „Dass ich dich besser hören kann!“ – „ Großmutter, was hast du für große Augen!“ – „Dass ich dich besser sehen kann!“ – „Großmutter, was hast du für große Hände!“ – „Dass ich dich besser packen kann!“ – „Großmutter, was hast du für ein großes Maul!“ – „Dass ich dich besser fressen kann!“ sagte der Wolf und aß auch das Rotkäppchen.

Als der Wolf seinen Appetit gestillt hatte, legte er sich ins Bett, schlief ein und fing an, laut zu schnarchen.Das hörte der Jäger, der an dem Haus vorbei ging. „Wie die alte Frau schnarcht”, dachte er. Der Jäger ging in das Haus, um nachzuschauen, ob ihr was fehle und sah, wie der große böse Wolf mit seinem dicken Bauch im Bett der Großmutter schlief. „Jetzt hab ich dich, du alter Sünder!Wie lange ich dich schon gesucht habe!“ dachte der Jäger und legte seine Büchse an. Da fiel ihm ein, dass der Wolf die arme Großmutter gefressen haben könnte. Er nahm eine Schere und schnitt den dicken Bauch des Wolfes auf. Sofort sah er das Rotkäppchen.Nach ein paar Schnitten konnte sich das Mädchen befreien. „Ach, wie war ich erschrocken, wie war es dunkel in dem Wolf seinem Leib!“, sagte das Rotkäppchen.

Auch die Großmutter konnte aus dem Bauch des Wolfes gerettet werden.Der Jäger, Rotkäppchen und die Großmutter holten große Steine und füllten damit den Bauch des Wolfes.Als er aufwachte, wollte er fortspringen, aber die Steine in seinem Leib waren so schwer, dass er gleich niedersank und tot umfiel.Der Jäger zog seinen Pelz ab und ging damit nach Hause.Die Großmutter aß den Kuchen und trank den Wein und erholte sich wieder.Das Rotkäppchen dachte, dass sie nie wieder den Weg verlassen wolle, den sie eigentlich gehen sollte.";

        return "Rotkäppchen";
    }

    private static string Aschenputtel(out string story)
    {
        story = @"Das Märchen beginnt damit, dass die Frau von einem reichen Mann stirbt. Bevor sie die Augen schließt, holt sie ihre einzige Tochter an ihr Krankenbett und sagt ihr: „Liebes Kind, bleib fromm und gut, so wird dir der liebe Gott immer beistehen, und ich will vom Himmel auf dich herabblicken und will um dich sein.

Genau das macht das Mädchen.Sie bleibt fromm und gut und besucht jeden Tag das Grab ihrer Mutter.Schon bald nach deren Tod nimmt sich ihr ehemaliger Ehemann und Vater des Kindes eine neue Frau.Die hat zwei Töchter, die wunderschön, aber auch sehr gemein und garstig sind.Sie behandeln ihre Stiefschwester wie eine Küchenmagd.Sie nehmen ihr alle schönen Kleider weg und ziehen ihr einen grauen Kittel und Holzpantoffel an. Das Mädchen muss jeden Tag hart in der Küche arbeiten.Ihre Stiefschwestern mobben sie und schütten ihr Erbsen und Linsen in die Asche. Bis spät in die Nacht muss das Mädchen die Erbsen und Linsen aus der Asche suchen.Auch schlafen muss das Mädchen in der Küche, direkt neben dem Herd in der Asche. Weil das Mädchen deswegen immer dreckig aussieht, wird es von ihren Stiefschwestern Aschenputtel genannt.

Als der Vater eines Tages auf Reisen geht, fragt er die drei Mädchen, was er ihnen mitbringen solle. Schöne Kleider und Edelsteine wünschen sich die Töchter von der Stiefmutter. „Vater, das erste Reis, das Euch auf Eurem Heimweg an den Hut stößt, das brecht für mich ab”, sagt Aschenputtel. Der Vater bringt ihr dein Reiskorn mit.Aschenputtel pflanzt es am Grab ihrer Mutter.Ein wunderschöner Baum wächste daraus.Auf dem Baum sitzt ein weißer Vogel.Und der wirft herab, was auch immer Aschenputtel sich wünscht.

Als der König ein Fest ankündigt, das drei Tage und Nächte dauern soll, gibt es viel Aufregung im Haus von Aschenputtel.Zu dem Fest sollen nämlich alle Jungfrauen des Landes kommen, damit sich der Prinz eine Frau aussuchen kann.Aschenputtel will mit auf das Fest und fragt ihre Stiefmutter: „Da habe ich dir eine Schüssel Linsen in die Asche geschüttet, wenn du die Linsen in zwei Stunden wieder ausgelesen hast, so sollst du mitgehen”, sagt die.

Aschenputtel geht in den Garten und ruft die Tauben: „Ihr zahmen Täubchen, ihr Turteltäubchen, all ihr Vöglein unter dem Himmel, kommt und helft mir lesen, die guten ins Töpfchen, die schlechten ins Kröpfchen.” Die Tauben suchen die Linsen aus der Schüssel heraus.Aschenputtel geht voller Freude zur Stiefmutter, doch die erteilt ihr eine Absage: „Nein, Aschenputtel, du hast keine Kleider und kannst nicht tanzen: du wirst nur ausgelacht.” Die Stiefmutter schüttet zwei Teller Linsen in die Asche. Aschenputtel soll auch diese heraussuchen.Dann dürfe sie auch auf das Fest gehen.

Aschenputtel ruft wieder ihr Tauben und die erledigen die Arbeit. Doch als Aschenputtel mit den herausgesuchten Linsen zur Stiefmutter geht, erlaubt diese ihr wieder nicht, mitzukommen: „Es hilft dir alles nichts: du kommst nicht mit, denn du hast keine Kleider und kannst nicht tanzen; wir müßten uns deiner schämen.”

Aschenputtel ist sehr traurig und geht zu dem Baum auf dem Grab ihrer Mutter: „Bäumchen, rüttel dich und schüttel dich, wirf Gold und Silber über mich”, sagt sie.Der Vogel wirft ihr ein gold-silbernes Kleid und hübsche Pantoffeln herunter.Aschenputtel geht auf das Fest und alle wundern sich, wer dieses schöne Mädchen ist.Der Prinz möchte den ganzen Abend nur mit ihr tanzen: „Das ist meine Tänzerin”, sagt er.Der Prinz will das Mädchen nach Hause bringen. Aber Aschenputtel entwischt ihm. Als ihr Vater später nach Hause kommt, liegt sie in der Küche und schläft. So ahnt niemand, dass Aschenputtel das schöne Mädchen auf dem Fest war.

Auch am nächsten Tag wünscht sich Aschenputtel ein Kleid von dem Vogel auf dem Baum.Sie bekommt ein noch viel Schöneres als am Abend vorher. Wieder tanzt sie auf dem Fest die ganze Nacht mit dem Prinzen. Wieder entwischt Anschenputtel dem Prinzen am Abend.Wieder ahnt niemand, dass das schönste Mädchen auf dem Fest Aschenputtel ist.

Für den dritten Tag des Festes aber hat sich der Prinz einen Trick ausgedacht: Er bestreicht die Treppe mit schwarzem Pech.Aschenputtels linker Pantoffel bleibt darauf hängen. Mit dem Pantoffel will der Prinz seine hübsche Tänzerin finden. Dem Mädchen, das in den Pantoffel passt, soll seine Frau werden.

Eine Tochter der Stiefmutter schneidet sich die Zehen ab, damit sie in den Schuh passt.Der Prinz denkt, sie sei das richtige Mädchen und nimmt sie mit auf das Schloss. Als die beiden jedoch am Grab von Aschenputtels Mutter vorbei reiten, rufen zwei Tauben: „Rucke di guck, rucke di guck, Blut ist im Schuck: der Schuck ist zu klein, die rechte Braut sitzt noch daheim.” Der Prinz sieht das Blut im Schuh.Er reitet noch einmal zu der Familie und fragt den reichen Mann, ob er noch eine Tochter habe: „Nur von meiner verstorbenen Frau ist noch ein kleines verbuttetes Aschenputtel da: das kann unmöglich die Braut sein”, sagt der Mann. Doch der Prinz will das Aschenputtel sehen.

Natürlich passt Aschenputtel der Schuh wie angegossen.Der Prinz erkennt seine hübsche Tänzerin. Er weiß, dass sie die Richtige ist. „Rucke di guck, rucke di guck,
kein Blut im Schuck: der Schuck ist nicht zu klein, die rechte Braut, die führt er heim”, gurren die Tauben.Zur Hochzeit wollen sich die Stiefschwestern einschleimen.Doch die Tauben picken beiden jeweils ein Auge aus.Für ihr Bosheit und ihre Falschheit sollen sie ihr Leben lang gestraft sein.";
        return "Aschenputtel";
    }

    private static bool goToToilet(int sleepTime)
    {
        Console.WriteLine("Ok, lass uns auf die Toilette gehn");
        Thread.Sleep(sleepTime);
        Console.WriteLine("Flush");
        Console.WriteLine();
        return true;
    }

    private static bool goAndDrink(int sleepTime)
    {
        Console.WriteLine("Wir holen uns ein leckeres Glas Milch.");
        Thread.Sleep(sleepTime);
        Console.WriteLine("Gluck");
        Thread.Sleep(sleepTime);
        Console.WriteLine("Gluck");
        Thread.Sleep(sleepTime);
        Console.WriteLine("Gluck");
        Thread.Sleep(sleepTime);
        Console.WriteLine("Ahhhhh");
        Thread.Sleep(sleepTime);
        return true;
    }

    private static bool canNotSleep(int sleepTime)
    {
        Thread.Sleep(sleepTime);
        Console.WriteLine("Willst du vielleicht eine andere Geschichte hören?");
        int fiftyFifty = new Random().Next(1, 3);
        for (int i = 0; i < 5; i++)
        {
            Console.Write("m");
            Thread.Sleep(100);
        }
        for (int i = 0; i < 5; i++)
        {
            Console.Write(".");
            Thread.Sleep(100);
        }
        Console.WriteLine();
        if (fiftyFifty == 1)
        {
            Console.WriteLine("ja");
            Thread.Sleep(sleepTime);
            Console.WriteLine("Puh, ok ok");
            return false;
        }
        else
        {
            Console.WriteLine("Nein, die Geschichte gefällt mir");
        }
        return true;
    }

    private static bool anotherStory(int sleepTime)
    {
        Thread.Sleep(sleepTime);
        Console.WriteLine("Ok ok.");
        return false;
    }


    private static string lastStoryToldTitle = "";

    private void ausgabe(String aus) => Console.WriteLine(aus);
        

    static thingsTheBabyWillDo goAndEat = (sleepTime) =>
    {
        Console.WriteLine("Komm, wir holen uns einen Keks.");
        Thread.Sleep(5000);
        Console.WriteLine("Schmatz");
        Thread.Sleep(500);
        Console.WriteLine("Schmatz");
        Thread.Sleep(500);
        Console.WriteLine("Schmatz");
        Thread.Sleep(500);
        Console.WriteLine("mmmmm Lecker");
        Thread.Sleep(5000);
        return true;
    };


    private static bool startTellingAStory()
    {

        //TODO: Define class with string and the function and call the function
        // -> use interface!!
        List<string> whatBabyCanWant = new List<string>();
        whatBabyCanWant.Add("Papa, ich muss auf die Toilette");
        whatBabyCanWant.Add("Papa, ich habe durst");
        whatBabyCanWant.Add("Papa, ich kann nicht schlafen");
        whatBabyCanWant.Add("Papa, ich will eine andere Geschichte");
        whatBabyCanWant.Add("Papa, ich hab irgendwie Hunger");

        List<thingsTheBabyWillDo> babyDoing = new List<thingsTheBabyWillDo>();
        babyDoing.Add(goToToilet);
        babyDoing.Add(goAndDrink);
        babyDoing.Add(canNotSleep);
        babyDoing.Add(anotherStory);
        babyDoing.Add(goAndEat);

        List<BTS> listOfBetTimeStories = new List<BTS>();
        listOfBetTimeStories.Add(HaenselUndGraetel);
        listOfBetTimeStories.Add(Rotkaeppchen);
        listOfBetTimeStories.Add(Aschenputtel);

        Console.WriteLine("So mein Schatz, welche Geschichte möchtest du heute lesen? Aschenputtel, Rotkäppchen oder Hänsel und Grätl");
        string chosenStory = Console.ReadLine();
        
        string story = "";
        bool bFound = false;
        
        string thisTimeStoryToldTitle = "";

        do
        {
            foreach (BTS storyToRead in listOfBetTimeStories)
            {
                if((thisTimeStoryToldTitle = storyToRead(out story)).Equals(chosenStory))
                {           
                    //Console.WriteLine(story);
                    bFound = true;
                    break;
                }
            }

            if (!bFound)
            {
                Console.WriteLine("Schatz, leider kenne ich diese Geschichte nicht, kannst du bitte eine von denen wählen, die ich vorgeschlagen habe?");
                chosenStory = Console.ReadLine();
            }
            else if(thisTimeStoryToldTitle.Equals(lastStoryToldTitle))
            {
                Console.WriteLine("Schatz, diese Geschichte hatten wir gerade, wähl bitte eine andere.");
                chosenStory = Console.ReadLine();
                bFound = false;
            }            

        }
        while (!bFound);        

        lastStoryToldTitle = thisTimeStoryToldTitle;

        int probability = 50;
        int valueToCompareProbability = new Random().Next(1, 101);

        for (int i = 0; i < story.Length; i++)
        {
            Console.Write(story[i]);

            if (story[i].ToString().Equals("."))
            {
                Thread.Sleep(2000);
            }
            else
            {
                Thread.Sleep(50);
            }            

            if (i % 100 == 0 && i > 0)
            {
                if (probability > valueToCompareProbability)
                {
                    int indexWhatHappens = new Random().Next(0, whatBabyCanWant.Count);
                    Console.WriteLine();
                    Console.WriteLine(whatBabyCanWant[indexWhatHappens]);
                    if (!babyDoing[indexWhatHappens](2000))
                    {//ok baby wants another story
                        return false;
                    }
                    Console.WriteLine();
                    probability = 50;
                }

                //probability increases by <5-10%
                probability += new Random().Next(5, 10);
                //Console.WriteLine();
                //Console.WriteLine(probability + "%");
                //Console.WriteLine();
            }
        }


        return true;
    }

    public static void Main(string[] args)
    {
        bool bStoryFinished = false;
        while (!bStoryFinished)
        {
            bStoryFinished = startTellingAStory();
        }
    }
}