using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataProviders;
using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;

namespace DataProviders.Tests
{
    [TestClass()]
    public class TxtProviderTests
    {
        private ITxtProvider prov;

        [TestMethod()]
        public void ReplaceStringToDataTimeTest()
        {
            prov = Substitute.For<ITxtProvider>();
            prov.ReplaceStringToDataTime(Arg.Any<string>()).Returns(DateTime.Now);
            var x = prov.ReplaceStringToDataTime("sdfdsfdsfdsf");

            Assert.IsNotNull(x);
        }
    }
}