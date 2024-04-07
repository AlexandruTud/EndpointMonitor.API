using Microsoft.AspNetCore.Mvc;
using iTEC_Hackathon.DTOs.Endpoint;
using iTEC_Hackathon.Interfaces.Endpoint;

namespace iTEC_Hackathon.Controllers
{
    public class EndpointController : ControllerBase
    {
        private readonly IGetEndpointRepository _getEndpointRepository;
        private readonly IAddEndpointRepository _addEndpointRepository;
        private readonly IDeleteEndpointRepository _deleteEndpointRepository;

        public EndpointController(IGetEndpointRepository getEndpointRepository, 
            IAddEndpointRepository addEndpointRepository, 
            IDeleteEndpointRepository deleteEndpointRepository)
        {
            _getEndpointRepository = getEndpointRepository;
            _addEndpointRepository = addEndpointRepository;
            _deleteEndpointRepository = deleteEndpointRepository;
        }

        [HttpPost]
        [Route("AddEndpoint")]
        public async Task<IActionResult> AddEndpointAsyncRepo([FromBody] EndpointInsertDTO endpointInsertDTO)
        {
            var endpointID = await _addEndpointRepository.AddEndpointAsyncRepo(endpointInsertDTO);

            if (endpointID > 0)
                return Ok(endpointID);
            else
                return BadRequest("Endpoint failed.");
        }

        [HttpGet]
        [Route("GetEndpoint")]
        public async Task<IActionResult> GetEndpointAsyncRepo(int idApplication)
        {
            var result = await _getEndpointRepository.GetEndpointAsyncRepo(idApplication);

            if(result != null)
                return Ok(result);
            else
                return BadRequest("Endpoint failed.");
        }

        [HttpDelete]
        [Route("DeleteEndpoint")]
        public async Task<IActionResult> DeleteEndpointAsyncRepo(int idEndpoint)
        {
            var success = await _deleteEndpointRepository.DeleteEndpointAsyncRepo(idEndpoint);

            if (success == 1)
                return Ok(success);
            else
                return BadRequest("Endpoint failed.");
        }

    }
}
