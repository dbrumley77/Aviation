using Aviation.Models;
using Dapper;
using System.Data;

namespace Aviation.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection; //Database Connection

        public ProductRepository(IDbConnection connection)  //Constructor for Database Connection
        {
            _connection = connection;
        }

         public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }
    }
}
