
using System;
using System.Collections.Generic;

namespace Expedia
{
	public interface IDatabase
	{
		List<String> Passengers { get; }
        List<Int32> Rooms { get; set; }
        Int32 Miles { get; set; }

        String getRoomOccupant(int roomNumber);
        String getCarLocation(int carNumber);
      
	}
}
