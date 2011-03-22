using System;
using Expedia;
using NUnit.Framework;
using System.Collections.Generic;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestFixture()]
	public class HotelTest
	{
		private Hotel targetHotel;
		private readonly int NightsToRentHotel = 5;
		private MockRepository mocks;
		
		[SetUp()]
		public void SetUp()
		{
			targetHotel = new Hotel(NightsToRentHotel);
			mocks = new MockRepository();
		}
		
		[Test()]
		public void TestThatHotelInitializes()
		{
			Assert.IsNotNull(targetHotel);
		}
		
		[Test()]
		public void TestThatHotelHasCorrectBasePriceForOneDayStay()
		{
			var target = new Hotel(1);
			Assert.AreEqual(45, target.getBasePrice());
		}
		
		[Test()]
		public void TestThatHotelHasCorrectBasePriceForTwoDayStay()
		{
			var target = new Hotel(2);
			Assert.AreEqual(90, target.getBasePrice());
		}
		
		[Test()]
		public void TestThatHotelHasCorrectBasePriceForTenDaysStay()
		{
			var target = new Hotel(10);
			Assert.AreEqual(450, target.getBasePrice());
		}
		
		[Test()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatHotelThrowsOnBadLength()
		{
			new Hotel(-5);
		}
		
	}
}
