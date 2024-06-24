using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyApiREST_Net8.Context;
using proyApiREST_Net8.Models;

namespace proyApiREST_Net8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Person>>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult> Listado()
        {
            List<Person> listado = _context.Persons.ToList();
            return StatusCode(StatusCodes.Status200OK, listado);
        }

        [HttpPost]
        [Route("insertar")]
        public async Task<ActionResult> inserta([FromBody] Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Ok");
        }
    }
}