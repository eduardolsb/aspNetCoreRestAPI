using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApplicationMessage.Controllers
{
    [ApiController]
    [Route("v1/product")]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Models.Product>>> Get(
            [FromServices] DataContext.DataContext context)
        {
            var products = await context.Products.Include(a=> a.Category).ToListAsync();

            return products;
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<ActionResult<Models.Product>> GetById(
            [FromServices] DataContext.DataContext context, 
            long id)
        {
            var product = await context.Products
                .Include(a => a.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(a=> a.Id == id);

            return product;
        }

        [HttpGet]
        [Route("category/{id:long}")]
        public async Task<ActionResult<List<Models.Product>>> GetByCategory(
            [FromServices] DataContext.DataContext context,
            long id)
        {
            var products = await context.Products
                .Include(a => a.Category)
                .AsNoTracking()
                .Where(a => a.IdCategory == id)
                .ToListAsync();

            return products;
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Models.Product>> Post(
            [FromServices] DataContext.DataContext context,
            [FromBody] Models.Product model)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
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
