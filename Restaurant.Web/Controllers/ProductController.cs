using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;


namespace Restaurant.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _services;
        public ProductController(IProductServices productServices)
        {
            _services = productServices;

        }
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDTO> list = new();
            var response = await _services.GetAllProducts();
            if (response != null && response.Success)
            {
                list = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.DisplayMessage;
            }
            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDTO model)
        {

            if (ModelState.IsValid)
            {
                var response = await _services.CreateProduct(model);
                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var response = await _services.GetProductById(productId);
            if (response != null && response.Success)
            {
                ProductDTO model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDTO model)
        {

            if (ModelState.IsValid)
            {
                var response = await _services.UpdateProduct(model);
                if (response != null && response.Success)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }


        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await _services.GetProductById(productId);
            if (response != null && response.Success)
            {
                ProductDTO model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.DisplayMessage;
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _services.DeleteProduct(model.ProductId);
                if (response.Success && response !=null)
                {
                    TempData["success"] = "Product deleted successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                 else
            {
                TempData["error"] = response?.DisplayMessage;
            }
            }
            return View(model);
        }
    }
}
