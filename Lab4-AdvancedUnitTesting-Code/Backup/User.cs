using System;
using System.Collections.Generic;
using System.Collections;

namespace Expedia
{
	public class User
	{
		public User(String aName)
		{
			Name = aName;
			Bookings = new List<Booking>();
		}
		
		public String Name
		{
			get; private set;
		}
		
		public Int32 FrequentFlierMiles
		{
			get 
			{
				var result = 0;
				foreach(var booking in Bookings)
				{
					if(booking.GetType() == typeof(Flight))
					{
						result += ((Flight)booking).Miles;
					}
				}
				
				return result;
			}
		}
		
		private double GetDiscount()
		{
			var result = 1.0;
			foreach(var discount in ServiceLocator.Instance.AvailableDiscounts)
			{	
				if(1.0-discount.ReductionPercent < result && discount.FrequentFlyerMilesCost <= FrequentFlierMiles)
				{
					result = 1.0 - discount.ReductionPercent;
				}
			}
			return result;
		}
		
		public double Price
		{
			get
			{
				var result = 0.0;
				foreach(var booking in Bookings)
				{
					result += booking.getBasePrice();	
				}
				return result *	GetDiscount();
			}
		}
		
		public List<Booking> Bookings
		{
			get; private set;
		}
		
		public void book(params Booking[] bookings)
		{
			foreach(var booking in bookings)
			{
				Bookings.Add(booking);
				
				if(booking.GetType() == typeof(Flight))
				{
					ServiceLocator.Instance.RemoveFlight((Flight)booking);	
				}
				
				if(booking.GetType() == typeof(Car))
				{
                    ServiceLocator.Instance.RemoveCar((Car)booking);	
				}
			}
		}
	}
}
