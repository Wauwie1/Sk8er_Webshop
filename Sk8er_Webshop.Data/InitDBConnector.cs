using Microsoft.Extensions.Configuration;

namespace Sk8er_Webshop.Data
{
    public abstract class InitDbConnector
    {
        public DatabaseConnector DatabaseConnector { get; private set; }
        protected InitDbConnector(IConfiguration configuration)
        {
            this.DatabaseConnector = new DatabaseConnector(configuration);
        }
    }
}