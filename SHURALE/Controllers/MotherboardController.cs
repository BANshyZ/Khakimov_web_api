using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHURALE.Migrations;
using SHURALE.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SHURALE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotherboardController : ControllerBase
    {
        public CompHelperContext Context { get; }

        public MotherboardController(CompHelperContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Motherboard> motherboards = Context.Motherboards.ToList();
            return Ok(motherboards);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Motherboard? motherboard = Context.Motherboards.Where(x => x.MotherboardId == id).FirstOrDefault();
            if (motherboard == null)
            {
                return BadRequest("Not found");
            }
            return Ok(motherboard);
        }

        [HttpPost]
        public IActionResult Add(Motherboard motherboard)
        {
            Context.Motherboards.Add(motherboard);
            Context.SaveChanges();
            return Ok(motherboard);
        }
        [HttpPut]
        public IActionResult Update(int id, string model,string socket, string ramType, string connectionInterface, string memoryInterface) 
        {
            Motherboard? motherboard = Context.Motherboards.Where(x => x.MotherboardId == id).FirstOrDefault();
            if (motherboard == null)
            {
                return BadRequest("Not found");
            }
            motherboard.Model = model;
            motherboard.Socket = socket;
            motherboard.Ramtype = ramType;
            motherboard.ConnectionInterface = connectionInterface;
            motherboard.MemoryInterface = memoryInterface;
            Context.SaveChanges();
            return Ok(motherboard);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Motherboard? motherboard = Context.Motherboards.Where(x => x.MotherboardId == id).FirstOrDefault();
            if (motherboard == null)
            {
                return BadRequest("Not found");
            }
            Context.Motherboards.Remove(motherboard);
            Context.SaveChanges();
            return Ok(motherboard);
        }
    }
}
