using Aviation.Models;

namespace Aviation.Data
{
    public interface IFalconRepository
    {
        public IEnumerable<Falcon> GetAllFalcon();
    }
}
