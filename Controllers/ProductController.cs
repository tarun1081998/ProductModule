using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductModule.Models;
using Microsoft.EntityFrameworkCore;
using ProductModule.Controllers.Handler;

namespace ProductModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public IHandler _handler;
        // public ProductContext _context;
        public ProductController(IHandler handler)
        {
            _handler = handler;
            // _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var product = await _handler.GetProducts();
                return Ok(product);
            }
            catch
            {
                return StatusCode(500);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody] Product product)
        {
            try
            {
                await _handler.PostProduct(product);
            }
            catch
            {
                return StatusCode(500);
            }
            
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, [FromBody] Product product){
            try
            {
                await _handler.EditProduct(id,product);
            }
            catch(Exception ex)
            {
                if(ex.Message=="Product not found"){
                    return StatusCode(400);
                }
                return StatusCode(500);
            }
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id){
            try
            {
                await _handler.DeleteProduct(id);
            }
            catch(Exception ex)
            {
                if(ex.Message=="Product not found"){
                    return StatusCode(400);
                }
                return StatusCode(500);
            }
            return Ok();
        }

    }
}