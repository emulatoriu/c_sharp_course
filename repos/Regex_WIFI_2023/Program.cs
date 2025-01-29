// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

//Console.WriteLine("Hello, World!");

bool isMatch;
//isMatch = Regex.Match("Kas*****Kasperl", @"^Kas").Success;
//Console.WriteLine(isMatch);
//isMatch = Regex.Match("Kas*****Kasperl", @"erl$").Success;
//Console.WriteLine(isMatch);
//isMatch = Regex.Match("KasKas", @"^Kas[A-Za-z]*Kas$").Success;
//Console.WriteLine(isMatch);
//isMatch = Regex.Match("Kasnockerln", @"sno").Success;
//Console.WriteLine(isMatch);
//isMatch = Regex.Match("Mississippi", @"ssi+").Success; //ss, ssi, ssiiiiiiiiiiiiiiiii
//Console.WriteLine(isMatch);
//isMatch = Regex.Match("Missssiippi", @"ssi?").Success; //Mississippi Missssppi
//Console.WriteLine(isMatch);
//isMatch = Regex.Match("Mississippi", @"is{2}").Success;
//Console.WriteLine(isMatch);
//isMatch = Regex.Match("achbnfdfach", @"(ach)[A-Za-z]*\1").Success;
//Console.WriteLine(isMatch);

//isMatch = Regex.Match("adfadadddaa", @"^[ad]*$").Success;
//Console.WriteLine(isMatch);
//isMatch = Regex.Match("591", @"^[1-9]\d").Success;
//Console.WriteLine(isMatch);


//isMatch = Regex.Match("_a fd_ k_ fda_", @"^\w[\w\s]*\w$").Success;
//Console.WriteLine(isMatch);

//isMatch = Regex.Match("1A", @"[a-fA-F0-9]{1,1}").Success;
//Console.WriteLine(isMatch);

isMatch = Regex.Match("dar", @"d(?!r)").Success;
Console.WriteLine(isMatch);

//0-9 (10 Zahlen = Decimalsystem)
//0-9A_F (16 Zahlne = Hexadezimal)
//0-1 (2 Zahlen = Binärsystem)
//0-7 = 0,1,2,3,4,5,6,7,10,11,12,13,14,15,16,17,20

//32 | 0
//4  | 4