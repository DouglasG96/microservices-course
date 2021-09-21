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
