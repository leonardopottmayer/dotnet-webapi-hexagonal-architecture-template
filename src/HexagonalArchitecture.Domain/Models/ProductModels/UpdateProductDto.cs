using HexagonalArchitecture.Domain.Contracts;

namespace HexagonalArchitecture.Domain.Models.ProductModels
{
    public class UpdateProductDto : IValidableFields
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public UpdateProductDto(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public bool FieldsAreValied()
        {
            bool isValid = true;

            if (Name.Trim().Length < 1)
                isValid = false;
            if (Convert.ToDouble(Price) < 0.01)
                isValid = false;

            return isValid;
        }

        public dynamic ValidateFields()
        {
            throw new NotImplementedException();
        }
    }
}
