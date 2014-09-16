namespace InterviewTest
{
    public class PercentDiscount : Discount
    {
	    private readonly decimal _percentValue;

        public PercentDiscount(decimal percentValue)
        {
	        Priority = PRIORITY_LOW;

	        _percentValue = percentValue;
        }

	    public override decimal Apply(decimal value)
	    {
		    return value*(100 - _percentValue)/100;
	    }
    }
}
