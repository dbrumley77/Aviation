using Aviation.Models;

namespace Aviation.Data
{
    public interface IGulfstreamRepository
    {

        public IEnumerable<Gulfstream> GetAllGulfstream();

        public IEnumerable<Category> GetCategories();

        public Gulfstream GetGulfstream(int id);

        public Gulfstream AssignCategory();

        public void InsertGulfstream(Gulfstream planeToInsert);

        public void DeleteGulfstream(Gulfstream plane);

        public void UpdateGulfstream(Gulfstream plane);

    }
}
