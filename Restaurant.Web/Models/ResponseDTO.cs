namespace Restaurant.Web.Models
{
    public class ResponseDTO
    {
        public bool Success { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> Errors { get; set; }
    }
}
