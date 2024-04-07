using System.Data;
using Dapper;
using iTEC_Hackathon.DTOs.Application;
using iTEC_Hackathon.Interfaces.Application;
using iTEC_Hackathon.Interfaces;

namespace iTEC_Hackathon.Repositories
{
    public class GetApplicationByIdRepository : IGetApplicationByIdRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public GetApplicationByIdRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<IEnumerable<ApplicationGetByIdDTO>> GetApplicationByIdAsyncRepo(int idApplication)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdApplication", idApplication);
            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<ApplicationGetByIdDTO>("GetApplicationById", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
