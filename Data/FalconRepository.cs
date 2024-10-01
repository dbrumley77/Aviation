using Aviation.Models;
using Dapper;
using System.Data;

namespace Aviation.Data
{
    public class FalconRepository : IFalconRepository
    {
        private readonly IDbConnection _connection; //Database Connection

        public FalconRepository(IDbConnection connection)  //Constructor for Database Connection
        {
            _connection = connection;
        }

        

        public IEnumerable<Falcon> GetAllFalcon()
        {
            return _connection.Query<Falcon>("SELECT * FROM falcon;");
        }
    }
}
