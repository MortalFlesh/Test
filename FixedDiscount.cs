namespace InterviewTest
{
    public class FixedDiscount : Discount
    {
	    private readonly decimal _discountAmount;

        public FixedDiscount(decimal amount)
        {
	        Priority = PRIORITY_HI;

	        _discountAmount = amount;
        }

	    public override decimal Apply(decimal value)
	    {
		    return value - _discountAmount;
	    }
    }
}
