using System;
using NUnit.Framework;
using Expedia;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestFixture()]
	public class CarTest
	{	
		private Car targetCar;
		private MockRepository mocks;
		
		[SetUp()]
		public void SetUp()
		{
			targetCar = new Car(5);
			mocks = new MockRepository();
		}
		
		[Test()]
		public void TestThatCarInitializes()
		{
			Assert.IsNotNull(targetCar);
		}	
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForFiveDays()
		{
			Assert.AreEqual(50, targetCar.getBasePrice()	);
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForTenDays()
		{
            var target = new Car(10);
			Assert.AreEqual(80, target.getBasePrice());	
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForSevenDays()
		{
			var target = new Car(7);
			Assert.AreEqual(10*7*.8, target.getBasePrice());
		}
		
		[Test()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatCarThrowsOnBadLength()
		{
			new Car(-5);
		}

        [Test()]
        public void TestThatCarLocationIsInDatabase()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            using (mocks.Record())
            {
                mockDatabase.getCarLocation(10);
                LastCall.Return("San Fran");
                mockDatabase.getCarLocation(9001);
                LastCall.Return("There's no way that can be right.");
            }
            var target = new Car(500);
            target.Database = mockDatabase;
            String result;
            result = target.getCarLocation(10);
            Assert.AreEqual("San Fran", result);

            result = target.getCarLocation(9001);
            Assert.AreEqual("There's no way that can be right.", result);
        }

        [Test()]
        public void TestThatCarCanGetMileageFromDatabase()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();

            mockDatabase.Miles = 500;
            var target = new Car(10);
            target.Database = mockDatabase;
            Assert.AreEqual(target.Mileage, 500);

        }

        [Test()]
        public void TestThatBMWBookingIsCorrectlyPriced()
        {
            var target = ObjectMother.BMW();
            Assert.AreEqual(80, target.getBasePrice());	
        }
	}
}
