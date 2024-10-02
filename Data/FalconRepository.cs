using Aviation.Models;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Numerics;

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
            return _connection.Query<Falcon>("SELECT * FROM FALCON;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _connection.Query<Category>("SELECT * FROM FALCON;");
        }

        public Falcon GetFalcon(int id)
        {
            if (id == 0)
            {
                throw new Exception("the id is 0");
            }
            var result = _connection.Query<Falcon>("SELECT * FROM FALCON WHERE FALCONID = @id", new { id = id }).FirstOrDefault();
            if (result == null)
            {
                throw new Exception("No event found with the given ID.");
            }
            return result;
        }

        public Falcon AssignCategory()
        {
            var categoryList = GetCategories();
            var plane = new Falcon();
            plane.Categories = categoryList;
            return plane;
        }

        public void InsertFalcon(Falcon planeToInsert)
        {
            _connection.Execute("INSERT INTO FALCON (AIRFRAME, MANUFACTURER, FALCONID, AIRCRAFT_TYPE, CREW, " +
                "SEATING_CAPACITY, LENGTH, WINGSPAN, HEIGHT, POWERPLANT, MAX_SPEED, DISTANCE_RANGE, CEILING) " +
                "VALUES (@Airframe, @Manufacturer, @FalconID, @Aircraft_Type, @Crew, @Seating_Capacity, @Length, " +
                "@Wingspan, @Height, @Powerplant, @Max_Speed, @Distance_Range, @ceiling );",
                 new
                 {
                     airframe = planeToInsert.Airframe,
                     manufacturer = planeToInsert.Manufacturer,
                     falconID = planeToInsert.FalconID,
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


        public void DeleteFalcon(Falcon plane)
        {
            
            _connection.Execute("DELETE FROM FALCON WHERE FALCONID = @falconID;", new { falconID = plane.FalconID });
        }


        public void UpdateFalcon(Falcon plane)
        {
            _connection.Execute("UPDATE FALCON SET AIRFRAME = @Airframe, MANUFACTURER = @Manufacturer, " +
            "AIRCRAFT_TYPE = @Aircraft_Type, CREW = @Crew, SEATING_CAPACITY = @Seating_Capacity, LENGTH = @Length, " +
            "WINGSPAN = @Wingspan, HEIGHT = @Height, POWERPLANT = @Powerplant, MAX_SPEED = @Max_Speed, " +
            "DISTANCE_RANGE = @Distance_Range, `CEILING` = @Ceiling WHERE FALCONID = @FalconID;",
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
                    FalconID = plane.FalconID  
                });


        }
    }
}
