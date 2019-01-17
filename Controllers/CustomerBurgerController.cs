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
    public class CustomerBurgerController : ControllerBase
    {
        // private readonly CustomerRepository _customerRepo;
        private readonly CustomerBurgerRepository _customerBurgerRepo;
        public CustomerBurgerController(CustomerBurgerRepository customerBurgerRepo)
        {
            _customerBurgerRepo = customerBurgerRepo;
        }



        [HttpPost]
        public ActionResult<string> Post([FromBody] CustomerBurger cb)
        {
            CustomerBurger result = _customerBurgerRepo.AddCustomerBurger(cb);
            return Created("/api/customerburger/" + result.Id, result);
        }
    }
}