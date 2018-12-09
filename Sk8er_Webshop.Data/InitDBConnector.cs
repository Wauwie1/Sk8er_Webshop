using Microsoft.Extensions.Configuration;

namespace Sk8er_Webshop.Data
{
    public abstract class InitDBConnector
    {
        public DatabaseConnector DatabaseConnector { get; private set; }
        protected InitDBConnector(IConfiguration configuration)
        {
            this.DatabaseConnector = new DatabaseConnector(configuration);
        }
    }
}