using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMvcProject.Models;

namespace WebMvcProject.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {

      var plist = new List<ProductModel>();
      var product1 = new ProductModel();

      product1.Price = 100;
      product1.Category = "Cilt Bakım";
      product1.Stock = 5;
      product1.ProductName = "Krem";

      var product2 = new ProductModel()
      {
        ProductName = "Ayakkabı",
        Price = 100,
        Stock = 5,
        Category = "Giyim"

      };

      plist.Add(product2);
      plist.Add(product1);

      return View(plist);


    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}