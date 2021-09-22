using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return products.Single(x => x.Id == id);
        } 

        [HttpPost]
        public ActionResult Create(Product model)
        {
            model.Id = products.Count() + 1;
            products.Add(model);
            return CreatedAtAction(
                "Get",
                new { id = model.Id },
                model
            );            
        } 

        [HttpPut("{productId}")]
        public ActionResult Update(int productId, Product model)
        {
            var originalEntry = products.Single(x => x.Id == productId);
            originalEntry.Name = model.Name;
            originalEntry.Description = model.Description;
            originalEntry.Price = model.Price;
            return NoContent();
        } 
        
        [HttpDelete("{idProduct}")]
        public ActionResult Delete(int idProduct)
        {
            products = products.Where(x => x.Id != idProduct).ToList();
            return NoContent();
        } 

        public static List<Product> products = new List<Product>
        {
            new Product
            {
               Id = 1,
               Name = "Guitarra electronica",
               Price = 1111,
               Description = "Ideal para hacer smusica"
            },
            new Product
            {
               Id = 2,
               Name = "Amplificador",
               Price = 1330,
               Description = "Ideal para reproducir musica"
            }

        };
    }
}
