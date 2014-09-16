using System.Diagnostics;

namespace InterviewTest
{
    public abstract class Discount
    {
	    protected const int PRIORITY_LOW = 10;
		protected const int PRIORITY_MEDIUM = 5;
		protected const int PRIORITY_HI = 0;

	    public int Priority { get; protected set; }

	    public abstract decimal Apply(decimal value);
    }
}
