using iTEC_Hackathon.Interfaces;
using Dapper;
using System.Data;
using iTEC_Hackathon.Interfaces.User;
using iTEC_Hackathon.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace iTEC_Hackathon.Repositories
{
    public class GetIsUserAuthorRepository : IGetIsUserAuthorRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetIsUserAuthorRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<GetIsUserAuthorDTO>> GetIsUserAuthorAsyncRepo([FromQuery] int idUser, [FromQuery] int idApplication)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            parameters.Add("@IdApplication", idApplication);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<GetIsUserAuthorDTO>("GetIsUserAuthor", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
