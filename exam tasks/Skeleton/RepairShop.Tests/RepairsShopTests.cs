using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {


            [Test]
            public void GarageNameShouldThrowExceptionWithEmptyAndNullValues()
            {

                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(null, 10);
                },
                "Invalid garage name."
                );
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(String.Empty, 10);
                },
                "Invalid garage name.");
            }

            [Test]
            public void GarageNameIsValid()
            {
                const string name = "Test";
                var garage = new Garage(name, 10);
                Assert.AreEqual(name, garage.Name);
            }


            [Test]
            public void GarageCarShouldBeCorrect()
            {
                const string carModel = "Opel";
                var garage = new Garage("Test", 10);
                var firstCar = new Car("Mercedes", 20);
                var secondCar = new Car(carModel, 21);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);

                var fixedCar = garage.FixCar(carModel);
                Assert.AreEqual(0, fixedCar.NumberOfIssues);
            }

            [Test]
            public void GarageCarsShouldThrowExceptionIfCarModelIsMissing()
            {
                const string carModel = "Opel";
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Opel", 15);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(carModel);
                }, $"The car {carModel} doesn't exist.");
            }


            [Test]
            public void AddCar()
            {
                var garage = new Garage("Test", 3);
                var car = new Car("Mercedes", 10);
                garage.AddCar(car);
                Assert.AreEqual(1, garage.CarsInGarage);
            }


            [Test]
            public void FixCar()
            {
                var garage = new Garage("Test", 3);
                var car = new Car("Mercedes", 10);
                garage.AddCar(car);
                garage.FixCar(car.CarModel);
                Assert.True(car.IsFixed);
            }
            [Test]
            public void FixNotExistingCarInTheService()
            {
                var garage = new Garage("Test", 3);
                //var car = new Car(null, 10);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Opel");
                });
            }


            [Test]
            public void RemoveFixedCar()
            {
                var garage = new Garage("Test", 3);
                var car = new Car("Mercedes", 10);
                garage.AddCar(car);
                garage.FixCar(car.CarModel);
                garage.RemoveFixedCar();
                Assert.AreEqual(0, garage.CarsInGarage);
            }
            [Test]
            public void RemoveNotFixedCarException()
            {
                var garage = new Garage("Test", 3);
                var car = new Car("Mercedes", 10);
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

            [Test]
            public void Report()
            {
                var garage = new Garage("Test", 3);
                var car1 = new Car("Mercedes", 4);
                var car2 = new Car("BMV", 2);

                garage.AddCar(car1);
                garage.AddCar(car2);

                int unfixedCars = 2;

                string report = $"There are {unfixedCars} which are not fixed: {car1.CarModel}, {car2.CarModel}.";

                Assert.AreEqual(garage.Report(), report);
            }

        }
    }
}