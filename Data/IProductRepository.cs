using Aviation.Models;

namespace Aviation.Data
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
    }
}
