﻿using System;

namespace InterviewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Don't change code in this file, just make it work 

            var customer = new Customer("John Black");

            //orders
            customer.AddOrder(new Order("LCD", OrderCategory.Hardware, 220));
            customer.AddOrder(new Order("Mouse", OrderCategory.Hardware, 30));
            customer.AddOrder(new Order("Keyboard", OrderCategory.Hardware, 45));
            customer.AddOrder(new Order("OS", OrderCategory.Software, 90));
            customer.AddOrder(new Order("Minesweeper deluxe", OrderCategory.Software, 1200));
            customer.AddOrder(new Order("Delivery", OrderCategory.Services, 25));
            customer.AddOrder(new Order("Installation", OrderCategory.Services, 60));

            // discounts 
            // percent:  amount * (100-percent) / 100
            // fixed: amount - value
            // All fixed are applied before percent
            customer.AddDiscount(OrderCategory.Hardware, new PercentDiscount(10));
            customer.AddDiscount(OrderCategory.Hardware, new FixedDiscount(15));
            customer.AddDiscount(OrderCategory.Software, new PercentDiscount(20));
			customer.AddDiscount(OrderCategory.Services, new BonusDiscount());

            var hardwareTotal = customer.GetTotalPriceByOrderCategory(OrderCategory.Hardware);
            var hardwareTotalWithDiscount = customer.GetTotalPriceWithDiscountByOrderCategory(OrderCategory.Hardware);
			var softwareTotalWithDiscount = customer.GetTotalPriceWithDiscountByOrderCategory(OrderCategory.Software);
			var servicesTotalWithDiscount = customer.GetTotalPriceWithDiscountByOrderCategory(OrderCategory.Services);
            var total = customer.GetTotalPriceWithDiscount();

            Console.WriteLine("Expected hardware total: {0}, actual {1}", 220 + 30 + 45, hardwareTotal);
            Console.WriteLine("Expected hardware total with discount: {0}, actual {1}", (220 + 30 + 45 - 15) * (100 - 10) / 100, hardwareTotalWithDiscount);
			Console.WriteLine("Expected software total with discount: {0}, actual {1}", (90 + 1200) * (100 - 20) / 100, softwareTotalWithDiscount);
			Console.WriteLine("Expected services total with discount: {0}, actual {1}", (25 + 60 - 10), servicesTotalWithDiscount);
            Console.WriteLine("Expected total with discount: {0}, actual {1}", (220 + 30 + 45 - 15) * (100 - 10) / 100 + (90 + 1200) * (100 - 20) / 100 + 25 + 60 - 10, total);

            Console.ReadKey();

            // bonus: add new discount for services with rule when amount > 50 substract 10 otherwise 0
        }
    }
}
