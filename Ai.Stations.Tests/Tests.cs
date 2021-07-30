using System;
using Xunit;
using Ai.Stations.Controllers;
using Ai.Stations.Model;
using Ai.Stations.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Collections.Generic;
using Castle.Core.Logging;
using System.Linq;
using FluentAssertions;
namespace Ai.Stations.Tests
{
    public class Tests
    {

        [Fact]
        public void GetAllStationsTest()
        {
            var mockRepo = new Mock<IStationsRepository>();
            mockRepo.Setup(repo => repo.ReturnListOfFeatures(null))
                .Returns(GetListOfStations());
            var controller = new StationsController(mockRepo.Object);

            var result = controller.GetStations(null);

            var viewResult = Assert.IsAssignableFrom<IEnumerable<Feature>>(result);
            Assert.Equal(2, viewResult.Count());
            viewResult.Should().BeEquivalentTo(GetListOfStations());
        }

        [Fact]
        public void GetStationsByTitleTest()
        {
            var mockRepo = new Mock<IStationsRepository>();
            mockRepo.Setup(repo => repo.ReturnListOfFeatures("test2"))
                .Returns(GetListOfStationsByTitle());
            var controller = new StationsController(mockRepo.Object);

            var result = controller.GetStations("test2");

            var viewResult = Assert.IsAssignableFrom<IEnumerable<Feature>>(result);
            Assert.Single(viewResult);
            viewResult.Should().BeEquivalentTo(GetListOfStationsByTitle());
        }

        [Fact]
        public void GetStationTest()
        {
            var mockRepo = new Mock<IStationsRepository>();
            mockRepo.Setup(repo => repo.ReturnFeature("test3"))
                .Returns(GetStationByTitle());
            var controller = new StationsController(mockRepo.Object);

            var result = controller.GetStationByTitle("test3");

            var viewResult = Assert.IsAssignableFrom<Feature>(result);

            viewResult.Should().BeEquivalentTo(GetStationByTitle());
        }

        [Fact]
        private IEnumerable<Feature> GetListOfStations()
        {
            var stations = new List<Feature>();
            stations.Add(
                    new Feature
                    {
                        Address = "123",
                        Geometry = new Geometry()
                        {
                            Coordinates = new List<float>() { 1, 2 }
                        },
                        Properties = new Properties()
                        {
                            MarkerSymbol = "rail-metro",
                            Title = "test",
                            Description = "desc",
                            Lines = new List<LineType> { LineType.Blue, LineType.Green },
                            Url = "https://www.test.co.uk"
                        }
                    });

            stations.Add(
                    new Feature
                    {
                        Address = "456",
                        Geometry = new Geometry()
                        {
                            Coordinates = new List<float>() { 3, 4 }
                        },
                        Properties = new Properties()
                        {
                            MarkerSymbol = "rail-metro",
                            Title = "test2",
                            Description = "desc2",
                            Lines = new List<LineType> { LineType.Blue },
                            Url = "https://www.test2.co.uk"
                        }
                    });

            return stations;
        }

        private IEnumerable<Feature> GetListOfStationsByTitle()
        {
            var stations = new List<Feature>();

            stations.Add(
                    new Feature
                    {
                        Address = "456",
                        Geometry = new Geometry()
                        {
                            Coordinates = new List<float>() { 3, 4 }
                        },
                        Properties = new Properties()
                        {
                            MarkerSymbol = "rail-metro",
                            Title = "test2",
                            Description = "desc2",
                            Lines = new List<LineType> { LineType.Blue },
                            Url = "https://www.test2.co.uk"
                        }
                    });

            return stations;
        }

        private Feature GetStationByTitle()
        {
            var station = new Feature
                {
                    Address = "789",
                    Geometry = new Geometry()
                    {
                        Coordinates = new List<float>() { 5, 6 }
                    },
                    Properties = new Properties()
                    {
                        MarkerSymbol = "rail-metro",
                        Title = "test3",
                        Description = "desc3",
                        Lines = new List<LineType> { LineType.Silver },
                        Url = "https://www.test3.co.uk"
                    }
                };

            return station;
        }
    }
}
