using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
    public class SideRepository
    {
        private readonly IDbConnection _db;

        public SideRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Side> GetAll()
        {
            return _db.Query<Side>("SELECT * FROM Sides");
        }


        public Side GetSideById(int id)
        {
            return _db.QueryFirstOrDefault<Side>($"SELECT * FROM Sides WHERE id = @id", new { id });
        }

        public Side AddSide(Side newside)
        {

            int id = _db.ExecuteScalar<int>("INSERT INTO Sides (Name, Description, Price)"
                         + " VALUES(@Name, @Description, @Price); SELECT LAST_INSERT_ID()", new
                         {
                             newside.Name,
                             newside.Description,
                             newside.Price
                         });
            newside.Id = id;
            return newside;

        }

        public Side GetOneByIdAndUpdate(int id, Side newside)
        {
            {
                return _db.QueryFirstOrDefault<Side>($@"
                UPDATE Sides SET  
                    Name = @Name,
                    Description = @Description,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM Sides WHERE id = {id};", newside);
            }
        }

        public bool FindByIdAndRemove(int id)
        {
            var success = _db.Execute(@"
                DELETE FROM Sides WHERE id = @id
            ", new { id });
            return success > 0;
        }

    }
}