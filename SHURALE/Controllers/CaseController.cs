using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHURALE.Models;

namespace SHURALE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        public CompHelperContext Context { get; }

        public CaseController(CompHelperContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Case> cases = Context.Cases.ToList();
            return Ok(cases);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Case? @case = Context.Cases.Where(x => x.CaseId == id).FirstOrDefault();
            if (@case == null)
            {
                return BadRequest("Not found");
            }
            return Ok(@case);
        }

        [HttpPost]
        public IActionResult Add(Case @case)
        {
            Context.Cases.Add(@case);
            Context.SaveChanges();
            return Ok(@case);
        }
        [HttpPut]
        public IActionResult Update(int id, string model, string motherboardFormFactor, string powerSupplyFormFactor)
        {
            Case? @case = Context.Cases.Where(x => x.CaseId == id).FirstOrDefault();
            if (@case == null)
            {
                return BadRequest("Not found");
            }
            @case.Model = model;
            @case.MotherBoardFormFactor = motherboardFormFactor;
            @case.PowerSupplyFormFactor = powerSupplyFormFactor;
            Context.SaveChanges();
            return Ok(@case);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Case? @case = Context.Cases.Where(x => x.CaseId == id).FirstOrDefault();
            if (@case == null)
            {
                return BadRequest("Not found");
            }
            Context.Cases.Remove(@case);
            Context.SaveChanges();
            return Ok(@case);
        }
    }
}
