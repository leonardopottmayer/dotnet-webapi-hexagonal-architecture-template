using System.Text.RegularExpressions;

namespace HexagonalArchitecture.Domain.Utils.AuxiliarTypes
{
    public class CPF
    {
        public bool IsValid { get; private set; }
        public string OriginalValue { get; private set; }
        public string Raw { get; private set; }
        public string Formatted { get; private set; }

        public CPF(string cpf)
        {
            OriginalValue = cpf;

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

            ValidateCPF();
        }

        /// <summary>
        /// Validates the document number
        /// </summary>
        private void ValidateCPF()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;

            int soma;
            int resto;

            var cpf = Raw.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                IsValid = false;
                return;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            IsValid = cpf.EndsWith(digito);

            if(IsValid)
                Formatted = Convert.ToUInt64(Raw).ToString(@"000\.000\.000\-00");
        }

        /// <summary>
        /// Get the formatted CPF
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
        /// Formats a CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static string Format(string cpf)
        {
            return new CPF(cpf).ToString();
        }

        /// <summary>
        /// Checks if a CPF string is valid
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool Validate(string cpf)
        {
            return new CPF(cpf).IsValid;
        }

        /// <summary>
        /// Unformats a CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static string GetPlain(string cpf)
        {
            return new CPF(cpf).ToPlainString();
        }
    }
}
