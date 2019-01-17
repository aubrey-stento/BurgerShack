using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerRepository _customerRepo;
        public CustomersController(CustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }



        // POST api/Customers
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            Customer result = _customerRepo.AddCustomer(customer);
            return Created("/api/customers/" + result.Id, result);
        }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        // {
        //     Customer result = _customerRepo.GetOneByIdAndUpdate(id, customer);
        //     if (result != null)
        //     {
        //         return result;
        //     }
        //     return NotFound();
        // }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            if (_customerRepo.DeleteCustomer(id))
            {
                return Ok("successfully deleted");
            }
            return BadRequest("ERROR, not able to delete"); ;
        }
    }
}
