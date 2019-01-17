using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
    public class CustomerRepository
    {
        private readonly IDbConnection _db;

        public CustomerRepository(IDbConnection db)
        {
            _db = db;
        }



        public Customer AddCustomer(Customer newcustomer)
        {

            int id = _db.ExecuteScalar<int>("INSERT INTO Customers (Name)"
                         + " VALUES(@Name); SELECT LAST_INSERT_ID()", new
                         {
                             newcustomer.Name,

                         });
            newcustomer.Id = id;
            return newcustomer;

        }

        public bool DeleteCustomer(int id)
        {
            int success = _db.Execute(@"DELETE FROM Customers WHERE id = @id", new { id });
            return success != 0;
        }

    }
}