using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers

{

    [ApiController]

    [Route("api/[controller]")]

    public class ProductsController : ControllerBase

    {

       

        private static List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Apple" },
            new Product { Id = 2, Name = "Banana" }
        };

        private static int _nextId = 3; // start after initial products
        
        [HttpGet]
        public ActionResult<List<Product>> Get()
{  
    return _products;
}
        [HttpPost]

        public ActionResult<Product> Post([FromBody] Product newProduct)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    newProduct.Id = _nextId++; // Assign a new ID - ensure uniqueness
    _products.Add(newProduct);

    return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
}

[HttpPut("{id}")]

public ActionResult<Product> Put(int id, [FromBody] Product updatedProduct)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    // Find the product by ID in our in-memory collection
    var existingProduct = _products.FirstOrDefault(p => p.Id == id);

    if (existingProduct == null)
        return NotFound($"Product with ID {id} not found.");

    // Update the product's properties
    existingProduct.Name = updatedProduct.Name;

    return Ok(existingProduct); // Return the updated product
}

[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
     var product = _products.FirstOrDefault(p => p.Id == id);
    if (product == null)
        return NotFound(new { message = $"Product with ID {id} not found." });

    _products.Remove(product);
    return Ok(new { message = $"Product {id} deleted successfully." });
}

    }

}