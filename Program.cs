using System;

namespace WhataDae__Wine_App
{

    class Program
    {

        private const int LegalAge = 21;
        
        static void Main(string[] args)
        {
            Console.WriteLine("****************************************Welcome to Whata Dae' Wines! **********************************\n\n");



            Console.WriteLine("Enter your DOB: MM/DD/YYYY");
            DateTime DOB = DateTime.Parse(Console.ReadLine());

            if (DOB < DateTime.Now.AddYears(-1 * LegalAge))
            {
                Console.WriteLine("\nAge Verification Successful!\n");
                Console.WriteLine("Please proceed with building your order.");

                var orderConfirmed = false;
                while (!orderConfirmed)
                {
                    Customer customer = GetCustomer();
                    var orderItems = GetOrderItems();

                    orderConfirmed = ConfirmOrder();

                    if (orderConfirmed)
                    {
                        GetOutput(customer, orderItems);
                    }
                }
                
                

            }
            else
            {
                Console.WriteLine("Sorry,You must be 21 or over to continue.");
                Console.WriteLine("press 0 or " + "any key to exit.");
                var input = Console.ReadLine();
                if (input == "0")
                {
                    System.Environment.Exit(0);
                }
            }
            return;

        }

        public static Customer GetCustomer()
        {

            Console.WriteLine("Let's get started with some basic information!\n\n");

            Customer customer = new Customer();

            Console.WriteLine("\nPlease enter your Last Name:");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("\nPlease enter your First Name:");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("\nEnter email:");
            customer.Email = Console.ReadLine();

            Console.WriteLine("\nEnter phone: e.g 5025551234");
            customer.Phone = Console.ReadLine();

            Console.WriteLine("\nEnter Street Address: (123 Main St): ");
            customer.StreetAddress = Console.ReadLine();

            Console.WriteLine("\nEnter City:");
            customer.City = Console.ReadLine();

            Console.WriteLine("\nEnter State: (KY)");
            customer.State = Console.ReadLine();

            Console.WriteLine("\nEnter ZIP Code");
            customer.PostalCode = Convert.ToInt32(Console.ReadLine());

            

            return customer;
        }

        public static List<OrderItem> GetOrderItems()
        {
            List<Product> products = new();

            Product product1 = new()
            {
                ProductId = "Red Wine",
                ProductName = "Cabernet",
                Price = 15.50m,

            };
            products.Add(product1);

            Product product2 = new ()
            {
                ProductId = "Red Wine",
                ProductName = "Malbec",
                Price = 15.50m,

            };
            products.Add(product2);

            Product product3 = new ()
            {
                ProductId = "Red Wine",
                ProductName = "Merlot",
                Price = 15.50m,

            };
            products.Add(product3);

            Product product4 = new ()
            {
                ProductId = "White Wine",
                ProductName = "Chardonnay",
                Price = 12.75m,

            };
            products.Add(product4);

            Product product5 = new ()
            {
                ProductId = "White Wine",
                ProductName = "Pinot Grigio",
                Price = 12.75m,

            };
            products.Add(product5);

            Product product6 = new ()
            {
                ProductId = "White Wine",
                ProductName = "Riesling",
                Price = 12.75m,

            };
            products.Add(product6);

            Product product7 = new ()
            {
                ProductId = "Rose Wine",
                ProductName = "Moscato",
                Price = 10.25m,

            };
            products.Add(product7);

            Product product8 = new ()
            {
                ProductId = "Rose Wine",
                ProductName = "Sirah",
                Price = 10.25m,

            };
            products.Add(product8);

            Product product9 = new ()
            {
                ProductId = "Rose Wine",
                ProductName = "Zinfandel",
                Price = 10.25m,

            };
            products.Add(product9);

            Console.WriteLine(" \n\nHere are the wines we have available for the current season:\n\n");
            Console.WriteLine("Red Wine Options");
            Console.WriteLine("Price: $15.50\n");
            Console.WriteLine("Cabernet");
            Console.WriteLine("Malbec");
            Console.WriteLine("Cabernet\n\n");

            Console.WriteLine("White Wine Options");
            Console.WriteLine("Price: $12.75\n");
            Console.WriteLine("Chardonnay");
            Console.WriteLine("Riesling");
            Console.WriteLine("Pinot Grigio\n\n");

            Console.WriteLine("Rose' Wine Options");
            Console.WriteLine("Price: $10.25\n");
            Console.WriteLine("Mascato");
            Console.WriteLine("Sirah");
            Console.WriteLine("Zinfandel\n");

            Console.WriteLine("******************************* Discounts NOW Available! ***************************************\n\n");

            Console.WriteLine("$1.00 OFF per Bottle when you buy 6 or more.");
            Console.WriteLine("$1.25 OFF per Bottle when you buy 12 or more.");
            Console.WriteLine("$2.00 OFF per Bottle when you buy 24 or more.\n");


            Console.WriteLine("Please type in the quantity for each item.   If you do not wish purchase a product pleasee add 0. \n");

            var orderItems = new List<OrderItem>();

            foreach (var product in products)
            {
                Console.WriteLine("Enter the quantity for {0}:", product.ProductName);

                OrderItem orderItem = new()
                {
                    Product = product
                };

                bool validEntry = false;

                do
                {
                    try
                    {
                        orderItem.Quantity = (Convert.ToInt32(Console.ReadLine()));
                        bool negative = orderItem.Quantity < 0;
                        if (!negative)
                        {
                            validEntry = true;
                        }
                        else
                        {
                            Console.WriteLine("Character Invalid. Please try again. Enter your order amount:");
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Character Invalid. Please try again. Enter your order amount:");
                    }

                } while (validEntry == false);

                if (orderItem.Quantity > 0)
                {
                    orderItem.PricePerLineItem = product.Price * orderItem.Quantity;

                    if (orderItem.Quantity > 0 && orderItem.Quantity < 10)
                    {
                        orderItem.DiscountPerLineItem = 0;
                    }
                    else if (orderItem.Quantity >= 10 && orderItem.Quantity < 25)
                    {
                        orderItem.DiscountPerLineItem = 1.10m;
                    }
                    else if (orderItem.Quantity >= 25 && orderItem.Quantity < 50)
                    {
                        orderItem.DiscountPerLineItem = 2.25m;
                    }
                    else if (orderItem.Quantity >= 50)
                    {
                        orderItem.DiscountPerLineItem = 5.50m;
                    }

                    orderItem.TotalDiscountPerLineItem = orderItem.DiscountPerLineItem * orderItem.Quantity;

                    orderItem.TotalPricePerLineItem = orderItem.PricePerLineItem - orderItem.TotalDiscountPerLineItem;

                    orderItems.Add(orderItem);
                }
            }
           
            return orderItems;
        }

        public static bool ConfirmOrder()
        {
            Console.WriteLine("\n\nPlease Confirm your information entered above by typing Y or N");
            
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Thanks!");
                return true;
            }
            else
            {
                Console.WriteLine("Missing Something?");
                Console.WriteLine("Let's take another look..");
                return false;
            }
        }

        public static void GetOutput(Customer customer, List<OrderItem> orderItems)
        {
            Console.WriteLine("\n\n\n\n                                               ****Information Confirmed****");

            Console.WriteLine($"\nCustomer Name: {customer.FirstName} {customer.LastName}");
     
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone: {customer.Phone}");
            Console.WriteLine($"Address: {customer.StreetAddress} {customer.City} {customer.State} {customer.PostalCode}");
            
            Console.WriteLine("Wines Ordered and Dicounts Applied:");

            decimal? grandTotalBeforeDiscount = 0m;
            decimal? grandTotalAfterDiscount = 0m;

            foreach (var orderItem in orderItems)
            {
                Console.WriteLine($"\nWine: {orderItem.Product.ProductName}");
                Console.WriteLine($"Price: {String.Format("{0:C}", orderItem.PricePerLineItem)}");
                Console.WriteLine($"Quantity: {orderItem.Quantity}");
                Console.WriteLine($"Discount Per Bottle: {String.Format("{0:C}", orderItem.DiscountPerLineItem)}");

                grandTotalBeforeDiscount += orderItem.TotalPricePerLineItem + orderItem.TotalDiscountPerLineItem;
                grandTotalAfterDiscount += orderItem.TotalDiscountPerLineItem;
            }

            Console.WriteLine($"\n\nGrand Total: {String.Format("{0:C}", grandTotalBeforeDiscount)}");
            Console.WriteLine($"Grand Total with Discounts: {String.Format("{0:C}", grandTotalAfterDiscount)}");
        }
    }
}