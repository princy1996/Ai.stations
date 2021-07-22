using Ai.Stations.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using stations.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// An end point that returns a list of features from json file
        /// </summary>
        /// <remarks>
        /// If a title is provided, a list will still be returned.
        /// To return a single result use <see cref="GetStationByTitle(string)"/>
        /// </remarks>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/stations")]
        public ActionResult<IEnumerable<Feature>> GetStations([FromQuery] string title)
        {
            ICollection<Feature> result = (ICollection<Feature>)_service.ReturnListOfFeatures(title);
            
            if(result == null)
            {
                return NotFound("Object not found");
            }
            else
            {
                return new ActionResult<IEnumerable<Feature>>(result);
            }

        }

        /// <summary>
        /// Returns a single Feature by title
        /// </summary>
        /// <param name="stationTitle"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/stations/{stationTitle}")]
        public ActionResult<Feature> GetStationByTitle([FromRoute] string stationTitle)
        {
            Feature result = _service.ReturnFeature(stationTitle);

            if (result == null)
            {
                return NotFound("Object not found");
            }
            else
            {
                return new ActionResult<Feature>(result);
            }
        }
    }
}


