using Ai.Stations.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace stations.Services
{
    public class StationsService
    {
        private readonly FeatureCollection featureCollection;
        public StationsService()
        {
            var rawJson = File.ReadAllText("Data/stations.json");
            featureCollection = JsonConvert.DeserializeObject<FeatureCollection>(rawJson);
        }

        public IEnumerable<Feature> ReturnListOfAllFeatures(string? title)
        {
            if(title == null)
            {
                return featureCollection.Features;
            }
            else
            {
                IEnumerable<Feature> titledFeatures = featureCollection.Features.Where(f => f.Properties.Title == title).ToList();
                return titledFeatures;
            }

        }





    }
}

