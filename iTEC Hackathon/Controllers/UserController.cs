using iTEC_Hackathon.DTOs.User;
using iTEC_Hackathon.Interfaces.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Diagnostics.Eventing.Reader;

namespace iTEC_Hackathon.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ILoginUserRepository _loginUserRepository;
        private readonly IRegisterUserRepository _registerUserRepository;
        private readonly IGetUserApplicationsInfoRepository _getUserApplicationsInfoRepository;
        private readonly IGetIsUserAuthorRepository _getIsUserAuthorRepository;

        public UserController(ILoginUserRepository loginUserRepository, 
            IRegisterUserRepository registerUserRepository, 
            IGetUserApplicationsInfoRepository getUserApplicationsInfoRepository,
            IGetIsUserAuthorRepository getIsUserAuthorRepository)
        {
            _loginUserRepository = loginUserRepository;
            _registerUserRepository = registerUserRepository;
            _getUserApplicationsInfoRepository = getUserApplicationsInfoRepository;
            _getIsUserAuthorRepository = getIsUserAuthorRepository;
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUserAsync([FromBody] UserCredentialsDTO userCredentialsDTO)
        {
            var userID = await _loginUserRepository.LoginUserAsyncRepo(userCredentialsDTO);

            if (userID > 0)
                return Ok(userID);
            else
                return BadRequest("Login failed.");
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserCredentialsDTO userCredentialsDTO)
        {
            var userID = await _registerUserRepository.RegisterUserAsyncRepo(userCredentialsDTO);

            if (userID > 0)
                return Ok(userID);
            else
                return BadRequest("Registration failed.");
        }

        [HttpGet]
        [Route("GetUserApplicationsInfo")]
        public async Task<IActionResult> GetUserApplicationsInfoAsync( int idUser)
        {
            var userApplicationsInfo = await _getUserApplicationsInfoRepository.GetUserApplicationsInfoAsyncRepo(idUser);

            if (userApplicationsInfo != null)
                return Ok(userApplicationsInfo);
            else
                return BadRequest("No applications found.");
        }

        [HttpGet]
        [Route("GetIsUserAuthor")]
        public async Task<IActionResult> GetIsUserAuthorAsync([FromQuery] int idUser, [FromQuery] int idApplication)
        {
            var isAuthor = await _getIsUserAuthorRepository.GetIsUserAuthorAsyncRepo(idUser, idApplication);

            if (isAuthor != null)
                return Ok(isAuthor);
            else
                return BadRequest("No applications found.");
        }   
    }
}
