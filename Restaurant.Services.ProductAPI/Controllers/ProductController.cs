using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.ProductAPI.Models.DTO;
using Restaurant.Services.ProductAPI.Repository;

namespace Restaurant.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected ResponseDTO _response;
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDTO();

        }
        [HttpGet]

        public async Task<ResponseDTO> GetProducts()
        {
            try
            {
                var productDTO = await _productRepository.GetProducts();
                _response.Result = productDTO;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Errors = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDTO> GetProductById(int id)
        {
            try
            {
                var productDTO = await _productRepository.GetProductById(id);
                _response.Result = productDTO;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Errors = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDTO> AddProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                var product = await _productRepository.CreateUpdateProduct(productDTO);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Errors = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDTO> UpdateProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                var product = await _productRepository.CreateUpdateProduct(productDTO);
                _response.Result = product;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Errors = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDTO> DeleteProduct(int id)
        {
            try
            {
                bool product = await _productRepository.DeleteProduct(id);
                _response.Result = product;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Errors = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;
        }
    }
}
