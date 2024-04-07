using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.DTOs.Report;
using System.Data;
using Dapper;
using iTEC_Hackathon.Interfaces.Report;

namespace iTEC_Hackathon.Repositories.Report
{
    public class GetReportsUnsolvedByIdUserRepository : IGetReportsUnsolvedByIdUserRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public GetReportsUnsolvedByIdUserRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<IEnumerable<ReportsUnsolvedGetByIdUserDTO>> GetReportsUnsolvedByIdUserAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<ReportsUnsolvedGetByIdUserDTO>("GetReportsUnsolvedByIdUser", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
