using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApplicationMessage.Controllers
{

    [ApiController]
    [Route("v1/category")]
    public class CategoryController : ControllerBase
    {



        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Models.Category>>> Get(
            [FromServices] DataContext.DataContext context)
        {
            var categories = await context.Categories.ToListAsync();

            return categories;
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<ActionResult<Models.Category>> GetById(
            [FromServices] DataContext.DataContext context, long id)
        {
            var category = await context.Categories.FirstOrDefaultAsync(a=> a.Id == id);

            return category;
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Models.Category>> Post(
            [FromServices] DataContext.DataContext context, 
            [FromBody] Models.Category model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
