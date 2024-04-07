using iTEC_Hackathon.DTOs.Report;

namespace iTEC_Hackathon.Interfaces.Report
{
    public interface IGetReportRepository
    {
        Task<IEnumerable<ReportGetDTO>> GetReportAsyncRepo(int idApplication);
    }
}