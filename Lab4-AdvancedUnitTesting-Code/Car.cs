
using System;

namespace Expedia
{
	public class Car : Booking
	{
		private int numberOfDaysToRent;
		
		public String Name
		{
			get; set;
		}
		
		public IDatabase Database
		{
			get; set;	
		}
		
        //Get's the current mileage associated with the car
		public Int32 Mileage
		{
			get
			{
				return Database.Miles;	
			}
		}

        //Get's the current location of the car
        public String getCarLocation(int carNumber)
        {
            return Database.getCarLocation(carNumber);
        }
		
		#region Booking implementation
		public double getBasePrice ()
		{	
			double result = numberOfDaysToRent * 10;
			
			if(numberOfDaysToRent > 5)
			{	
				result *= 0.8;
			}
			
			return result;
		}
		#endregion
		
		public Car (int daysToRent)
		{
			if(daysToRent <= 0)
				throw new ArgumentOutOfRangeException("Days to Rent must be greater than zero!");
			
			numberOfDaysToRent = daysToRent;
		}
	}
}
