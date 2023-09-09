using System.Text.RegularExpressions;

namespace HexagonalArchitecture.Domain.Utils.AuxiliarTypes
{
    public class CNPJ
    {
        public bool IsValid { get; private set; }
        public string OriginalValue { get; private set; }
        public string Raw { get; private set; }
        public string Formatted { get; private set; }

        public CNPJ(string cnpj)
        {
            OriginalValue = cnpj;

            Configure();
        }

        /// <summary>
        /// Configures the class
        /// </summary>
        private void Configure()
        {
            // Set raw
            string regexPattern = "[^0-9]";
            Raw = Regex.Replace(OriginalValue, regexPattern, "");

            ValidateCNPJ();
        }

        /// <summary>
        /// Validates the document number
        /// </summary>
        private void ValidateCNPJ()
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;
            int resto;

            string digito;
            string tempCnpj;

            var cnpj = Raw.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
            {
                IsValid = false;
                return;
            }

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            IsValid = cnpj.EndsWith(digito);

            if (IsValid)
                Formatted = Convert.ToUInt64(Raw).ToString(@"00\.000\.000\/0000\-00");
        }

        /// <summary>
        /// Get the formatted CNPJ
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return IsValid ? Formatted : null;
        }

        /// <summary>
        /// Get the CEP without any formatting, only numbers
        /// </summary>
        /// <returns></returns>
        public string ToPlainString()
        {
            return IsValid ? Raw : null;
        }

        /// <summary>
        /// Formats a CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static string Format(string cnpj)
        {
            return new CNPJ(cnpj).ToString();
        }

        /// <summary>
        /// Checks if a CNPJ string is valid
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static bool Validate(string cnpj)
        {
            return new CNPJ(cnpj).IsValid;
        }

        /// <summary>
        /// Unformats a CNPJ
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static string GetPlain(string cnpj)
        {
            return new CNPJ(cnpj).ToPlainString();
        }
    }
}
