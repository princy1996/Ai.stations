using Ai.Stations.Model;
using Ai.Stations.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ai.Stations.Controllers
{

    [ApiController]
    [Produces("application/json")]
    public class StationsController : ControllerBase
    {
        private readonly IStationsRepository _stationsRepository;

        public StationsController(IStationsRepository stationsRepository)
        {
            _stationsRepository = stationsRepository;
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
        public IEnumerable<Feature>? GetStations([FromQuery] string? title)
        {
            ICollection<Feature> result = (ICollection<Feature>)_stationsRepository.ReturnListOfFeatures(title);
            
            if(result == null)
            {
                return null;
            }
            else
            {
                return result;
            }

        }

        /// <summary>
        /// Returns a single Feature by title
        /// </summary>
        /// <param name="stationTitle"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/stations/{stationTitle}")]
        public Feature? GetStationByTitle([FromRoute] string stationTitle)
        {
            Feature result = _stationsRepository.ReturnFeature(stationTitle);

            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
    }
}


