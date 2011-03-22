using System.Collections.Generic;
using System;

namespace Expedia
{
	public class Database : IDatabase
	{
		public List<String> Passengers
		{
			get
			{
				throw new InvalidOperationException("Can't access the database until production!");	
			}
		}
		
		public List<Int32> Rooms
		{
			get
			{
				throw new InvalidOperationException("Can't access the database until production!");	
			}
		}
		
		public Int32 Miles
		{
			get
			{
				throw new InvalidOperationException("Can't access the database until production!");	
			}
		}

        public String GetRoomOccupant(int roomNumber)
        {
            	throw new InvalidOperationException("Can't access the database until production!");	
			
        }
	}
}
