using iTEC_Hackathon.DTOs.Statistics;

namespace iTEC_Hackathon.Interfaces
{
    public interface IGetTotalNumberOfReportsBySolvedRepository
    {
        Task<IEnumerable<GetTotalNumberOfReportsBySolvedDTO>> GetTotalNumberOfReportsBySolvedAsyncRepo();
    }
}