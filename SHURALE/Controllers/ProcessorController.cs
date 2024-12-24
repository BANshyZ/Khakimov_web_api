using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHURALE.Models;
namespace SHURALE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorController : ControllerBase
    {
        public CompHelperContext Context { get; }

        public ProcessorController(CompHelperContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Cpu> cpus = Context.Cpus.ToList();
            return Ok(cpus);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Cpu? cpu = Context.Cpus.Where(x => x.Cpuid == id).FirstOrDefault();
            if (cpu == null)
            {
                return BadRequest("Not found");
            }
            return Ok(cpu);
        }

        [HttpPost]
        public IActionResult Add(Cpu cpu)
        {
            Context.Cpus.Add(cpu);
            Context.SaveChanges();
            return Ok(cpu);
        }
        [HttpPut]
        public IActionResult Update(int id, string model, int powerRating, string formFactor)
        {
            Cpu? cpu = Context.Cpus.Where(x => x.PowerSupplyId == id).FirstOrDefault();
            if (cpu == null)
            {
                return BadRequest("Not found");
            }
            cpu.Model = model;
            cpu.PowerRating = powerRating;
            cpu.FormFactor = formFactor;
            Context.SaveChanges();
            return Ok(cpu);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Cpu? motherboard = Context.Cpus.Where(x => x.PowerSupplyId == id).FirstOrDefault();
            if (motherboard == null)
            {
                return BadRequest("Not found");
            }
            Context.Cpus.Remove(motherboard);
            Context.SaveChanges();
            return Ok(motherboard);
        }
    }
}
