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

    if (number.Length < 7) {
        Console.WriteLine(number );
        for (int i = 0; i < 4; i++) {
            int digit = number.Length - i;
            string thousands = int.Parse(number[i].ToString()) > 1 ? NumberToText(int.Parse(number[i].ToString())) + " mil " : "mil ";
            int rest = int.Parse(number.ToString().Remove(0, 1));
            return thousands + NumberToText(rest);
        }
    }

    return "";

}



Console.WriteLine("Type ya numba");
String number = Console.ReadLine();


Console.WriteLine(NumberToText(int.Parse(number)));
