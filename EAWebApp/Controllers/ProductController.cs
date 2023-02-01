using EAWebApp.Producer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EAWebApp.Controllers;

public class ProductController : Controller
{
    private readonly IProductUtil productUtil;

    public ProductController(IProductUtil productUtil)
    {
        this.productUtil = productUtil;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> List()
    {
        var products = await productUtil.GetProduct();
        return View(products);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await productUtil.CreateProduct(product);

        return RedirectToAction("List");
    }

    public async Task<IActionResult> Edit(int id)
    {
        return View(await productUtil.GetProductById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        await productUtil.EditProduct(product);

        return RedirectToAction("List");

    }


    public async Task<IActionResult> Delete(int id)
    {
        return View(await productUtil.GetProductById(id));
    }

    [HttpPost]
    public async Task<ActionResult> Delete(int id, Product product)
    {
        try
        {
            await productUtil.DeleteProduct(id);

            return RedirectToAction("List");
        }
        catch
        {
            return View();
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        return View(await productUtil.GetProductById(id));
    }


}