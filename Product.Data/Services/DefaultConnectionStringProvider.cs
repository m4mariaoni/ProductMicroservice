using Microsoft.Extensions.Configuration;
using ProductMicroservice.Data.Interface;

namespace ProductMicroservice.Data.Services
{
    public class DefaultConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;
        public DefaultConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionString()
        {
          return  _configuration.GetConnectionString("ProductDB");
        }
    }
}
