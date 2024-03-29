﻿using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public interface ICartService
    {
        Task<ResponseDTO?> GetCartByUserIdAsnyc(string userId);
        Task<ResponseDTO?> UpsertCartAsync(CartDTO cartDto);
        Task<ResponseDTO?> RemoveFromCartAsync(int cartDetailsId);
        Task<ResponseDTO?> ApplyCouponAsync(CartDTO cartDto);
        Task<ResponseDTO?> EmailCart(CartDTO cartDto);
    }   
}
