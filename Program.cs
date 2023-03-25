using System;

namespace WhataDae__Wine_App
{

    class Program
    {

        private const int LegalAge = 21;
        
        static void Main(string[] args)
        {
            Console.WriteLine("*************************************  Welcome to Whata Dae' Wines!   ********************************\n\n");
            Console.WriteLine("                            We are one of the finest Local Wine Vinyards around!\n");
            Console.WriteLine("             We create and serve homemade, refined, and delicious wines only using fresh ingredients!\n\n");


            //Age Verification feature. Only allows 21 and over to continue through the app//
            Console.WriteLine("Enter your DOB: MM/DD/YYYY");
            DateTime DOB = DateTime.Parse(Console.ReadLine());

            if (DOB < DateTime.Now.AddYears(-1 * LegalAge))
            {
                Console.WriteLine("\n                                         Age Verification Successful!");
                Console.WriteLine("                                   Please proceed with building your wine order.");

                // master loop feature  to re-enter in information if order confirmation returnes false "N".//
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
                
                

            }// program will exit if ager verification returns false//
            else
            {
                Console.WriteLine("Sorry,You must be 21 or over to continue.");
                Console.WriteLine("Press 0 or " + "any key to exit.");
                var input = Console.ReadLine();
                if (input == "0")
                {
                    System.Environment.Exit(0);
                }
            }
            return;

        }

        //customer class that recives basic information. Input iformation will be diplayed after confirmation initiated responding "Y"//
        public static Customer GetCustomer()
        {

            Console.WriteLine("\n\n\nLet's get started with some basic information!\n\n");

            Customer customer = new Customer();

            Console.WriteLine("Enter your Last Name:");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("\nEnter your First Name:");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("\nEmail:");
            customer.Email = Console.ReadLine();

            Console.WriteLine("\nPhone Number: e.g 5025551234");
            customer.Phone = Console.ReadLine();

            Console.WriteLine("\nEnter Street Address:  (e.g. 123 Main St): ");
            customer.StreetAddress = Console.ReadLine();

            Console.WriteLine("\nEnter City:");
            customer.City = Console.ReadLine();

            Console.WriteLine("\nEnter State: (e.g KY)");
            customer.State = Console.ReadLine();

            Console.WriteLine("\nEnter ZIP Code");
            customer.PostalCode = Convert.ToInt32(Console.ReadLine());

            

            return customer;
        }
        //product class with List feature represents Order selection with pricing displayed.
        public static List<OrderItem> GetOrderItems()
        {
            List<Product> products = new();

            Product product1 = new()
            {
                ProductId = "Red Wine",
                ProductName = "Cabernet",
                Price = 12.50m,

            };
            products.Add(product1);

            Product product2 = new ()
            {
                ProductId = "Red Wine",
                ProductName = "Malbec",
                Price = 12.50m,

            };
            products.Add(product2);

            Product product3 = new ()
            {
                ProductId = "Red Wine",
                ProductName = "Merlot",
                Price = 12.50m,

            };
            products.Add(product3);

            Product product4 = new ()
            {
                ProductId = "White Wine",
                ProductName = "Chardonnay",
                Price = 10.75m,

            };
            products.Add(product4);

            Product product5 = new ()
            {
                ProductId = "White Wine",
                ProductName = "Pinot Grigio",
                Price = 10.75m,

            };
            products.Add(product5);

            Product product6 = new ()
            {
                ProductId = "White Wine",
                ProductName = "Riesling",
                Price = 10.75m,

            };
            products.Add(product6);

            Product product7 = new ()
            {
                ProductId = "Rose Wine",
                ProductName = "Sweet Rose' Moscato",
                Price = 8.25m,

            };
            products.Add(product7);

            Product product8 = new ()
            {
                ProductId = "Rose Wine",
                ProductName = "Sirah",
                Price = 8.25m,

            };
            products.Add(product8);

            Product product9 = new ()
            {
                ProductId = "Rose Wine",
                ProductName = "Zinfandel",
                Price = 8.25m,

            };
            products.Add(product9);


            Console.WriteLine($"\n\n                             Fantastic! You're like Butter...... You're on a roll!");
            Console.WriteLine(" \n\nHere are the wines we currently have available for the season:\n");
            Console.WriteLine("Red Wine Options");
            Console.WriteLine("Price: $12.50");
            Console.WriteLine("Cabernet");
            Console.WriteLine("Malbec");
            Console.WriteLine("Merlot\n");

            Console.WriteLine("White Wine Options");
            Console.WriteLine("Price: $10.75");
            Console.WriteLine("Chardonnay");
            Console.WriteLine("Riesling");
            Console.WriteLine("Pinot Grigio\n");

            Console.WriteLine("Rose' Wine Options");
            Console.WriteLine("Price: $8.25");
            Console.WriteLine("Sweet Rose' Moscato");
            Console.WriteLine("Sirah");
            Console.WriteLine("Zinfandel\n");
            Console.WriteLine("                                            WE HAVE GREAT NEWS!\n");
            Console.WriteLine("    *******************************       Discounts NOW Available!       ***********************************\n");

            Console.WriteLine("$0.15 OFF per Bottle when you buy 10 or more.");
            Console.WriteLine("$0.25 OFF per Bottle when you buy 25 or more.");
            Console.WriteLine("$0.50 OFF per Bottle when you buy 50 or more.\n");

            //user is propmted for each wine. Enter in quantity or "0". Depending on what quantity determines pricing. must follow through entire prompt.//
            Console.WriteLine("Please type in the quantity for each item.  If you do not wish purchase a product please add 0 for item quantity. \n\n");

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
                
                //Calculations for disounts to be appplied to quantity of order items.//
                
                if (orderItem.Quantity > 0)
                {
                    orderItem.PricePerLineItem = product.Price * orderItem.Quantity;

                    if (orderItem.Quantity > 0 && orderItem.Quantity < 10)
                    {
                        orderItem.DiscountPerLineItem = 0;
                    }
                    else if (orderItem.Quantity >= 10 && orderItem.Quantity < 25)
                    {
                        orderItem.DiscountPerLineItem = 0.15m;
                    }
                    else if (orderItem.Quantity >= 25 && orderItem.Quantity < 50)
                    {
                        orderItem.DiscountPerLineItem = 0.25m;
                    }
                    else if (orderItem.Quantity >= 50)
                    {
                        orderItem.DiscountPerLineItem = 0.50m;
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
            //order confirmation if return true, information will be displayed with completed order information. //
            Console.WriteLine("                          You've made some excellent wine selections!\n");
            Console.WriteLine("\n\nPlease confirm your information and wine order above by typing Y or N.");
            
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("\n\n                                 Thankyou!");
                return true;
            }
            else
            {
                Console.WriteLine("Did you forget something?");
                Console.WriteLine("Your age was previously verified.\n");
                Console.WriteLine("Now worries...How about a RE-DO! Re-enter Information and Wine order.");
                return false;
            }
        }
        // complete order and customer information output, total order wit dicounts, quanities and grand totals.//
        public static void GetOutput(Customer customer, List<OrderItem> orderItems)
        {
            Console.WriteLine("\n\n\n\n                                               ****Information Confirmed****");

            Console.WriteLine($"\nCustomer Name: {customer.FirstName} {customer.LastName}");
     
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone: {customer.Phone}");
            Console.WriteLine($"Address: {customer.StreetAddress} {customer.City} {customer.State} {customer.PostalCode}");
            
            Console.WriteLine("\n\nWines Ordered and Discounts Applied:\n");

            decimal? grandTotalBeforeDiscount = 0m;
            decimal? grandTotalAfterDiscount = 0m;
            foreach (var orderItem in orderItems)
            {
                Console.WriteLine($"\nWine: {orderItem.Product.ProductName}");
                Console.WriteLine($"Price: {String.Format("{0:C}", orderItem.PricePerLineItem)}");
                Console.WriteLine($"Quantity: {orderItem.Quantity}");
                Console.WriteLine($"Discount Per Bottle: {String.Format("{0:C}", orderItem.DiscountPerLineItem)}");

                decimal? totalDiscountPerLineItem = orderItem.DiscountPerLineItem * orderItem.Quantity;
                grandTotalBeforeDiscount = orderItem.TotalPricePerLineItem;
                grandTotalAfterDiscount += orderItem.TotalPricePerLineItem - orderItem.DiscountPerLineItem;
                
                
            }

            Console.WriteLine($"\nGrand Total: {String.Format("{0:C}", grandTotalAfterDiscount)}"); 

            Console.WriteLine("\n\n                                           Scroll up to see entire order details\n\n");

           

            Console.WriteLine("\n         A Representative will contact you in the next 15 minutes to retrieve and submit a payment method from you.");

            Console.WriteLine("\n\n                  Thankyou for choosing WhataDae' Wines!      We appreciate your buisness!\n\n");

            Console.WriteLine("                                     ****************      CHEERS!!      ****************\n\n");

            
        }
    }
}