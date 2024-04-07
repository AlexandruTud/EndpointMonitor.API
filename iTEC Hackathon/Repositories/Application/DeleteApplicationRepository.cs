using Dapper;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.Application;
using System.Data;

namespace iTEC_Hackathon.Repositories
{
    public class DeleteApplicationRepository : IDeleteApplicationRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public DeleteApplicationRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<int> DeleteApplicationAsyncRepo(int idApplication)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdApplication", idApplication);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("DeleteApplication", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
