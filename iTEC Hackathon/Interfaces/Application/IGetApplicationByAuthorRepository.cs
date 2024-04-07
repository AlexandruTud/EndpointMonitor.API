using iTEC_Hackathon.DTOs.Application;

namespace iTEC_Hackathon.Interfaces.Application
{
    public interface IGetApplicationByAuthorRepository
    {
        Task<IEnumerable<ApplicationGetByAuthorDTO>> GetApplicationAsyncRepo(int idUserAuthor);
    }
}