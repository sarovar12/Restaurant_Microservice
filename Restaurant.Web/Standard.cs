namespace Restaurant.Web
{
    public static class Standard
    {
        public static string ProductAPIBase { get; set; }
        public static string CouponAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
