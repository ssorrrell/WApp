using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;
using WAppServer.Objects.CurrentConditions;

namespace WAppServer.Objects.Test.CurrentConditions
{
    [TestFixture]
    public class CurrentConditionsManagerF
    {
        private CurrentConditionsManager  _currentConditionsManager;

        [SetUp]
        public void SetUp()
        {
            _currentConditionsManager = new CurrentConditionsManager(null);
        }

        [Test]
        public void TestGetCurrentConditionFromXDoc()
        {
            var filePath = @"C:\Users\Stephen\Desktop\WApp\WAppServer\SampleData\KAMA.xml";
            var doc = XDocument.Load(filePath);
            var result = _currentConditionsManager.GetCurrentConditionFromXDoc(doc);

            Assert.IsNotNull(result);
        }
    }
}
