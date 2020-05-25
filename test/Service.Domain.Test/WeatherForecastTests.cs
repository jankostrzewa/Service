using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Domain.Tests
{
    [TestClass]
    public class WeatherForecastTests
    {
        [TestMethod]
        public void WeatherForecast_Created_With_Valid_Arguments()
        {
            // Arrange

            // Act
            var weatherForecast = new WeatherForecast(Guid.NewGuid(), DateTime.UtcNow, 0, "summary", _humidities);
            // Assert
            Assert.IsNotNull(weatherForecast);
            Assert.IsNotNull(weatherForecast.Humidities);
        }

        [TestMethod]
        public void WeatherForecast_Created_With_Valid_Arguments_And_Empty_List()
        {
            // Arrange
            _humidities = new List<string>();

            // Act
            var weatherForecast = new WeatherForecast(Guid.NewGuid(), DateTime.UtcNow, 0, "summary", _humidities);

            // Assert
            Assert.IsNotNull(weatherForecast);
            Assert.IsNotNull(weatherForecast.Humidities);
        }

        [TestMethod]
        public void WeatherForecast_Created_With_Valid_Arguments_And_Null_List()
        {
            // Arrange
            _humidities = null;

            // Act
            var weatherForecast = new WeatherForecast(Guid.NewGuid(), DateTime.UtcNow, 0, "summary", _humidities);

            // Assert
            Assert.IsNotNull(weatherForecast);
            Assert.IsNotNull(weatherForecast.Humidities);
        }

        [TestMethod]
        public void WeatherForecast_Not_Created_With_Invalid_Id()
        {
            // Arrange

            // Act
            Func<WeatherForecast> weatherForecast = () => new WeatherForecast(default, DateTime.UtcNow, 15, "summary", _humidities);

            // Assert
            Assert.ThrowsException<ArgumentException>(weatherForecast);
        }

        [TestMethod]
        public void WeatherForecast_Not_Created_With_Invalid_Date()
        {
            // Arrange

            // Act
            Func<WeatherForecast> weatherForecast = () => new WeatherForecast(Guid.NewGuid(), default, 15, "summary", _humidities);

            // Assert
            Assert.ThrowsException<ArgumentException>(weatherForecast);
        }

        [TestMethod]
        public void WeatherForecast_Created_With_Default_TemperatureC()
        {
            // Arrange

            // Act
            var weatherForecast = new WeatherForecast(Guid.NewGuid(), DateTime.UtcNow, default, "summary", _humidities);

            // Assert
            Assert.IsNotNull(weatherForecast);
        }

        [TestMethod]
        public void WeatherForecast_Not_Created_With_Invalid_Summary()
        {
            // Arrange

            // Act
            Func<WeatherForecast> weatherForecast = () => new WeatherForecast(Guid.NewGuid(), DateTime.UtcNow, 15, default, _humidities);

            // Assert
            Assert.ThrowsException<ArgumentException>(weatherForecast);
        }

        [TestMethod]
        public void Humidity_Added()
        {
            // Arrange
            var weatherForecast = new WeatherForecast(Guid.NewGuid(), DateTime.UtcNow, 0, "summary", _humidities);
            var newHumidity = "d";
            // Act
            weatherForecast.AddHumidity(newHumidity);

            // Assert
            Assert.IsNotNull(weatherForecast.Humidities);
            Assert.AreEqual(newHumidity, weatherForecast.Humidities.Last());
        }

        [TestMethod]
        public void Humidity_Empty_Not_Added()
        {
            // Arrange
            var weatherForecast = new WeatherForecast(Guid.NewGuid(), DateTime.UtcNow, 0, "summary", _humidities);

            // Act
            Action add = () => weatherForecast.AddHumidity("");

            // Assert
            Assert.ThrowsException<ArgumentException>(add);
        }

        [TestMethod]
        public void Humidity_Null_Not_Added()
        {
            // Arrange
            var weatherForecast = new WeatherForecast(Guid.NewGuid(), DateTime.UtcNow, 0, "summary", _humidities);

            // Act
            Action add = () => weatherForecast.AddHumidity(null);

            // Assert
            Assert.ThrowsException<ArgumentException>(add);
        }

        private List<string> _humidities;

        [TestInitialize]
        public void Setup()
        {
            _humidities = new List<string> { "a", "b", "c" };
        }
    }
}
