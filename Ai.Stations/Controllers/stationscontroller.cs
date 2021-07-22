using Ai.Stations.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using stations.Services;
using System;
using System.Collections.Generic;

namespace Ai.Stations.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class StationsController : ControllerBase
    {
        private readonly ILogger<StationsController> _logger;
        private readonly StationsService _service;

        public StationsController(StationsService stationsService, ILogger<StationsController> logger)
        {
            _logger = logger;
            _service = stationsService;
        }

        [HttpGet]
        [Route("api/stations")]
        public ActionResult<IEnumerable<Feature>> GetStations([FromQuery] string title)
        {
            var result = _service.ReturnListOfAllFeatures(title);
            
            if(result == null)
            {
                return NotFound("Object not found");
            }
            else
            {
                return new ActionResult<IEnumerable<Feature>>(result);
            }

        }
    }
}


