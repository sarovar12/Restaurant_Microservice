namespace Restaurant.Services.ShoppingCartAPI.Model.DTO
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool Success { get; set; } = true;
        public string DisplayMessage { get; set; } = "";
    }
}
