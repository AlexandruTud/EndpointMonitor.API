using iTEC_Hackathon.DTOs.User;

namespace iTEC_Hackathon.Interfaces.User
{
    public interface IGetUserApplicationsInfoRepository
    {
        Task<IEnumerable<UserApplicationsInfoDTO>> GetUserApplicationsInfoAsyncRepo(int idUser);
    }
}