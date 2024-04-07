using iTEC_Hackathon.DTOs.Report;

namespace iTEC_Hackathon.Interfaces.Report
{
    public interface IGetReportsUnsolvedByIdUserRepository
    {
        Task<IEnumerable<ReportsUnsolvedGetByIdUserDTO>> GetReportsUnsolvedByIdUserAsyncRepo(int idUser);
    }
}