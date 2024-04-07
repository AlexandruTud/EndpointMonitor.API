using Microsoft.AspNetCore.Mvc;
using iTEC_Hackathon.DTOs.Endpoint;
using iTEC_Hackathon.Interfaces.EndpointHistory;
using iTEC_Hackathon.DTOs.EndpointHistory;
using iTEC_Hackathon.Interfaces;

namespace iTEC_Hackathon.Controllers
{

    public class EndpointHistoryController : ControllerBase
    {
        private readonly IAddEndpointHistoryRepository _addEndpointHistoryRepository;
        private readonly IGetEndpointHistoryByHoursRepository _getEndpointHistoryByHoursRepository;
        private readonly IGetEndpointStateByHistoryRepository _getEndpointStateByHistoryRepository;
        private readonly IGetHistoryByIdEndpointRepository _getHistoryByIdEndpointRepository;

        public EndpointHistoryController(IAddEndpointHistoryRepository addEndpointHistoryRepository,
            IGetEndpointHistoryByHoursRepository getEndpointHistoryByHoursRepository,
            IGetEndpointStateByHistoryRepository getEndpointStateByHistoryRepository,
            IGetHistoryByIdEndpointRepository getHistoryByIdEndpointRepository)
        {
            _addEndpointHistoryRepository = addEndpointHistoryRepository;
            _getEndpointHistoryByHoursRepository = getEndpointHistoryByHoursRepository;
            _getEndpointStateByHistoryRepository = getEndpointStateByHistoryRepository;
            _getHistoryByIdEndpointRepository = getHistoryByIdEndpointRepository;
        }

        [HttpPost]
        [Route("AddEndpointHistory")]
        public async Task<IActionResult> AddEndpointHistoryAsyncRepo([FromBody] EndpointHistoryInsertDTO endpointHistoryInsertDTO)
        {
            var result = await _addEndpointHistoryRepository.AddEndpointHistoryAsyncRepo(endpointHistoryInsertDTO);

            if (result > 0)
                return Ok(result);
            else
                return BadRequest("Endpoint History failed.");
        }

        [HttpGet]
        [Route("GetEndpointHistoryByHours")]
        public async Task<IActionResult> GetEndpointHistoryByHoursAsyncRepo([FromQuery] int idEndpoint, [FromQuery] int hours)
        {
            var result = await _getEndpointHistoryByHoursRepository.GetEndpointHistoryByHoursAsyncRepo(idEndpoint, hours);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Endpoint History failed.");
        }

        [HttpGet]
        [Route("GetEndpointHistoryById")]
        public async Task<IActionResult> GetHistoryByIdEndpointAsynRepo(int idEndpoint)
        {
            var result = await _getHistoryByIdEndpointRepository.GetHistoryByIdEndpointAsynRepo(idEndpoint);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Endpoint History failed.");
        }
    }
}