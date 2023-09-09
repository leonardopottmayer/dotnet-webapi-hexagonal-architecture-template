using System.Text.RegularExpressions;

namespace HexagonalArchitecture.Domain.Utils.AuxiliarTypes
{
    public class CEP
    {
        public bool IsValid { get; private set; }
        public string Code { get; private set; }
        public string Suffix { get; private set; }
        public string OriginalValue { get; private set; }
        public string Raw { get; private set; }
        public string Formatted { get; private set; }

        public CEP(string cep)
        {
            OriginalValue = cep;

            Configure();
        }

        private void Configure()
        {
            // Set raw
            string regexPattern = "[^0-9]";
            Raw = Regex.Replace(OriginalValue, regexPattern, "");

            ValidateCEP();
        }

        /// <summary>
        /// Validates the CEP number
        /// </summary>
        private void ValidateCEP()
        {
            if (Raw.Length == 8)
            {
                Code = Raw.Substring(0, 5);
                Suffix = Raw.Substring(5, 3);

                Formatted = Code + "-" + Suffix;

                IsValid = Regex.IsMatch(Formatted, ("[0-9]{5}-[0-9]{3}"));

                return;
            }

            IsValid = false;
        }

        /// <summary>
        /// Get the formatted CEP
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

        public static string Format(string cep)
        {
            return new CEP(cep).ToString();
        }

        /// <summary>
        /// Checks if a CEP string is valid
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        public static bool Validate(string cep)
        {
            return new CEP(cep).IsValid;
        }

        /// <summary>
        /// Unformats a CEP
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        public static string GetPlain(string cep)
        {
            return new CEP(cep).ToPlainString();
        }
    }
}
