using Ai.Stations.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ai.Stations.Services
{
    public interface IStationsRepository
    {
        IEnumerable<Feature> ReturnListOfFeatures(string? title);
        Feature? ReturnFeature(string title);
    }
    public class StationsRepository : IStationsRepository
    {
        private readonly FeatureCollection featureCollection;
        public StationsRepository()
        {
            var rawJson = File.ReadAllText("Data/stations.json");
            featureCollection = JsonConvert.DeserializeObject<FeatureCollection>(rawJson);
        }

        public IEnumerable<Feature> ReturnListOfFeatures(string? title)
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

        public Feature? ReturnFeature(string title)
        {
            if (title == null)
            {
                return null;
            }
            else
            {
                Feature titledFeature = featureCollection.Features.Where(f => f.Properties.Title == title).Single();
                return titledFeature;
            }

        }





    }
}

