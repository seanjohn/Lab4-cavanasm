using NUnit.Framework;
using System;
using Expedia;

namespace ExpediaTest
{
	[TestFixture()]
	public class DiscountTest
	{
		[Test()]
		public void TestThatDiscountInitializes()
		{
			var target = new Discount(0.01, 1);
			Assert.IsNotNull(target);
			Assert.AreEqual(0.01, target.ReductionPercent);
			Assert.AreEqual(1, target.FrequentFlyerMilesCost);
		}
	}
}
