namespace LowBank.Windows
{
    public static class StringExtensions
    {
        public static decimal ConvertDecimalString(this string decimalString)
        {
            List<char> decimalChars = new List<char>();

            foreach (char caracter in decimalString)
            {
                // Validar se é numero ou . ou ,
                if (caracter == '.' || caracter == ',' || char.IsDigit(caracter))
                {
                    // usa esse caracter
                    decimalChars.Add(caracter);
                }
            }

            string textoSaldo = new string(decimalChars.ToArray());
            var saldo = decimal.Parse(textoSaldo);
            return saldo;
        }
    }
}
