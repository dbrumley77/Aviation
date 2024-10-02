using Aviation.Models;

namespace Aviation.Data
{
    public interface IFalconRepository
    {
        public IEnumerable<Falcon> GetAllFalcon();

        public IEnumerable<Category> GetCategories();

        public Falcon GetFalcon(int id);

        public Falcon AssignCategory();

        public void InsertFalcon(Falcon planeToInsert);

        public void DeleteFalcon(Falcon plane);

        public void UpdateFalcon(Falcon plane);

       
    }
}
