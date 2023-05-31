namespace LINQPrj
{
    class Program
    {
        public static void Main()
        {
            // List is a generic type that can store any type of data in it.
            // For example, you can store int, string, double, etc. in a List.
            // You can also store objects in a List as shown below.
            List<Item> list = new List<Item>()
            {
                new Item { ItemID = 1, ItemName = "Pen" },
                new Item { ItemID = 2, ItemName = "Pencil" },
                new Item { ItemID = 3, ItemName = "Notebook" },
                new Item { ItemID = 4, ItemName = "Eraser" },
                new Item { ItemID = 5, ItemName = "Sharpener" }
            };
            List<Customer> customer = new List<Customer>()
            {
                new Customer { CustomerID = 1, CustomerName = "Abul", area = "New Market" },
                new Customer { CustomerID = 2, CustomerName = "Babul", area = "Dhanmondi" },
                new Customer { CustomerID = 3, CustomerName = "Kabul", area = "Gulshan" },
                new Customer { CustomerID = 4, CustomerName = "Sabul", area = "Mirpur" },
                new Customer { CustomerID = 5, CustomerName = "Nabul", area = "Uttara" },
                new Customer { CustomerID = 6, CustomerName = "Dabul", area = "Lalmatia" },
            };
            List<Orders> orders = new List<Orders>()
            {
                new Orders { OrderID=1, OrderDate = new DateTime(2023, 5, 27), CustomerID = 1, ItemID = 1, ItemRate = 200, Quantity = 2 },
                new Orders { OrderID=2, OrderDate = new DateTime(2023, 5, 24), CustomerID = 1, ItemID = 2, ItemRate = 500, Quantity = 1 },
                new Orders { OrderID=3, OrderDate = new DateTime(2023, 5, 22), CustomerID = 2, ItemID = 1, ItemRate = 100, Quantity = 2 },
                new Orders { OrderID=4, OrderDate = new DateTime(2023, 5, 21), CustomerID = 2, ItemID = 2, ItemRate = 520, Quantity = 8 },
                new Orders { OrderID=5, OrderDate = new DateTime(2023, 5, 17), CustomerID = 3, ItemID = 1, ItemRate = 140, Quantity = 2 },
                new Orders { OrderID=6, OrderDate = new DateTime(2023, 5, 16), CustomerID = 3, ItemID = 2, ItemRate = 570, Quantity = 3 },
                new Orders { OrderID=7, OrderDate = new DateTime(2023, 5, 15), CustomerID = 4, ItemID = 1, ItemRate = 15, Quantity = 2 },
                new Orders { OrderID=8, OrderDate = new DateTime(2023, 5, 14), CustomerID = 4, ItemID = 2, ItemRate = 540, Quantity = 4 },
                new Orders { OrderID=9, OrderDate = new DateTime(2023, 5, 13), CustomerID = 5, ItemID = 1, ItemRate = 120, Quantity = 2 },
                new Orders { OrderID=10, OrderDate = new DateTime(2023, 5, 12), CustomerID = 5, ItemID = 2, ItemRate = 560, Quantity = 5 },
                new Orders { OrderID=11, OrderDate = new DateTime(2023, 5, 11), CustomerID = 6, ItemID = 1, ItemRate = 110, Quantity = 2 },
            };
            // LINQ Query Syntax
            // Query 1: Get all items 
            var itemList = from i in list
                           select i;
            //// print query1
            foreach (var item in itemList)
            {
                Console.WriteLine(item.ItemID + " " + item.ItemName);
            }

            //// Query 2: Get all customers
            var customerList = from c in customer
                               select c;
            //// print query2
            foreach (var cust in customerList)
            {
                Console.WriteLine(cust.CustomerID + " " + cust.CustomerName + " " + cust.area);
            }

            //// Query 3: Get all orders
            var orderList = from o in orders
                            select o;
            //// print query3
            foreach (var order in orderList)
            {
                Console.WriteLine(order.OrderID + " " + order.OrderDate + " " + order.CustomerID + " " + order.ItemID + " " + order.ItemRate + " " + order.Quantity);
                //}

                //// Query 4: Select only CustomerName and CustomerID where CustomerID is 3
                var customerIDNameByID = from customers in customer
                                         where customers.CustomerID == 3
                                         select new { customers.CustomerID, customers.CustomerName };
                //// print query4
                foreach (var c in customerIDNameByID)
                {
                    Console.WriteLine(c.CustomerID + " " + c.CustomerName);
                }
                // Query 5: OrderDate, CustomerName, ItemName, ItemRate, Quantity and Total joined from all tables
                var orderDetails = from order2 in orders
                                   join cust in customer on order2.CustomerID equals cust.CustomerID
                                   join item in list on order2.ItemID equals item.ItemID
                                   orderby cust.CustomerName descending
                                   select new { order2.OrderDate, cust.CustomerName, item.ItemName, order2.ItemRate, order2.Quantity, Total = order2.Quantity * order2.ItemRate };
                // print query5
                foreach (var orderDetail in orderDetails)
                {
                    Console.WriteLine(orderDetail.OrderDate + ":" + orderDetail.CustomerName + " " + orderDetail.ItemName + " " + orderDetail.ItemRate + " " + orderDetail.Quantity + " " + orderDetail.Total);
                }
                // Query 6: Same query but only where CustomerID=1
                var orderDetailsByID = from order1 in orders
                                       join cust in customer on order1.CustomerID equals cust.CustomerID
                                       join item in list on order1.ItemID equals item.ItemID
                                       where cust.CustomerID == 1
                                       select new { order1.OrderDate, cust.CustomerName, item.ItemName, order1.ItemRate, order1.Quantity, Total = order1.Quantity * order1.ItemRate };
                // print query6
                foreach (var orderDetail in orderDetailsByID)
                {
                    Console.WriteLine(orderDetail.OrderDate + ":" + orderDetail.CustomerName + " " + orderDetail.ItemName + " " + orderDetail.ItemRate + " " + orderDetail.Quantity + " " + orderDetail.Total);
                }
                // Query 7: Same query but only where OrderDate is between 2023-05-27 and 2023-05-20
                var orderDetailsByDate = from order3 in orders
                                         join cust in customer on order3.CustomerID equals cust.CustomerID
                                         join item in list on order3.ItemID equals item.ItemID
                                         where order3.OrderDate >= new DateTime(2023, 5, 20) && order3.OrderDate <= new DateTime(2023, 5, 27)
                                         select new { order3.OrderDate, cust.CustomerName, item.ItemName, order3.ItemRate, order3.Quantity, Total = order3.Quantity * order3.ItemRate };
                // print query7
                foreach (var orderDetail in orderDetailsByDate)
                {
                    Console.WriteLine(orderDetail.OrderDate + ":" + orderDetail.CustomerName + " " + orderDetail.ItemName + " " + orderDetail.ItemRate + " " + orderDetail.Quantity + " " + orderDetail.Total);
                }
                // Query 8: Same query but the area is Mirpur, Uttara or Lalmatia with in operator
                var orderDetailsByArea = from order4 in orders
                                         join cust in customer on order4.CustomerID equals cust.CustomerID
                                         join item in list on order4.ItemID equals item.ItemID
                                         where new[] { "Lalmatia", "Mirpur", "Uttara" }.Contains(cust.area)
                                         select new { order4.OrderDate, cust.CustomerName, cust.area, item.ItemName, order4.ItemRate, order4.Quantity, Total = order4.Quantity * order4.ItemRate };
                // print query8
                foreach (var orderDetail in orderDetailsByArea)
                {
                    Console.WriteLine(orderDetail.OrderDate + ":" + orderDetail.CustomerName + " " + orderDetail.area + " " + orderDetail.ItemName + " " + orderDetail.ItemRate + " " + orderDetail.Quantity + " " + orderDetail.Total);
                }

                //-------------------------------------------------------------------------------------
                // Generic
                // What is Generic?
                // Generic is a type of class, interface, delegate or method that can be used with any data type.
                ClsCompare<int> clsCompare1 = new ClsCompare<int>();
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(clsCompare1.Compare(a, b));

                ClsCompare<string> clsCompare2 = new ClsCompare<string>();
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();
                Console.WriteLine(clsCompare2.Compare(str1, str2));

                ClsCompare<bool> clsCompare3 = new ClsCompare<bool>();
                bool bool1 = Convert.ToBoolean(Console.ReadLine());
                bool bool2 = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine(clsCompare3.Compare(bool1, bool2));


                ClGeneric<string> clGeneric1 = new ClGeneric<string>("Rahim", "Name");
                Console.WriteLine(clGeneric1.Name + " " + clGeneric1.Value);

                ClGeneric<int> clGeneric2 = new ClGeneric<int>(25, "Age");
                Console.WriteLine(clGeneric2.Name + " " + clGeneric2.Value);

                GenericMethod g1 = new GenericMethod();
                Console.WriteLine(g1.FirstNumber(10));
                Console.WriteLine(g1.FirstNumber(10.5));
                Console.WriteLine(g1.FirstNumber("Hello"));
                Console.WriteLine(g1.FirstNumber(true));
                Console.WriteLine(g1.FirstNumber(Convert.ToDateTime("2023-05-29")));

                Console.WriteLine();

                Console.WriteLine(g1.SecondNumber(40.2));
                Console.WriteLine(g1.SecondNumber(true));
                Console.WriteLine(g1.SecondNumber("World"));



            }
        }
    }
}