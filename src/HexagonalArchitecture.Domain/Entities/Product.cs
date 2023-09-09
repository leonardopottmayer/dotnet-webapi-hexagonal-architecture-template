namespace HexagonalArchitecture.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public Product() { }
        public Product(long id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
