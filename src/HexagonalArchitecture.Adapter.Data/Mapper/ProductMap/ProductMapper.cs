using HexagonalArchitecture.Domain.Entities;

namespace HexagonalArchitecture.Adapter.Data.Mapper.ProductMap
{
    public class ProductMapper : AuditableEntityClassMapper<Product>
    {
        public ProductMapper()
        {
            ToTable("product");

            Map(i => i.Id).ToColumn("id").IsKey();
            Map(i => i.Name).ToColumn("name");
            Map(i => i.Price).ToColumn("price");
        }
    }
}
