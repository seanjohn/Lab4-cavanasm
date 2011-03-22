
using System;

namespace Expedia
{
	public class Hotel : Booking
	{
		private int numberOfNightsToRent;
		
		public IDatabase Database
		{
			get;
			set;
		}
		
        //Returns the number of rooms available in the hotel
		public Int32 AvailableRooms
		{
			get
			{
				return Database.Rooms.Count;	
			}
		}

        //Returns the occupant of a room in the hotel
        public String getRoomOccupant(int roomNumber)
        {
            return Database.getRoomOccupant(roomNumber);
                 
        }
		
		#region Booking implementation
		public double getBasePrice ()
		{
			return 45 * numberOfNightsToRent;
		}
		#endregion
		
		public Hotel (int nightsToRent)
		{
			if(nightsToRent <= 0)
				throw new ArgumentOutOfRangeException("Nights to rent must be greater than zero!");
			
			numberOfNightsToRent = nightsToRent;
		}
	}
}
