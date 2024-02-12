namespace Restaurant.Services.CouponAPI.Model.DTO
{
    public class ResponseDTO
    {
        public bool Success { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}
