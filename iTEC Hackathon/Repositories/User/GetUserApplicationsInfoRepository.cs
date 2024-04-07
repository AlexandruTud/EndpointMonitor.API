using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.DTOs.User;
using Dapper;
using System.Data;
using iTEC_Hackathon.Interfaces.User;


namespace iTEC_Hackathon.Repositories.User
{
    public class GetUserApplicationsInfoRepository : IGetUserApplicationsInfoRepository
    {
        private readonly IDbConnectionFactory _dbconnectionFactory;
        public GetUserApplicationsInfoRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<IEnumerable<UserApplicationsInfoDTO>> GetUserApplicationsInfoAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<UserApplicationsInfoDTO>("GetUserApplicationInfo", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
