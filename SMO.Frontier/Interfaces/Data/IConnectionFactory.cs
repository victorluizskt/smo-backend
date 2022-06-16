using System.Data;

namespace SMO.Frontier.Interfaces.Data
{
    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}
