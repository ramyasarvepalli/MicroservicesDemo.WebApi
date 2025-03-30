using Microsoft.AspNetCore.Mvc;
using Product.Microservice.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Products> _products = new List<Products>
        {
            new Products { Id = 1, Name = "Sanitizer", Price = 15 },
            new Products { Id = 2, Name = "Glass", Price = 5 },
            new Products { Id = 3, Name = "Mask", Price = 10 }
        };

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            return _products;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public Products? Get(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        // POST: api/Products
        [HttpPost]
        public Products Post([FromBody] Products product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public Products? Put(int id, [FromBody] Products updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
            }
            return product;
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public Products? Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return product;
        }
    }
}
