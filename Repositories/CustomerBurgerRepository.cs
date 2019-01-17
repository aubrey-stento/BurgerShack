using System.Collections.Generic;
using System.Data;
using Dapper;
using BurgerShack.Models;

namespace BurgerShack.Repositories
{
    public class CustomerBurgerRepository
    {
        private readonly IDbConnection _db;
        public CustomerBurgerRepository(IDbConnection db)
        {
            _db = db;

        }



        //GetBooksByCustomerId
        public IEnumerable<Burger> GetBurgersByCustomerId(int id)
        {
            return _db.Query<Burger>($@"
        SELECT * FROM customerburgers cb
        INNER JOIN burgers b ON b.id = cb.burgerId
        WHERE (customerId = @id);
      ", new { id });
        }

        //         //GetLibrariesByBookId
        //         public IEnumerable<Library> GetLibrariesByBookId(int id)
        //         {
        //             return _db.Query<Library>($@"
        //         SELECT * FROM librarybooks lb
        //         INNER JOIN library l ON l.id = lb.libraryId
        //         WHERE (bookId = @id);
        //       ", new { id });
        //         }


        //AddCustomerBurger
        public CustomerBurger AddCustomerBurger(CustomerBurger cb)
        {
            int id = _db.ExecuteScalar<int>(@"
              INSERT INTO CustomerBurgers(customerId, burgerId)
              VALUES(@CustomerId, @BurgerId);
              SELECT LAST_INSERT_ID();
              ", cb);
            cb.Id = id;
            return cb;
        }

        //         //DeleteLibraryBook

        //         public bool DeleteLibraryBook(LibraryBook lb)
        //         {
        //             int success = _db.Execute(@"DELETE FROM LibraryBooks WHERE bookId = @BookId AND libraryId = @LibraryId", lb);
        //             return success != 0;

        //         }


    }
}