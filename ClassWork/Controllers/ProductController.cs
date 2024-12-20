using System.Diagnostics;
using System.Text.Json;
using ClassWork.Intafraces.Product;
using ClassWork.Interfaces.Services;
using ClassWork.Models;
using ClassWork.Models.Product;
using ClassWork.Models.Product.Drinks.Heirs;
using ClassWork.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClassWork.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _iProductService;

      
        public ProductController(ILogger<ProductController> logger, IProductService iProductService)
        {
            _logger = logger;
            _iProductService = iProductService;
        }

        public IActionResult Index()
        { 
            return View(_iProductService.GetAll());
        }

        // ����� ��� ����������� ������� � ���������� �������
        public IActionResult Details(int id)
        {
        
            var product = _iProductService.FindById(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.JsonData = product.GetJsonInfo();

            return View();
        }



        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_iProductService.GetAll());
        }



        [HttpGet("delete-by-id")]
        public IActionResult DeleteById([FromBody] int id)
        {
            var product = _iProductService.FindById(id);

            if (product == null) {
                return NotFound();
            }

            return Ok(_iProductService.Delete(product));
        }

        [HttpGet("delete")]
        public IActionResult Delete([FromBody] Product product)
        { 

            return Ok(_iProductService.Delete(product));
        }

        [HttpGet("update")]
        public IActionResult Update([FromBody] Product product)
        {
             
            return Ok(_iProductService.Update(product));
        }


        [HttpGet] 
        public IActionResult DownloadProductsJson(int id)
        {
            // ����������� �������� � JSON-������
            string json = JsonSerializer.Serialize(_iProductService.GetAll(), new JsonSerializerOptions
            {
                WriteIndented = true, // ��������������� �����
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // ��������� ������� ���� ��� �������������
            });
             

            // ���������� JSON ��� ����
            var fileName = "products.json";
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
            return File(jsonBytes, "application/json", fileName);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
