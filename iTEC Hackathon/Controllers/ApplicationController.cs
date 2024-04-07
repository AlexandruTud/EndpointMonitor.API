using Microsoft.AspNetCore.Mvc;
using iTEC_Hackathon.DTOs.Application;
using iTEC_Hackathon.Interfaces.Application;
using iTEC_Hackathon.Interfaces.User;

namespace iTEC_Hackathon.Controllers
{
    public class ApplicationController : ControllerBase
    {
        private readonly IAddApplicationRepository _addApplicationRepository;
        private readonly IDeleteApplicationRepository _deleteApplicationRepository;
        private readonly IGetApplicationByAuthorRepository _getApplicationByAuthorRepository;
        private readonly IGetApplicationByIdRepository _getApplicationByIdRepository;
        private readonly IUpdateApplicationRepository _updateApplicationRepository;

        public ApplicationController(IAddApplicationRepository addApplicationRepository,
            IDeleteApplicationRepository deleteApplicationRepository, 
            IGetApplicationByAuthorRepository getApplicationRepository,
            IUpdateApplicationRepository updateApplicationRepository,
            IGetApplicationByIdRepository getApplicationByIdRepository)
        {
            _addApplicationRepository = addApplicationRepository;
            _deleteApplicationRepository = deleteApplicationRepository;
            _getApplicationByAuthorRepository = getApplicationRepository;
            _updateApplicationRepository = updateApplicationRepository;
            _getApplicationByIdRepository = getApplicationByIdRepository;
        }

        [HttpPost]
        [Route("AddApplication")]
        public async Task<IActionResult> AddApplicationAsyncRepo([FromBody] ApplicationInsertDTO applicationInsertDTO)
        {
            var applicationID = await _addApplicationRepository.AddApplicationAsyncRepo(applicationInsertDTO);

            if (applicationID > 0)
                return Ok(applicationID);
            else
                return BadRequest("Application failed.");
        }

        [HttpDelete]
        [Route("DeleteApplication")]
        public async Task<IActionResult> DeleteApplicationAsyncRepo(int idApplication)
        {
            var success = await _deleteApplicationRepository.DeleteApplicationAsyncRepo(idApplication);

            if (success == 1)
                return Ok(success);
            else
                return BadRequest("Application failed.");
        }

        [HttpGet]
        [Route("GetApplication(s)ByAuthor")]
        public async Task<IActionResult> GetApplicationAsyncRepo(int idUserAuthor)
        {
            var result = await _getApplicationByAuthorRepository.GetApplicationAsyncRepo(idUserAuthor);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Application failed.");
        }

        [HttpGet]
        [Route("GetApplicationById")]
        public async Task<IActionResult> GetApplicationByIdAsyncRepo(int idApplication)
        {
            var result = await _getApplicationByIdRepository.GetApplicationByIdAsyncRepo(idApplication);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Application failed.");
        }

        [HttpPatch]
        [Route("UpdateApplication")]
        public async Task<IActionResult> UpdateApplicationAsyncRepo([FromBody] ApplicationUpdateDTO applicationUpdateDTO)
        {
            var success = await _updateApplicationRepository.UpdateApplicationAsyncRepo(applicationUpdateDTO);
            if(success == 1)
                return Ok();
            else
                return BadRequest("Application update failed.");
        }
    }
}
