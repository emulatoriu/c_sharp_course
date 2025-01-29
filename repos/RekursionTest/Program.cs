using RekursionTest;

class MainClass
{

    //private static void printTillOne(int number)
    //{
    //    if(number <= 0)
    //    {
    //        return;
    //    }
    //    Console.WriteLine(number);
    //    printTillOne(number -1);
    //}

    public static void Main(String[] args)
    {
        //printTillOne(10);
        Person karli = new Person("Karli", 20);

        Person karliFather = new Person("Franz", 40);
        Person karliMother = new Person("Helga", 39);

        Person karliMotherFather = new Person("Peppi", 60);
        Person karliMotherMother = new Person("Susi", 59);

        Person karliOpa = new Person("Herbert", 60);
        Person karliOma = new Person("Gertrude", 59);

        karli.leftChild = karliFather;
        karli.rightChild = karliMother;
        karliFather.leftChild = karliOpa;
        karliFather.rightChild = karliOma;
        karliMother.leftChild = karliMotherFather;
        karliMother.rightChild = karliMotherMother;

        Console.WriteLine(new PersonService().getPerson("Susi", karli).Age);
    }
}