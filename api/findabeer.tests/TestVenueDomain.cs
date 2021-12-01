using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using findabeer.api.Models;

namespace findabeer.tests
{
    [TestClass]
    public class TestVenueDomain
    {
        [TestMethod]
        public void TestLatLongDistanceTo()
        {
            // lat1, long1, lat2, long2, distance
            var data = (new []
            {
                ( 53.797676F, -1.5493602F, 53.80673847989985F, -1.5550435262355744F, 1075.654353987005 )
                // in production would expand this test
            }).ToList();

            data.ForEach(d => 
            {
                var v = new Venue { Lat = d.Item1, Long = d.Item2 };
                System.Console.WriteLine(d.Item1);
                Assert.AreEqual(d.Item5, v.DistanceTo(d.Item3, d.Item4));
            });
        }
    }
}
