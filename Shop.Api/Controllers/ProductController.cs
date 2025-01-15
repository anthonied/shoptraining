using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Dtos;
using Shop.Data.DomainServices;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductDomainService domainService, IMapper mapper) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> GetAction()
        {
            var products = await domainService.GetAsync();
            return Ok(mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> Post([FromBody] ProductDto product)
        {
            var productWithId = await domainService.InsertAsync(mapper.Map<Product>(product));
            return Ok(mapper.Map<ProductDto>(productWithId));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
                return BadRequest("Identity mismatch");

            var product = mapper.Map<Product>(productDto);
            int rows = await domainService.UpdateAsync(product);

            if (rows == 0)
                return BadRequest("Database error");

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rows = await domainService.DeleteAsync(id);
            if (rows == 0)
                return BadRequest("Entry not found");

            return NoContent();
        }
    }
}
    