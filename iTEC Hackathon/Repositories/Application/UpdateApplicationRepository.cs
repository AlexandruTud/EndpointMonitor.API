using System.Data;
using Dapper;
using iTEC_Hackathon.DTOs.Application;
using iTEC_Hackathon.Infrastructure;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.User;


namespace iTEC_Hackathon.Repositories
{
    public class UpdateApplicationRepository : IUpdateApplicationRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public UpdateApplicationRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

       public async Task<int> UpdateApplicationAsyncRepo(ApplicationUpdateDTO applicationUpdateDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdApplication", applicationUpdateDTO.IdApplication);
            parameters.Add("@IdState", applicationUpdateDTO.IdState);
            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("UpdateApplication", parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<int>("Success");
                return result;
            }
        }
    }
}
