using System.Data;

namespace MC.Frontier.Interfaces.Data
{
    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }
}
