﻿namespace Restaurant.Services.ShoppingCartAPI.Model.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
