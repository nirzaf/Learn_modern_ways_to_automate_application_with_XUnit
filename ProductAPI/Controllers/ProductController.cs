using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Repository;

namespace ProductAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository productRepository;

    public ProductController(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    [HttpGet]
    [Route("/[controller]/[action]/{id}")]
    public Product GetProductById(int id)
    {
        return productRepository.GetProductById(id);
    }

    // GET: ProductController/GetProducts
    [HttpGet]
    [Route("/[controller]/[action]")]
    public ActionResult<List<Product>> GetProducts()
    {
        return productRepository.GetAllProducts();
    }

    // POST: ProductController/Create
    [HttpPost]
    [Route("/[controller]/[action]")]
    public Product Create(Product product)
    {
        return productRepository.AddProduct(product);
    }


    // PUT: ProductController/Create
    [HttpPut]
    [Route("/[controller]/[action]")]
    public Product Update(Product product)
    {
        return productRepository.UpdateProduct(product);
    }

    // PUT: ProductController/Delete
    [HttpDelete]
    [Route("/[controller]/[action]")]
    public void Delete(int id)
    {
        productRepository.DeleteProduct(id);
    }

}