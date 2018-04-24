using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeoCoordinatePortable;

namespace EASA.Tests
{
    [TestClass]
    public class CrewPlanner
    {
        [TestMethod]
        public void TakeInTimeAndTasks_ReturnCrew()
        {
            //(tasks / 4) / (hours * .66)
            //Arrange
            int crew = 3;
            double tasks = 1234;
            double hours = 168;

            //Act
            double crewNeeded = Math.Ceiling((tasks / 4) / Math.Ceiling(hours * .66));
            //Console.WriteLine("crew = ", crew, " crewNeeded = ", Convert.ToInt32(crewNeeded));

            //Assert
            Assert.AreEqual(crew, Convert.ToInt32(crewNeeded));
            //Assert.AreEqual(crew, crew);
        }
        [TestMethod]
        public void TakeInWeight()
        {
            //Arrange
            double weightKg = 2000;
            double finalVelocity = 9.400;
            double exhaustVelocity = 3.0;
            double testFuelWeight = 43886.0;

            //Act
            double fuelWeight = Math.Ceiling((weightKg * Math.Pow(2.718, (finalVelocity / exhaustVelocity))) - weightKg);

            //Assert
            Assert.AreEqual(testFuelWeight, fuelWeight);
        }
        
        [TestMethod]
        public void getFunkMath()
        {
            //double sLat = (28.0 + (32 / 60));
            //double sLon = (80.0 + (34 / 60));
            //double eLat = (28.0 + (33 / 60));
            //double eLon = (80.0 + (34 / 60));

            //double sLatBits = 32 / 60;
            //double sLonBits = 34 / 60;
            //double eLatBits = 33 / 60;
            //double eLonBits = 34 / 60;

            //double sLat = 28 + sLatBits;
            //double sLon = 80 + sLonBits;
            //double eLat = 28 + eLatBits;
            //double eLon = 80 + eLonBits;


            //double sLat = 28;
            //double sLon = 80;
            //double eLat = 28;
            //double eLon = 80;

            //double sLat = 28.5555;
            //double sLon = 33.3333;
            //double eLat = 28.9876;
            //double eLon = 33.4567;


            //const double r = 6371e3; // meters
            //double dlat = (eLat - sLat) / 2;
            //double dlon = (eLon - sLon) / 2;

            //double q = Math.Pow(Math.Sin(dlat), 2) + Math.Cos(sLat) * Math.Cos(eLat) * Math.Pow(Math.Sin(dlon), 2);
            //double c = 2 * Math.Atan2(Math.Sqrt(q), Math.Sqrt(1 - q));

            //double distance = r * c / 1000;

            double sMinutes = 33 * 0.0166667;
            double eMinutes = 32 * 0.0166667;
            double lat1 = 28 + sMinutes;
            double lat2 = 28 + eMinutes;

            double sMinutesO = 34 * 0.0166667;
            double eMinutesO = 34 * 0.0166667;
            double lon1 = 80 + sMinutesO;
            double lon2 = 80 + eMinutesO;

            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            dist =  dist * 0.8684;

            Assert.AreEqual(1, Math.Round(dist));

        }

    }
}
