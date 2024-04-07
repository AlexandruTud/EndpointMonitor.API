using Dapper;
using System.Data;
using iTEC_Hackathon.Interfaces;
using iTEC_Hackathon.DTOs.Application;
using iTEC_Hackathon.Interfaces.Application;

namespace iTEC_Hackathon.Repositories
{
    public class AddApplicationRepository : IAddApplicationRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public AddApplicationRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddApplicationAsyncRepo(ApplicationInsertDTO applicationInsertDTO)
        {
            var parameters = new DynamicParameters();

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            parameters.Add("@Name", applicationInsertDTO.Name);
            parameters.Add("@Description", applicationInsertDTO.Description);
            parameters.Add("@IdUserAuthor", applicationInsertDTO.IdUserAuthor);
            parameters.Add("@Image", applicationInsertDTO.Image);
            parameters.Add("IdApplicationState", 1);
            parameters.Add("@DateCreated", sqlFormattedDate);
            parameters.Add("@IdApplication", dbType: DbType.Int32, direction: ParameterDirection.Output);
 
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("InsertApplication", parameters, commandType: CommandType.StoredProcedure);
                var result =  parameters.Get<int>("IdApplication");
                return result;
            }
        }
    }
}
