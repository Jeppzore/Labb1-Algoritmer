Labb1();

static void Labb1()
{
    Console.Write("Please enter a combination of letters and characters: ");
    string input = Console.ReadLine();
    string coloredNumbers;

    ulong coloredSum; //summan av färgade siffror
    ulong totalColoredSum = 0; //Totala summan av alla adderade färgade substrings (coloredSum)

    char[] numbers = input.ToCharArray();

    Console.WriteLine();
   
    for (int i = 0; i < numbers.Length; i++)
    {
        //Spara en char array temporärt för att kunna skapa en ny delsträng
        char[] storeNumbers = new char[numbers.Length];

        //Förhindrar j-loop att köras om numbers[i] inte innehåller en siffra
        if (char.IsNumber(numbers[i]))
        {
            storeNumbers[i] = numbers[i];


            for (int j = i + 1; j < numbers.Length; j++)
            {
                storeNumbers[j] = numbers[j];

                if (numbers[i] == numbers[j] && char.IsNumber(numbers[i]))
                {
                    coloredNumbers = new string(storeNumbers); //Sparar de sökta värdena i storeNumber i strängen coloredNumbers

                    //Det som skrivs innan coloredNumbers
                    Console.Write(input.Substring(0, input.IndexOf(coloredNumbers)));
                    //Det som skall skrivas ut i färg (coloredNumbers)
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(coloredNumbers);
                    //Det som skrivs efter coloredNumbers
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(input.Substring(j + 1));

                    //Ger ut string-summan av coloredNumbers till ulong coloredSum och tar bort överflödiga "\0" i coloredNumbers
                    ulong.TryParse(coloredNumbers.Replace("\0", ""), out coloredSum);


                    totalColoredSum += coloredSum;

                    break;
                }

                if (!char.IsDigit(numbers[i]) || !char.IsDigit(numbers[j]))
                {
                    break;
                }
            }
        }
    }
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Total value of the colored numbers = {totalColoredSum}");
    Console.ResetColor();
}