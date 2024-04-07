using iTEC_Hackathon.DTOs.Report;

namespace iTEC_Hackathon.Interfaces.Report
{
    public interface IAddReportRepository
    {
        Task<int> AddReportAsyncRepo(ReportInsertDTO reportInsertDTO);
    }
}