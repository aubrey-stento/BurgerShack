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
    public class SidesController : ControllerBase
    {
        private readonly SideRepository _sideRepo;
        public SidesController(SideRepository sideRepo)
        {
            _sideRepo = sideRepo;
        }

        // GET api/Sides
        [HttpGet]
        public ActionResult<IEnumerable<Side>> Get()
        {
            return Ok(_sideRepo.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Side> Get(int id)
        {
            Side result = _sideRepo.GetSideById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // POST api/Sides
        [HttpPost]
        public ActionResult<Side> Post([FromBody] Side side)
        {
            Side result = _sideRepo.AddSide(side);
            return Created("/api/sides/" + result.Id, result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Side> Put(int id, [FromBody] Side side)
        {
            Side result = _sideRepo.GetOneByIdAndUpdate(id, side);
            if (result != null)
            {
                return result;
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            if (_sideRepo.FindByIdAndRemove(id))
            {
                return Ok("successfully deleted");
            }
            return BadRequest("ERROR, not able to delete"); ;
        }
    }
}
