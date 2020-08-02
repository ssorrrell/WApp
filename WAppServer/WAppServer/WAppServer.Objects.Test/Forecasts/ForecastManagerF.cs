using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;
using WAppServer.Objects.Forecasts;

namespace WAppServer.Objects.Test.Forecasts
{
    [TestFixture]
    public class ForecastManagerF
    {
        private ForecastManager _forecastManager;

        [SetUp]
        public void SetUp()
        {
            _forecastManager = new ForecastManager(null);
        }

        [Test]
        public void TestGetForecastFromXDoc()
        {
            var filePath = @"C:\Users\Stephen\Desktop\WApp\WAppServer\SampleData\Forecast.xml";
            var doc = XDocument.Load(filePath);
            var result = _forecastManager.GetForecastFromXDoc(doc);

            Assert.IsNotNull(result);
        }
    }
}
