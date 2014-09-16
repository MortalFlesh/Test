using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest
{
    public class Customer
    {
	    private readonly string _name;
		private readonly Dictionary<OrderCategory, List<Order>> _ordersByCategory = new Dictionary<OrderCategory, List<Order>>();
	    private readonly Dictionary<OrderCategory, List<Discount>> _discountsByCategory = new Dictionary<OrderCategory, List<Discount>>();

        public Customer(string name)
        {
	        _name = name;
        }


	    public void AddOrder(Order order)
	    {
		    var orderCategory = order.Category;

		    if (!_ordersByCategory.ContainsKey(orderCategory))
		    {
			    _ordersByCategory[orderCategory] = new List<Order>();
		    }

			_ordersByCategory[orderCategory].Add(order);
	    }

	    public void AddDiscount(OrderCategory orderCategory, Discount discount)
	    {
		    if (!_discountsByCategory.ContainsKey(orderCategory))
		    {
			    _discountsByCategory[orderCategory] = new List<Discount>();
		    }
			
			_discountsByCategory[orderCategory].Add(discount);
	    }

	    public decimal GetTotalPriceByOrderCategory(OrderCategory orderCategory)
	    {
		    return _ordersByCategory.Where(pair => pair.Key == orderCategory).Sum(pair => pair.Value.Sum(o => o.Price));
	    }

	    public decimal GetTotalPriceWithDiscountByOrderCategory(OrderCategory orderCategory)
	    {
		    var total = GetTotalPriceByOrderCategory(orderCategory);
		    var discountListsByCategory = _discountsByCategory.Where(pair => pair.Key == orderCategory).Select(pair => pair.Value);

			foreach (var discountList in discountListsByCategory)
		    {
			    foreach (var discount in discountList.OrderBy(d => d.Priority))
			    {
				    total = discount.Apply(total);
			    }
		    }

		    return total;
	    }

	    public decimal GetTotalPriceWithDiscount()
	    {
			return _ordersByCategory.Keys.Sum(orderCategory => GetTotalPriceWithDiscountByOrderCategory(orderCategory));
	    }
    }
}
