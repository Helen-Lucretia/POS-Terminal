using System;
using System.Collections.Generic;
using System.Linq;

namespace POS_Terminal
{
    public class Product
    {
        public string pName { get; set; }
        public string pCategory { get; set; }
        public string pDescription { get; set; }
        public decimal pPrice { get; set; }

        public Product(string name, string category, string description, decimal price)
        {
            pName = name;
            pCategory = category;
            pDescription = description;
            pPrice = price;
        }

        public override string ToString()
        {
            return $"{pName} \tCategory: {pCategory} \nDescription: {pDescription} \nPrice: {pPrice}";
        }
    }
    public class Menu
    {
        public static void DisplayMenu(List<Product> coffee)
        {
            int productNum = 1;
            foreach (Product product in coffee)
            {
                Console.WriteLine($"{productNum} " + product.ToString());
                productNum++;
            }
        }
    }
    public class Cart
    {
        
        public static void Reciept()
        {
            Console.WriteLine();
            Console.WriteLine("Friendly Neighborhood Coffee Shop!");
            Console.WriteLine("1247 Memory Lane Imaginary Mind, DP 48100");
            Console.WriteLine("Phone: 313-555-9912");

        }
        public static decimal SubTotal(Dictionary<Product, int> shoppingCart)
        {
            decimal total = 0;
            foreach (KeyValuePair<Product, int> product in shoppingCart)
            {
                decimal price = product.Key.pPrice;
                total += price * product.Value;
            }
            return total;
        }
        public static decimal GrandTotal(decimal total)
        {
            decimal salesTax = 1.06m;
            decimal grandTotal = total * salesTax;
            grandTotal = decimal.Round(grandTotal, 2, MidpointRounding.AwayFromZero);
            return grandTotal;
        }
        public static decimal Change(Dictionary<Product, int> shoppingCart, decimal amount)
        {
            decimal change = 0;
            decimal total = SubTotal(shoppingCart);
            decimal grandtotal = GrandTotal(total);
            //do change
            change = amount - grandtotal;
            return change;
        }
    }
    class Program
    {
        static List<Product> items = new List<Product>();
        static void Main(string[] args)
        {
            items.Add(new Product("Blonde Roast", "Hot Coffee", "Lightly roasted coffee that's soft, mellow and flavorful.", 3.05m));
            items.Add(new Product("Caffe Misto", "Hot Coffee", "A one-to-one combination of fresh-brewed coffee and steamed milk.", 2.98m));
            items.Add(new Product("Salted Caramel", "Cold Coffee", "Super-smooth cold brew, sweetened with a touch of caramel and topped with a salted, rich cold foam.", 3.45m));
            items.Add(new Product("Honey Almondmilk", "Cold Coffee", "Lightly sweetened with honey and topped off with almondmilk.", 3.98m));
            items.Add(new Product("Mocha Frappucino", "Frappuccino", "Roast coffee, milk and ice.", 2.55m));
            items.Add(new Product("Strawberry Creme Frappuccino", "Frappuccino", "A blend of ice, milk and strawberry puree layered on top of a splash of strawberry puree and finished with vanilla whipped cream.", 3.50m));
            items.Add(new Product("Earl Grey", "Hot Tea", "A citrus fruit with subtle lemon and floral lavender notes.", 1.39m));
            items.Add(new Product("Honey Citrus Mint", "Hot Tea", "Herbal tea, hot water, steamed lemonade and a touch of honey mingle.", 1.45m));
            items.Add(new Product("Guava Black Tea Lemonade", "Cold Tea", "Boldly flavored iced tea made with a combination of our guava-flavored fruit juice blend.", 2.00m));
            items.Add(new Product("Iced Passion Tango Tea", "Iced Tea", "A blend of hibiscus, lemongrass and apple, handshaken with ice.", 2.15m));
            items.Add(new Product("Caramel Apple Spice", "Hot Drinks", "Steamed apple juice complemented with cinnamon syrup, whipped cream and a caramel sauce drizzle.", 2.55m));
            items.Add(new Product("Dragon Drink", "Cold Drinks", "A refreshing combination of sweet mango and dragonfruit.", 2.78m));

            Dictionary<Product, int> shoppingCart = new Dictionary<Product, int>();

            Console.WriteLine("Welcome to your Friendly Neighborhood Coffee Shop!");
            int validUserInput;
            int validQuantity;

            decimal amount;
            string userChoice;

            bool userInput;
            bool quantity;
            do
            {
                Console.WriteLine();
                Menu.DisplayMenu(items);

                Console.Write("\nWhich item would you like to purchase? (1-12): ");
                userInput = Int32.TryParse(Console.ReadLine(), out validUserInput);
                Console.Write("What is the quantity of your purchase? ");
                quantity = Int32.TryParse(Console.ReadLine(), out validQuantity);

                if (userInput && validUserInput > 0 && validUserInput <= items.Count && validQuantity > 0)
                {
                    shoppingCart.Add(items[validUserInput - 1], validQuantity);


                    Console.WriteLine($"You've purchased {validQuantity} {items[validUserInput - 1].pName} at {items[validUserInput - 1].pPrice}.");
                    Console.WriteLine();
                }
                Console.Write("Would you like to order anything else? (y/n): ");
                userChoice = Console.ReadLine().ToLower();
            } while (userChoice == "y");

            Cart.SubTotal(shoppingCart);
            decimal salesTax = 1.06m;
            decimal grandTotal = Cart.SubTotal(shoppingCart) * salesTax;

            //gives sub total and grand total
            Console.WriteLine($"Subtotal: {Cart.SubTotal(shoppingCart)}");
            Console.WriteLine($"That will be {grandTotal} with tax. (CASH ONLY).");

            //Ask the user for amount being tendered
            Console.Write("Enter in the amount you are paying: ");
            amount = Decimal.Parse(Console.ReadLine());
            decimal change = Cart.Change(shoppingCart, amount);

            //displaying receipt with items ordered, subtotal, grand total, amount tendered and change.

            Cart.Reciept();
            foreach (KeyValuePair<Product, int> product in shoppingCart)
            {
                Console.WriteLine(product.Value + " " + product.Key.pName + " " + product.Key.pPrice);
            }
            Console.WriteLine();
            Console.WriteLine($"Subtotal: {Cart.SubTotal(shoppingCart)}");
            Console.WriteLine($"Sales Tax: {salesTax}");
            Console.WriteLine($"Grand Total: {grandTotal:$0.00}");
            Console.WriteLine($"Tendered: {amount}");
            Console.WriteLine($"Change: {change:$0.00}");
        }

    }
}
