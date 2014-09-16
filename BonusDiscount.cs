using System;

namespace InterviewTest
{
	public class BonusDiscount : Discount
	{
		public BonusDiscount()
		{
			Priority = PRIORITY_MEDIUM;
		}

		public override decimal Apply(decimal value)
		{
			return (value > 50 ? value - 10 : value);
		}
	}
}