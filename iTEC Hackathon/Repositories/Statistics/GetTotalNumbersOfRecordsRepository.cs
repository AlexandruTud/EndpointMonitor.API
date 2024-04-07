using iTEC_Hackathon.DTOs.Statistics;
using iTEC_Hackathon.Interfaces;
using Dapper;
using System.Data;

namespace iTEC_Hackathon.Repositories.Statistics
{
    public class GetTotalNumbersOfRecordsRepository : IGetTotalNumbersOfRecordsRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetTotalNumbersOfRecordsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<GetTotalNumberOfRecordsDTO>> GetTotalNumbersOfRecordsAsyncRepo()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<GetTotalNumberOfRecordsDTO>("GetTotalNumbersOfRecords", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
