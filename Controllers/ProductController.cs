using Api_tech.Data;
using Api_tech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_tech.Controllers
{
    [Route("api/[Controller]/[action]")]

    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var data = await _appDbContext.ProductDetails.ToListAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _appDbContext.ProductDetails.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
            return Ok("Created successfully");
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(int Id, [FromBody] Product product)
        {
            if (Id != product.Id)
            {
                return BadRequest("Id mismatched");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _appDbContext.Entry(product).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return Ok("Edited successfully");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult>Delete(int Id)
        {
            var dat=await _appDbContext.ProductDetails.FindAsync(Id);
            if (dat == null)
            {
                return NotFound("Id is not found");
            }
            _appDbContext.ProductDetails.Remove(dat);
           await _appDbContext.SaveChangesAsync();
            return Ok("DEleted successfully");

        }
    }
}
