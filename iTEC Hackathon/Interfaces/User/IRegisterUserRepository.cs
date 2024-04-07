using iTEC_Hackathon.DTOs.User;

namespace iTEC_Hackathon.Interfaces.User
{
    public interface IRegisterUserRepository
    {
        Task<int> RegisterUserAsyncRepo(UserCredentialsDTO userCredentialsDTO);
    }
}