using iTEC_Hackathon.DTOs.Statistics;

namespace iTEC_Hackathon.Interfaces
{
    public interface IGetTotalNumbersOfRecordsRepository
    {
        Task<IEnumerable<GetTotalNumberOfRecordsDTO>> GetTotalNumbersOfRecordsAsyncRepo();
    }
}