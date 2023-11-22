using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdressBookWebApiManager.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdressBookWebApiManager.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IAdressBookService service;
        public ContactsController(IAdressBookService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Person>))]
        public IActionResult getAllPeople() => Ok(service.getAllPeople());

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Person))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult addPerson([FromBody] Person person)
        {
            if (person.id < 1 || person.email.Length == 0) return BadRequest();
            service.addPerson(person);
            return Created("", person);
        }

        [HttpDelete]
        [Route("{personId}")]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult deletePerson(int personId)
        {
            if (personId < 1) return BadRequest();

            try
            {
                service.deletePerson(personId);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        [Route("/findByName")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Person>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult findPersonByName([FromBody] string name)
        {
            if (name.Length == 0) return BadRequest();
            try
            {
                return Ok(service.findPersonByName(name));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}

