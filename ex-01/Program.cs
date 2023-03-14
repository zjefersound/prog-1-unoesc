static String NumberToText(int numberToConvert)
{
    int absoluteNumber = Math.Abs(numberToConvert);
    String number = absoluteNumber.ToString();

    if (absoluteNumber < 20)
    {
        string[] firstNumbers = { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
        return firstNumbers[absoluteNumber];
    }

    for (int i = 0; i < number.Length - 1; i++)
    {
        string[] tens = { "", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
        string[] hundreds = { "cem", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
        string[] thousands = { "mil", "dois mil", "três mil", "quatro mil", "cinco mil", "seis mil", "sete mil", "oito mil", "nove mil" };
        string[][] numberSets = { tens, hundreds, thousands };

        int digit = number.Length - i;
        string currentText = numberSets[digit - 2][int.Parse(number[i].ToString()) - 1];
        int rest = int.Parse(number.ToString().Remove(0, 1));
        string connector = digit < 4 ? " e " : " ";
        string nextNumber = rest > 0 ? connector + NumberToText(rest) : " ";
        return currentText + nextNumber;
    }

    return "";
}



Console.WriteLine("Type ya numba");
String number = Console.ReadLine();


Console.WriteLine(NumberToText(int.Parse(number)));
