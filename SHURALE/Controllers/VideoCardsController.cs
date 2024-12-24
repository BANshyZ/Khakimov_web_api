using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHURALE.Models;

namespace SHURALE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoCardsController : ControllerBase
    {
        public CompHelperContext Context { get; }

        public VideoCardsController(CompHelperContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Gpu> gpus = Context.Gpus.ToList();
            return Ok(gpus);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Gpu? gpu = Context.Gpus.Where(x => x.Gpuid == id).FirstOrDefault();
            if (gpu == null)
            {
                return BadRequest("Not found");
            }
            return Ok(gpu);
        }

        [HttpPost]
        public IActionResult Add(Gpu gpu)
        {
            Context.Gpus.Add(gpu);
            Context.SaveChanges();
            return Ok(gpu);
        }
        [HttpPut]
        public IActionResult Update(int id, string model, string videoMemoryType, string connectionIntrerface)
        {
            Gpu? gpu = Context.Gpus.Where(x => x.Gpuid == id).FirstOrDefault();
            if (gpu == null)
            {
                return BadRequest("Not found");
            }
            gpu.Model = model;
            gpu.VideoMemoryType = videoMemoryType;
            gpu.ConnectionInterface = connectionIntrerface;
            Context.SaveChanges();
            return Ok(gpu);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Gpu? gpu = Context.Gpus.Where(x => x.Gpuid == id).FirstOrDefault();
            if (gpu == null)
            {
                return BadRequest("Not found");
            }
            Context.Gpus.Remove(gpu);
            Context.SaveChanges();
            return Ok(gpu);
        }
    }
}
