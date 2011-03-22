
using System;
using System.Collections.Generic;

namespace Expedia
{
	public class Flight : Booking
	{
		private DateTime dateThatFlightLeaves;
		private DateTime dateThatFlightReturns;
		
		public int Miles
		{
			get; private set;	
		}
		
		#region Booking implementation
		public double getBasePrice ()
		{
			var lengthOfSpread = (dateThatFlightReturns - dateThatFlightLeaves).Days;
			
			return 200 + lengthOfSpread*20;
		}
		
		public int NumberOfPassengers
		{
			get
			{
				return Database.Passengers.Count;
			}
		}
		
		public IDatabase Database
		{
			get;
			set;
		}
		
		#endregion
		
		public Flight (DateTime startDate, DateTime endDate, int someMiles)
		{
			if(endDate < startDate)
				throw new InvalidOperationException("End date cannot be before start date!");
			
			if(someMiles < 0)
				throw new ArgumentOutOfRangeException("Miles must be positive!");
			
			dateThatFlightLeaves = startDate;
			dateThatFlightReturns = endDate;
			Miles = someMiles;
		}
	}
}
