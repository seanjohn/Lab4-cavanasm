using System;
using System.Collections.Generic;

namespace Expedia
{
	public class ServiceLocator
	{
		private static ServiceLocator _instance = null;
		public static ServiceLocator Instance
		{
			get
			{
				if(_instance == null)
					_instance = new ServiceLocator();
				
				return _instance;
			}
		}
		
		private List<Discount> discounts;
		private List<Flight> flights;
		private List<Car> cars;
		
		public ServiceLocator ()
		{
			discounts = new List<Discount>();
			flights = new List<Flight>();
			cars = new List<Car>();
		}
		
		public List<Flight> AvailableFlights
		{
			get { return flights; }
		}
		
		public List<Discount> AvailableDiscounts
		{
			get	{ return discounts;	}
		}
		
		public List<Car> AvailableCars
		{
			get { return cars; }	
		}
		
		public void AddDiscount(Discount aDiscount)
		{
			discounts.Add(aDiscount);	
		}
		
		public void AddFlight(Flight aFlight)
		{
			flights.Add(aFlight);	
		}
		
		public void RemoveFlight(Flight aFlight)
		{
			flights.Remove(aFlight);	
		}
		
		public void AddCar(Car aCar)
		{
			cars.Add(aCar);	
		}
		
		public void RemoveCar(Car aCar)
		{
			cars.Remove(aCar);	
		}
	}
}
