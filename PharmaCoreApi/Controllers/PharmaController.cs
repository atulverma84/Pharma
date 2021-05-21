using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PharmaCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaController : ControllerBase
    {
        private readonly ILogger<PharmaController> _logger;
        private readonly ICouchRepository _couchRepository;
        public PharmaController(ILogger<PharmaController> logger, ICouchRepository couchRepository)
        {
            _logger = logger;
            _couchRepository = couchRepository;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PharmaDetails pharmaDetails)
        {
            //pharmaDetails.UpdatedOn = DateTime.Now;
            var result = await _couchRepository.PostDocumentAsync(pharmaDetails);
            if (result.IsSuccess)
            {
                var sResult = JsonConvert.DeserializeObject<SavedResult>(result.SuccessContentObject);
                return new CreatedResult("Success", sResult);
            }

            return new UnprocessableEntityObjectResult(result.FailedReason);
        }

        //[HttpPost]
        [HttpPost]
        [Route("Find")]
        //[ActionName("Find")]
        public async Task<IActionResult> PostFindDocument([FromBody] Query details)
        {
            //pharmaDetails.UpdatedOn = DateTime.Now;
            var result = await _couchRepository.FindDocument(details);
            if (result.IsSuccess)
            {
                var sResult = JsonConvert.DeserializeObject<Documents>(result.SuccessContentObject);
                return new CreatedResult("Success", sResult);
            }

            return new UnprocessableEntityObjectResult(result.FailedReason);
        }

        //[HttpPost]
        [HttpGet("{key}")]
        [Route("View/{key}")]
        //[ActionName("Find")]
        public async Task<IActionResult> PostFindViewDocument(string key)
        {
            //pharmaDetails.UpdatedOn = DateTime.Now;
            var result = await _couchRepository.GetViewAsync(key);
            if (result.IsSuccess)
            {
                var sResult = JsonConvert.DeserializeObject<Documents>(result.SuccessContentObject);
                return new CreatedResult("Success", sResult);
            }

            return new UnprocessableEntityObjectResult(result.FailedReason);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
            {
            _logger.LogInformation("fetching data from couchDB against id {0}", id);
            var result = await _couchRepository.GetDocumentAsync(id);
            if (result.IsSuccess)
            {
                // var responseContent = result.SuccessContentObject;
                var responseString = result.SuccessContentObject;

                dynamic task = JObject.Parse(responseString);

                var sResult = JsonConvert.DeserializeObject<ListPharmaDetails>(responseString);
                _logger.LogInformation("Data from couchDb fetched against id {0}", id);
                return new OkObjectResult(sResult);
                
            }
            return new NotFoundObjectResult("NotFound");
        }
    }
}
