static string getLastCharacters(string text, int charactersCount)
{
    int length = text.Length;
    int offset = Math.Max(0, length - charactersCount);
    return text.Substring(offset);
}

static String NumberToText(double numberToConvert)
{
    Dictionary<long, string[]> bigNumberDictionary = new Dictionary<long, string[]>();
    bigNumberDictionary.Add(7, new string[] { " mil", "mil" });
    bigNumberDictionary.Add(10, new string[] { " milhões", "um milhão" });
    bigNumberDictionary.Add(13, new string[] { " bilhões", "um bilhão" });
    bigNumberDictionary.Add(16, new string[] { " trilhões", "um trilhão" });

    long[] supportedNumbers = { (long)Math.Pow(10, 3), (long)Math.Pow(10, 6), (long)Math.Pow(10, 9), (long)Math.Pow(10, 12) };


    long absoluteNumber = Math.Abs(Convert.ToInt64(Math.Truncate(numberToConvert)));
    String number = absoluteNumber.ToString();

    if (absoluteNumber < 20)
    {
        string[] firstNumbers = { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
        return firstNumbers[absoluteNumber];
    }

    if (number.Length < 4)
    {
        for (int i = 0; i < number.Length - 1; i++)
        {
            string[] tens = { "", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            string[] hundreds = { "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
            string[][] numberSets = { tens, hundreds };

            long digit = number.Length - i;
            string currentText = digit - 2 == 1 && long.Parse(number[i].ToString()) - 1 == 0 ? "cem" : numberSets[digit - 2][long.Parse(number[i].ToString()) - 1];
            long rest = long.Parse(number.ToString().Remove(0, 1));
            string connector = digit < 4 ? " e " : " ";
            string nextNumber = rest > 0 ? connector + NumberToText(rest) : " ";
            return currentText + nextNumber;
        }
    }

    foreach (long supportedNumber in supportedNumbers)
    {
        long supportedNumberMaxLength = supportedNumber.ToString().Length + 3;
        if (number.Length < supportedNumberMaxLength)
        {
            long currentNumericalUnity = (long)(absoluteNumber / supportedNumber);

            string currentNumericalUnityText = currentNumericalUnity > 1
                ? NumberToText(currentNumericalUnity) + bigNumberDictionary.GetValueOrDefault(supportedNumberMaxLength)[0]
                : bigNumberDictionary.GetValueOrDefault(supportedNumberMaxLength)[1];
            long rest = long.Parse(getLastCharacters(number, 3));
            string connector = rest > 0 && rest < 1000 ? " e " : " ";

            string nextNumber = rest > 0 ? connector + NumberToText(rest) : "";
            return currentNumericalUnityText + nextNumber;
        }
    }

    return "";

}

static String DecimalNumberToText(double numberToConvert)
{
    long absoluteNumber = Math.Abs(Convert.ToInt64(Math.Truncate(numberToConvert)));
    int decimalNumber = Convert.ToInt32(Math.Truncate((numberToConvert - Math.Truncate(numberToConvert)) * 100));
    string absoluteNumberText = NumberToText(absoluteNumber);
    string decimalNumberText = decimalNumber > 0 ? NumberToText(decimalNumber) : "";
    string connector = decimalNumber > 0 ? " virgula " : "";

    return absoluteNumberText + connector + decimalNumberText;
}



Console.WriteLine("Type ya numba");
String number = Console.ReadLine();


Console.WriteLine(DecimalNumberToText(double.Parse(number)));
