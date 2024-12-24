using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHURALE.Models;

namespace SHURALE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        public CompHelperContext Context { get; }

        public StorageController(CompHelperContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Storage> storages = Context.Storages.ToList();
            return Ok(storages);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Storage? storage = Context.Storages.Where(x => x.StorageId == id).FirstOrDefault();
            if (storage == null)
            {
                return BadRequest("Not found");
            }
            return Ok(storage);
        }

        [HttpPost]
        public IActionResult Add(Storage storage)
        {
            Context.Storages.Add(storage);
            Context.SaveChanges();
            return Ok(storage);
        }
        [HttpPut]
        public IActionResult Update(int id, string model, string memoryType, int capacity, string memoryInterface)
        {
            Storage? storage = Context.Storages.Where(x => x.StorageId == id).FirstOrDefault();
            if (storage == null)
            {
                return BadRequest("Not found");
            }
            storage.Model = model;
            storage.MemoryType = memoryType;
            storage.Capacity = capacity;
            storage.MemoryInterface = memoryInterface;
            Context.SaveChanges();
            return Ok(storage);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Storage? storage = Context.Storages.Where(x => x.StorageId == id).FirstOrDefault();
            if (storage == null)
            {
                return BadRequest("Not found");
            }
            Context.Storages.Remove(storage);
            Context.SaveChanges();
            return Ok(storage);
        }
    }
}
