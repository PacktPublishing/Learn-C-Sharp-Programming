using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_04
{
    [TestClass]
    public class PatternMatching3
    {
        [TestMethod]
        public void TestMethod1()
        {
            const int len = 6;
            var weekDays = Enum.GetNames(typeof(DayOfWeek));
            var expected = new[] { "Sunday", "Monday", "Friday", };

            var six = weekDays
                .Where(w => w is string { Length: len })
                .ToArray();

            Assert.IsTrue(six.SequenceEqual(expected));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var order = new Order()
            {
                IsMadeOnWeb = true,
                Quantity = 1000,
                Customer = new Customer()
                {
                    Country = "Italy"
                },
            };

            Assert.AreEqual(7.5m, GetDiscount(order));
            order.Quantity = 1;
            Assert.AreEqual(5.0m, GetDiscount(order));
            order.IsMadeOnWeb = false;
            Assert.AreEqual(2.0m, GetDiscount(order));
            order.Customer.Country = string.Empty;
            Assert.AreEqual(0m, GetDiscount(order));
        }

        public decimal GetDiscount(Order order) => order switch
        {
            var o when o.Quantity > 100 => 7.5m,
            { IsMadeOnWeb: true } => 5.0m,
            { Customer: { Country: "Italy" } } => 2.0m,
            _ => 0,
        };


    }

    public class Order
    {
        public Guid Id { get; set; }
        public bool IsMadeOnWeb { get; set; }
        public Customer Customer { get; set; }
        public decimal Quantity { get; set; }
    }

    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }

}
