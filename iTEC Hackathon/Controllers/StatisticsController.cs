using Microsoft.AspNetCore.Mvc;
using iTEC_Hackathon.Interfaces;

namespace iTEC_Hackathon.Controllers
{
    public class StatisticsController : ControllerBase
    {
        private readonly IGetTotalNumbersOfRecordsRepository _getTotalNumbersOfRecordsRepository;
        private readonly IGetTotalNumberOfEndpointsByStateRepository _getTotalNumberOfEndpointsByStateRepository;
        private readonly IGetTotalNumberOfReportsBySolvedRepository _getTotalNumberOfReportsBySolvedRepository;
        public StatisticsController(IGetTotalNumbersOfRecordsRepository getTotalNumbersOfRecordsRepository,
            IGetTotalNumberOfEndpointsByStateRepository getTotalNumberOfEndpointsByStateRepository,
            IGetTotalNumberOfReportsBySolvedRepository getTotalNumberOfReportsBySolvedRepository)
        {
            _getTotalNumbersOfRecordsRepository = getTotalNumbersOfRecordsRepository;
            _getTotalNumberOfEndpointsByStateRepository = getTotalNumberOfEndpointsByStateRepository;
            _getTotalNumberOfReportsBySolvedRepository = getTotalNumberOfReportsBySolvedRepository;
        }

        [HttpGet]
        [Route("GetTotalNumberOfRecords")]
        public async Task<IActionResult> GetStatisticsAsyncRepo()
        { 
            var result = await _getTotalNumbersOfRecordsRepository.GetTotalNumbersOfRecordsAsyncRepo();

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Statistics failed.");
        }

        [HttpGet]
        [Route("GetTotalNumberOfEndpointsByState")]
        public async Task<IActionResult> GetTotalNumberOfEndpointsByStateAsyncRepo()
        {
            var result = await _getTotalNumberOfEndpointsByStateRepository.GetTotalNumberOfEndpointsByStateAsyncRepo();

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Statistics failed.");
        }

        [HttpGet]
        [Route("GetTotalNumberOfReportsBySolved")]
        public async Task<IActionResult> GetTotalNumberOfReportsBySolvedAsyncRepo()
        {
            var result = await _getTotalNumberOfReportsBySolvedRepository.GetTotalNumberOfReportsBySolvedAsyncRepo();

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Statistics failed.");
        }
    }
}
