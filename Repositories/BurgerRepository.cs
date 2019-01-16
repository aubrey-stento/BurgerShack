using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
    public class BurgerRepository
    {
        private readonly IDbConnection _db;

        public BurgerRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Burger> GetAll()
        {
            return _db.Query<Burger>("SELECT * FROM Burgers");
        }


        public Burger GetBurgerById(int id)
        {
            return _db.QueryFirstOrDefault<Burger>($"SELECT * FROM Burgers WHERE id = @id", new { id });
        }

        public Burger AddBurger(Burger newburger)
        {

            int id = _db.ExecuteScalar<int>("INSERT INTO Burgers (Name, Description, Price)"
                         + " VALUES(@Name, @Description, @Price); SELECT LAST_INSERT_ID()", new
                         {
                             newburger.Name,
                             newburger.Description,
                             newburger.Price
                         });
            newburger.Id = id;
            return newburger;

        }

        public Burger GetOneByIdAndUpdate(int id, Burger newburger)
        {
            {
                return _db.QueryFirstOrDefault<Burger>($@"
                UPDATE Burgers SET  
                    Name = @Name,
                    Description = @Description,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM Burgers WHERE id = {id};", newburger);
            }
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute(@"
                DELETE FROM Burgers WHERE Id = @id
            ", id);
            return success > 0 ? "successfully deleted" : "ERROR, not able to delete";
        }

    }
}