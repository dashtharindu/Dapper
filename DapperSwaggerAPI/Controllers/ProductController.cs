using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperSwaggerAPI.Data;
using DapperSwaggerAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperSwaggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;
        public ProductController()
        {
            productRepository = new ProductRepository();
        }

        [HttpGet]
        public ActionResult<Product> Get()
        {
            return Ok(productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromForm]Product prod)
        {
            if (ModelState.IsValid)
            {
                productRepository.Add(prod);
                return Ok("Successfully Added");
            }
            else
            {
                return Ok("Not a valid model");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm]Product prod)
        {
            prod.ProductId = id;
            if (ModelState.IsValid)
            {
                return Ok(productRepository.Update(prod));
            }
            return Ok("Update Failed");
        }

        //todo-do not pass id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(productRepository.Delete(id));
        }
    }
}