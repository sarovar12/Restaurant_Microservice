namespace Restaurant.Web
{
    public static class Standard
    {
        public static string ProductAPIBase { get; set; }
        public static string CouponAPIBase { get; set; }
        public static string AuthenticationAPIBase { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public const string TokenCookie = "JWTToken";

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
