using System;
using System.Collections.Generic;
using System.Linq;

namespace chapter_10_04
{
   class Customer
   {
      public long Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
   }

   class Article
   {
      public long Id { get; set; }
      public string EAN13 { get; set; }
      public string Name { get; set; }
      public double Price { get; set; }
   }

   class OrderLine
   {
      public long Id { get; set; }
      public long OrderId { get; set; }
      public long ArticleId { get; set; }
      public double Quantity { get; set; }
      public double Discount { get; set; }
   }

   class Order
   {
      public long Id { get; set; }
      public DateTime Date { get; set; }
      public long CustomerId { get; set; }
      public double Discount { get; set; }
   }


   class Program
   {
      static void Main(string[] args)
      {
         {
            int[] arr = { 1, 1, 3, 5, 8, 13, 21, 34 };
            {
               int sum = 0;
               for (int i = 0; i < arr.Length; ++i)
               {
                  if (arr[i] % 2 == 1)
                     sum += arr[i];
               }
            }

            {
               int sum = arr.Where(x => x % 2 == 1).Sum();
            }

            {
               int sum = (from x in arr
                          where x % 2 == 1
                          select x).Sum();

            }
         }

         {
            var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            {
               var count = text
                  .Split(new char[] { ' ', ',', '.' })
                  .Where(w => !string.IsNullOrEmpty(w))
                  .Count();

               var groups = text
                  .Split(new char[] { ' ', ',', '.' })
                  .GroupBy(w => w.Length, w => w.ToLower())
                  .Select(g => new { Length = g.Key, Words = g })
                  .Where(g => g.Length > 0)
                  .OrderBy(g => g.Length);

               foreach (var group in groups)
               {
                  Console.WriteLine($"Length={group.Length}");
                  foreach (var word in group.Words)
                  {
                     Console.WriteLine($"  {word}");
                  }
               }
            }

            {
               var count = (from w in text.Split(new char[] { ' ', ',', '.' })
                            where !string.IsNullOrEmpty(w)
                            select w).Count();

               var groups = from w in text.Split(new char[] { ' ', ',', '.' })
                            group w.ToLower() by w.Length into g
                            where g.Key > 0
                            orderby g.Key
                            select new { Length = g.Key, Words = g };

               foreach (var group in groups)
               {
                  Console.Write($"Length={group.Length}: ");
                  Console.WriteLine(string.Join(',', group.Words));
               }
            }
         }

         {
            var articles = new List<Article>()
            {
               new Article(){ Id = 1, EAN13 = "5901234123457", Name = "paper", Price = 100.0},
               new Article(){ Id = 2, EAN13 = "5901234123466", Name = "pen", Price = 200.0},
               new Article(){ Id = 3, EAN13 = "5901234123475", Name = "pencil", Price = 300.0},
               new Article(){ Id = 4, EAN13 = "5901234123484", Name = "paint", Price = 400.0},
               new Article(){ Id = 5, EAN13 = "5901234123493", Name = "clips", Price = 500.0},
            };

            var customers = new List<Customer>()
            {
               new Customer() { Id = 101, FirstName = "John", LastName = "Doe", Email = "john.doe@email.com"},
               new Customer() { Id = 102, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@email.com"},
            };

            var orders = new List<Order>()
            {
               new Order() { Id = 1001, Date = new DateTime(2020, 3, 12), CustomerId = customers[0].Id },
               new Order() { Id = 1002, Date = new DateTime(2020, 4, 23), CustomerId = customers[1].Id },
               new Order() { Id = 1003, Date = new DateTime(2020, 4, 26), CustomerId = customers[0].Id },
               new Order() { Id = 1004, Date = new DateTime(2020, 5, 12), CustomerId = customers[0].Id }
            };

            var orderlines = new List<OrderLine>()
            {
               new OrderLine(){ Id = 1, OrderId=orders[0].Id, ArticleId = articles[0].Id, Quantity=2},
               new OrderLine(){ Id = 2, OrderId=orders[0].Id, ArticleId = articles[1].Id, Quantity=1},
               new OrderLine(){ Id = 3, OrderId=orders[1].Id, ArticleId = articles[2].Id, Quantity=1},
               new OrderLine(){ Id = 4, OrderId=orders[1].Id, ArticleId = articles[3].Id, Quantity=2},
               new OrderLine(){ Id = 5, OrderId=orders[2].Id, ArticleId = articles[3].Id, Quantity=2},
               new OrderLine(){ Id = 6, OrderId=orders[2].Id, ArticleId = articles[4].Id, Quantity=1},
               new OrderLine(){ Id = 7, OrderId=orders[3].Id, ArticleId = articles[1].Id, Quantity=1},
               new OrderLine(){ Id = 8, OrderId=orders[3].Id, ArticleId = articles[2].Id, Quantity=2},
               new OrderLine(){ Id = 9, OrderId=orders[3].Id, ArticleId = articles[1].Id, Quantity=3},
            };            

            {
               var query = 
                  orders.Join(orderlines,
                              o => o.Id,
                              ol => ol.OrderId,
                              (o, ol) => new { Order = o, Line = ol })
                        .Join(customers,
                              o => o.Order.CustomerId,
                              c => c.Id,
                              (o, c) => new { o.Order, o.Line, Customer = c})
                        .Join(articles,
                              o => o.Line.ArticleId,
                              a => a.Id,
                              (o, a) => new { o.Order, o.Line, o.Customer, Article = a})
                        .Where(o => o.Order.Date >= new DateTime(2020, 4, 1) &&
                                    o.Customer.FirstName == "John")
                        .OrderBy(o => o.Article.Name)                        
                        .Select(o => o.Article.Name);

               Console.WriteLine(string.Join(',', query));
            }

            {
               var query = from o in orders
                           join ol in orderlines on o.Id equals ol.OrderId
                           join c in customers on o.CustomerId equals c.Id
                           join a in articles on ol.ArticleId equals a.Id
                           where o.Date >= new DateTime(2020, 4, 1) &&
                                 c.FirstName == "John"
                           orderby a.Name
                           select a.Name;

               Console.WriteLine(string.Join(',', query));
            }
         }
      }
   }
}
