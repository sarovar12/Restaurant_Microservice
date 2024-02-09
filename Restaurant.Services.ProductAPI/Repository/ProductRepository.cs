using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.ProductAPI.DatabaseContext;
using Restaurant.Services.ProductAPI.Models;
using Restaurant.Services.ProductAPI.Models.DTO;

namespace Restaurant.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;  
            _mapper = mapper;
            
        }
        public async Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO)
        {
           var product = _mapper.Map<Product>(productDTO);
            if(product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
           await _db.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);

        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _db.Products.FirstOrDefaultAsync(product => product.ProductId == productId);
                if(product == null)
                {
                    return false;
                }
                product.DateDeleted = DateTime.Now;
                await _db.SaveChangesAsync();
                return true;

            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            var product = await _db.Products.Where(product=>product.ProductId == productId && product.DateDeleted == null).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _db.Products.Where(x=>x.DateDeleted == null).ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }
    }
}
