using iTEC_Hackathon.DTOs.User;

namespace iTEC_Hackathon.Interfaces.User
{
    public interface ILoginUserRepository
    {
        Task<int> LoginUserAsyncRepo(UserCredentialsDTO userCredentialsDTO);
    }
}