using HexagonalArchitecture.Domain.Contracts;

namespace HexagonalArchitecture.Domain.Models.ProductModels
{
    public class ProductDto : IValidableFields
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductDto() { }
        public ProductDto(long id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public bool FieldsAreValied()
        {
            bool isValid = true;

            if (Id == 0)
                isValid = false;
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
