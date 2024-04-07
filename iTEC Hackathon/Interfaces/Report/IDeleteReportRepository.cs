namespace iTEC_Hackathon.Interfaces.Report
{
    public interface IDeleteReportRepository
    {
        Task<int> DeleteReportAsyncRepo(int idReport);
    }
}