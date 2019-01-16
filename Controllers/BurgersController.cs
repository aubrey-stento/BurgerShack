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
    public class BurgersController : ControllerBase
    {
        private readonly BurgerRepository _burgerRepo;
        public BurgersController(BurgerRepository burgerRepo)
        {
            _burgerRepo = burgerRepo;
        }

        // GET api/Burgers
        [HttpGet]
        public ActionResult<IEnumerable<Burger>> Get()
        {
            return Ok(_burgerRepo.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Burger> Get(int id)
        {
            Burger result = _burgerRepo.GetBurgerById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // POST api/Burgers
        [HttpPost]
        public ActionResult<Burger> Post([FromBody] Burger burger)
        {
            Burger result = _burgerRepo.AddBurger(burger);
            return Created("/api/burgers/" + result.Id, result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Burger> Put(int id, [FromBody] Burger burger)
        {
            Burger result = _burgerRepo.GetOneByIdAndUpdate(id, burger);
            if (result != null)
            {
                return result;
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _burgerRepo.FindByIdAndRemove(id);
        }
    }
}
