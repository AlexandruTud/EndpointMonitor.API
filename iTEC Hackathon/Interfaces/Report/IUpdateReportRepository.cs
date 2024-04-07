using iTEC_Hackathon.DTOs.Report;

namespace iTEC_Hackathon.Interfaces.Report
{
    public interface IUpdateReportRepository
    {
        Task<int> UpdateReportAsyncRepo(ReportUpdateDTO reportUpdateDTO);
    }
}