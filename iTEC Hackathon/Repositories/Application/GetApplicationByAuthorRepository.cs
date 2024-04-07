using System.Data;
using Dapper;
using iTEC_Hackathon.DTOs.Application;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.Interfaces.Application;


namespace iTEC_Hackathon.Repositories
{
    public class GetApplicationByAuthorRepository : IGetApplicationByAuthorRepository
    {
      private readonly IDbConnectionFactory _dbconnectionFactory;
        public GetApplicationByAuthorRepository(IDbConnectionFactory dbconnectionFactory)
        {
            _dbconnectionFactory = dbconnectionFactory;
        }

        public async Task<IEnumerable<ApplicationGetByAuthorDTO>> GetApplicationAsyncRepo(int idUserAuthor)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUserAuthor", idUserAuthor);
            using (var connection = _dbconnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<ApplicationGetByAuthorDTO>("GetApplicationsByAuthor", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
