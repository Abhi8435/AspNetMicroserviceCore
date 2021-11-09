using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public CatalogController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _repository.GetProducts());
        }

        [HttpGet("{id}",Name = "GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _repository.GetProduct(id);
            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
        [HttpGet("Category/{categoryName}", Name = "GetProductByCategory")]
        public async Task<ActionResult<Product>> GetProductByCategory(string categoryName)
        {
            var product = await _repository.GetProductByCategory(categoryName);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
        [HttpGet("Name/{name}", Name = "GetProductByName")]
        public async Task<ActionResult<Product>> GetProductByName(string name)
        {
            var product = await _repository.GetProductByName(name);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            await _repository.CreateProduct(product);
            return CreatedAtRoute("GetProductById", new { id = product.Id });
        }
        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            var status = await _repository.UpdateProduct(product);
            if (!status)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult<Product>> DeleteProduct(string id)
        {
            var status = await _repository.DeleteProduct(id);
            if (!status)
            {
                return NotFound();
            }
            return NoContent();
        }






    }
}
