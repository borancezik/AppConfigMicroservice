namespace AppConfigMicroservice.Common
{
    public class RedisSettings
    {
        public string ServiceUrl { get; set; }
        public string Password { get; set; }
        public int CachingType { get; set; }
    }
}
