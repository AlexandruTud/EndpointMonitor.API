using System.Data;

namespace iTEC_Hackathon.Interfaces
{
    public interface IDbConnectionFactory
    {
        public IDbConnection ConnectToDataBase();
    }
}
