static string getLastCharacters(string text, int charactersCount)
{
    int length = text.Length;
    int offset = Math.Max(0, length - charactersCount);
    return text.Substring(offset);
}

static String NumberToText(int numberToConvert)
{
    int absoluteNumber = Math.Abs(numberToConvert);
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
            string[] hundreds = { "cem", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
            string[][] numberSets = { tens, hundreds };

            int digit = number.Length - i;
            string currentText = numberSets[digit - 2][int.Parse(number[i].ToString()) - 1];
            int rest = int.Parse(number.ToString().Remove(0, 1));
            string connector = digit < 4 ? " e " : " ";
            string nextNumber = rest > 0 ? connector + NumberToText(rest) : " ";
            return currentText + nextNumber;
        }
    }

    Dictionary<int, string[]> bigNumberDictionary = new Dictionary<int, string[]>();
    bigNumberDictionary.Add(7, new string[] { " mil", "mil" });
    bigNumberDictionary.Add(10, new string[] { " milhões", "um milhão" });
    bigNumberDictionary.Add(13, new string[] { " bilhões", "um bilhão" });
    bigNumberDictionary.Add(16, new string[] { " trilhões", "um trilhão" });

    int[] supportedNumbers = { (int)Math.Pow(10, 3), (int)Math.Pow(10, 6), (int)Math.Pow(10, 9), (int)Math.Pow(10, 12) };

    foreach (int supportedNumber in supportedNumbers)
    {
        int supportedNumberMaxLength = supportedNumber.ToString().Length + 3;
        if (number.Length < supportedNumberMaxLength)
        {
            int currentNumericalUnity = (int)(absoluteNumber / supportedNumber);

            string currentNumericalUnityText = currentNumericalUnity > 1
                ? NumberToText(currentNumericalUnity) + bigNumberDictionary.GetValueOrDefault(supportedNumberMaxLength)[0]
                : bigNumberDictionary.GetValueOrDefault(supportedNumberMaxLength)[1];
            int rest = int.Parse(getLastCharacters(number, 3));
            string connector = rest > 0 && rest < 1000 ? " e " : " ";

            string nextNumber = rest > 0 ? connector + NumberToText(rest) : "";
            return currentNumericalUnityText + nextNumber;
        }
    }

    return "";

}



Console.WriteLine("Type ya numba");
String number = Console.ReadLine();


Console.WriteLine(NumberToText(int.Parse(number)));
