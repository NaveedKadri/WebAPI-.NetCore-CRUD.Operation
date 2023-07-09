using DotnetCoreAPI.Entities;
using DotnetCoreAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly DBContext dbContext;
        public EmployeeController(DBContext DBContext)
        {
            this.dbContext = DBContext;

        }

        [HttpGet("personaldetails")]

        public async Task<ActionResult<List<personaldetailsDTO>>> Get()
        {
            var List = await dbContext.personaldetails.Select
                (s => new personaldetailsDTO
                {
                    EmployeeId = s.EmployeeId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Age = s.Age,
                }

                ).ToListAsync();
            if (List.Count < 0)
            {
                return NotFound();
            }

            else
            {
                return List;
            }
            
        }
    }
}
