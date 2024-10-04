using Aviation.Models;
using Dapper;
using System.Data;

namespace Aviation.Data
{
    public class GulfstreamRepository : IGulfstreamRepository

    {

        private readonly IDbConnection _connection; //Database Connection

        public GulfstreamRepository(IDbConnection connection)  //Constructor for Database Connection
        {
            _connection = connection;
        }


        public Gulfstream AssignCategory()
        {
            var categoryList = GetCategories();
            var plane = new Gulfstream();
            plane.Categories = categoryList;
            return plane;
        }
    

        public void DeleteGulfstream(Gulfstream plane)
        {
           _connection.Execute("DELETE FROM GULFSTREAM WHERE GULFSTREAMID = @gulfstreamID;", new { gulfstreamID = plane.GulfstreamID });
        }

        public IEnumerable<Gulfstream> GetAllGulfstream()
        {
             return _connection.Query<Gulfstream>("SELECT * FROM GULFSTREAM;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _connection.Query<Category>("SELECT * FROM GULFSTREAM;");
        }

        public Gulfstream GetGulfstream(int id)
        {
            if (id == 0)
            {
                throw new Exception("the id is 0");
            }
            var result = _connection.Query<Gulfstream>("SELECT * FROM GULFSTREAM WHERE GULFSTREAMID = @id", new { id = id }).FirstOrDefault();
            if (result == null)
            {
                throw new Exception("No event found with the given ID.");
            }
            return result;
        }

        public void InsertGulfstream(Gulfstream planeToInsert)
        {
            _connection.Execute("INSERT INTO GULFSTREAM (AIRFRAME, MANUFACTURER, GULFSTREAMID, AIRCRAFT_TYPE, CREW, " +
                "SEATING_CAPACITY, LENGTH, WINGSPAN, HEIGHT, POWERPLANT, MAX_SPEED, DISTANCE_RANGE, CEILING) " +
                "VALUES (@Airframe, @Manufacturer, @GulfstreamID, @Aircraft_Type, @Crew, @Seating_Capacity, @Length, " +
                "@Wingspan, @Height, @Powerplant, @Max_Speed, @Distance_Range, @ceiling );",
                 new
                 {
                     airframe = planeToInsert.Airframe,
                     manufacturer = planeToInsert.Manufacturer,
                     gulfstreamID = planeToInsert.GulfstreamID,
                     aircraft_type = planeToInsert.Aircraft_Type,
                     crew = planeToInsert.Crew,
                     seating_capacity = planeToInsert.Seating_Capacity,
                     length = planeToInsert.Length,
                     wingspan = planeToInsert.Wingspan,
                     height = planeToInsert.Height,
                     powerplant = planeToInsert.Powerplant,
                     max_speed = planeToInsert.Max_Speed,
                     distance_range = planeToInsert.Distance_Range,
                     ceiling = planeToInsert.Ceiling
                 });
        }

        public void UpdateGulfstream(Gulfstream plane)
        {
            _connection.Execute("UPDATE GULFSTREAM SET AIRFRAME = @Airframe, MANUFACTURER = @Manufacturer, " +
            "AIRCRAFT_TYPE = @Aircraft_Type, CREW = @Crew, SEATING_CAPACITY = @Seating_Capacity, LENGTH = @Length, " +
            "WINGSPAN = @Wingspan, HEIGHT = @Height, POWERPLANT = @Powerplant, MAX_SPEED = @Max_Speed, " +
            "DISTANCE_RANGE = @Distance_Range, `CEILING` = @Ceiling WHERE GULFSTREAMID = @GulfstreamID;",
            new
            {
                Airframe = plane.Airframe,
                Manufacturer = plane.Manufacturer,
                Aircraft_Type = plane.Aircraft_Type,
                Crew = plane.Crew,
                Seating_Capacity = plane.Seating_Capacity,
                Length = plane.Length,
                Wingspan = plane.Wingspan,
                Height = plane.Height,
                Powerplant = plane.Powerplant,
                Max_Speed = plane.Max_Speed,
                Distance_Range = plane.Distance_Range,
                Ceiling = plane.Ceiling,
                GulfstreamID = plane.GulfstreamID
            });
            
        }
    }
}
