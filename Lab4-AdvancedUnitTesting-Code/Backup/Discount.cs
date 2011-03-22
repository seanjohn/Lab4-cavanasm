
using System;

namespace Expedia
{
	public class Discount
	{
		public Discount (double aReductionPercent, int aFrequentFlyerMilesCost)
		{
			ReductionPercent = aReductionPercent;
			FrequentFlyerMilesCost = aFrequentFlyerMilesCost;
		}
		
		public double ReductionPercent
		{
			get;
			private set;
		}
		
		public int FrequentFlyerMilesCost
		{
			get;
			private set;
		}
	}
}
