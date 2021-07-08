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
        private readonly StationsService Service;

        public StationsController(ILogger<StationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/stations")]
        public ActionResult<Dictionary<string, object>> GetStations()
        {
            var stations = new StationsService();
            List<string> List = stations.getList();

            var dictionary = new Dictionary<string, object>();

            foreach (var item in List)
            {
                dictionary.Add(item, item);
            }



            if (List.Count == 0)
            {
                Console.WriteLine("No List");

            }

            return dictionary;
        }

        [HttpGet]
        [Route("api/station/{?stationName}")]
        public ActionResult<string> GetStation(string stationName)
        {
            var stations = new StationsService();
            var one = stations.getStationbytitle(string.Empty);


            return one;
        }
    }
}


