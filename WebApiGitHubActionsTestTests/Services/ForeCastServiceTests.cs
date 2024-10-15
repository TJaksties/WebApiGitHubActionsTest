using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiGitHubActionsTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGitHubActionsTest.Services.Tests
{
    [TestClass]
    public class ForeCastServiceTests
    {
        private ForeCastService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new ForeCastService();
        }

        [TestMethod]
        public void GetForecasts_ReturnsCorrectNumberOfForecasts()
        {
            // Arrange
            int days = 5;

            // Act
            var forecasts = _service.GetForecasts(days);

            // Assert
            Assert.AreEqual(days, forecasts.Count());
        }

        [TestMethod]
        public void GetForecastForDate_ReturnsForecast()
        {
            // Arrange
            var date = DateOnly.FromDateTime(DateTime.Now);

            // Act
            var forecast = _service.GetForecastForDate(date);

            // Assert
            Assert.AreEqual(date, forecast.Date);
        }

        [TestMethod]
        public void GetForecastForDate_ReturnsDifferentForecastsForDifferentDates()
        {
            // Arrange
            var date1 = DateOnly.FromDateTime(DateTime.Now);
            var date2 = DateOnly.FromDateTime(DateTime.Now.AddDays(1));

            // Act
            var forecast1 = _service.GetForecastForDate(date1);
            var forecast2 = _service.GetForecastForDate(date2);

            // Assert
            Assert.AreNotEqual(forecast1.Date, forecast2.Date);
        }
    }
}