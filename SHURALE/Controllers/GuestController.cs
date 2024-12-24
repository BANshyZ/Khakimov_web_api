using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHURALE.Models;

namespace SHURALE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        public CompHelperContext Context { get; }

        public GuestController(CompHelperContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Guest> guests = Context.Guests.ToList();
            return Ok(guests);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Guest? guest = Context.Guests.Where(x => x.Id == id).FirstOrDefault();
            if (guest == null)
            {
                return BadRequest("Not found");
            }
            return Ok(guest);
        }

        [HttpPost]
        public IActionResult Add(Guest guest)
        {
            Context.Guests.Add(guest);
            Context.SaveChanges();
            return Ok(guest);
        }
        [HttpPut]
        public IActionResult Update(int id, string username, string password, string email)
        {
            Guest? guest = Context.Guests.Where(x => x.Id == id).FirstOrDefault();
            if (guest == null)
            {
                return BadRequest("Not found");
            }
            guest.Username = username;
            guest.Password = password;
            guest.Email = email;
            Context.SaveChanges();
            return Ok(guest);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Guest? guest = Context.Guests.Where(x => x.Id == id).FirstOrDefault();
            if (guest == null)
            {
                return BadRequest("Not found");
            }
            Context.Guests.Remove(guest);
            Context.SaveChanges();
            return Ok(guest);
        }
    }
}
