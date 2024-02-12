using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.CouponAPI.DatabaseContext;
using Restaurant.Services.CouponAPI.Model.DTO;

namespace Restaurant.Services.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _db;
        protected IMapper _mapper;
        public CouponRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }
        public async Task<CouponDTO> GetCouponByCode(string couponCode)
        {
            var couponFromDb = await _db.Coupons.FirstOrDefaultAsync(u => u.CouponCode == couponCode);
            return _mapper.Map<CouponDTO>(couponFromDb);
        }
    }
}
