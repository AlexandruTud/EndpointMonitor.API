using iTEC_Hackathon.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace iTEC_Hackathon.Interfaces.User
{
    public interface IGetIsUserAuthorRepository
    {
        Task<IEnumerable<GetIsUserAuthorDTO>> GetIsUserAuthorAsyncRepo([FromQuery] int idUser, [FromQuery] int idApplication);
    }
}