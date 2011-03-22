
using System;
using NUnit.Framework;
using Expedia;

namespace ExpediaTest
{
	[TestFixture()]
	public class ServiceLocatorTest
	{
		[Test()]
		public void TestThatServiceLocatorInitializes()
		{
			Assert.IsNotNull(new ServiceLocator());	
		}
		
		[Test()]
		public void TestThatServiceLocatorAvailableDiscountsReturnsExpectedDiscounts()
		{
			var firstDiscount = new Discount(0.05, 1000);
			var secondDisctount = new Discount(0.10, 1750);
			var locator = new ServiceLocator();
			
			locator.AddDiscount(firstDiscount);
			locator.AddDiscount(secondDisctount);
			
			Assert.AreSame(firstDiscount, locator.AvailableDiscounts[0]);
			Assert.AreSame(secondDisctount, locator.AvailableDiscounts[1]);
			Assert.AreEqual(2, locator.AvailableDiscounts.Count);
		}
		
		[Test()]
		public void TestThatServiceLocatorAvailableFlightsReturnsExpectedFlights()
		{
			var firstFlight = new Flight(DateTime.Today, DateTime.Today.AddDays(1), 500);
			var secondFlight = new Flight(DateTime.Today, DateTime.Today.AddDays(3), 200);
			var locator = new ServiceLocator();
			
			locator.AddFlight(firstFlight);
			locator.AddFlight(secondFlight);
			
			Assert.AreSame(firstFlight, locator.AvailableFlights[0]);
			Assert.AreSame(secondFlight, locator.AvailableFlights[1]);
			Assert.AreEqual(2, locator.AvailableFlights.Count);
		}
		
		[Test()]
		public void TestThatServiceLocatorAvailableCarsReturnsExpectedCars()
		{
			var firstCar = new Car(5);
			var secondCar = new Car(4);
			var locator = new ServiceLocator();
			
			locator.AddCar(firstCar);
			locator.AddCar(secondCar);
			
			Assert.AreSame(firstCar, locator.AvailableCars[0]);
			Assert.AreSame(secondCar, locator.AvailableCars[1]);
			Assert.AreEqual(2, locator.AvailableCars.Count);
		}
	}
}
