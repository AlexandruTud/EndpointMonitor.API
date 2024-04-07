namespace iTEC_Hackathon.Interfaces.Application
{
    public interface IDeleteApplicationRepository
    {
        Task<int> DeleteApplicationAsyncRepo(int idApplication);
    }
}
