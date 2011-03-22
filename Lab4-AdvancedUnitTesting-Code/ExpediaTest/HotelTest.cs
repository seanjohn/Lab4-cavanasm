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
        [Test()]
        public void TestThatHotelDoesGetRoomOccupantFromTheDatabase()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            String roomOccupant = "Whale Rider";
            String anotherRoomOccupant = "Raptor Wrangler";

            using (mocks.Record())
            {
                mockDatabase.getRoomOccupant(24);
                LastCall.Return(roomOccupant);

                mockDatabase.getRoomOccupant(1025);
                LastCall.Return(anotherRoomOccupant);
            }

            var target = new Hotel(10);
            target.Database = mockDatabase;
            String result;
            result = target.getRoomOccupant(1025);
            Assert.AreEqual(result, anotherRoomOccupant);

            result = target.getRoomOccupant(24);
            Assert.AreEqual(result, roomOccupant);
        }

        [Test()]
        public void TestThatHotelDoesGetRoomCountFromDatabase()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            List<Int32> Rooms = new List<int>();
            for (var i = 0; i < 100; i++)
            {
                Rooms.Add(i); 
            }

            mockDatabase.Rooms = Rooms;

            var target = new Hotel(10);
            target.Database = mockDatabase;

            int roomCount = target.AvailableRooms;
            Assert.AreEqual(roomCount, Rooms.Count);
        }
		
	}
}
