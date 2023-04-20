using Fixxo_Web_Api.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Contexts;

using WebApi.Models.Entities;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]

    [UseApiKey]

    public class ProductsController : ControllerBase
    {   
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [HttpGet("tag/{tag}")]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetProductsByTag(string tag)
        {
            var products = await _context.Products.Where(p => p.Tag == tag).ToListAsync();

            if (!products.Any())
            {
                return NotFound();
            }

            return products;
        }
	




	}
}
