using System;
using Xunit;
using POS_Terminal;
using System.Collections.Generic;

namespace POS_Testing
{
    public class UnitTest1
    {
        [Fact]
        public void TestSubTotal()
        {
            Dictionary<Product, int> shoppingCart = new Dictionary<Product, int>();
            shoppingCart.Add(new Product("Blonde Roast", "Hot Coffee", "Lightly roasted coffee that's soft, mellow and flavorful.", 3.05m), 3);
            shoppingCart.Add(new Product("Mocha Frappucino", "Frappuccino", "Roast coffee, milk and ice.", 2.55m), 2);

            decimal result = Cart.SubTotal(shoppingCart);
            Assert.Equal(14.25m, result);
        }
        [Fact]
        public void TestGrandTotal()
        {
            Product prod = new Product("Misto Coffee", "Iced Coffee", "Rich and smooth", 1.75m);
            decimal result = Cart.GrandTotal(1.75m);
            Assert.Equal(1.86m, result);
        }
        [Fact]
        public void TestChange()
        {
            Dictionary<Product, int> shoppingCart = new Dictionary<Product, int>();
            shoppingCart.Add(new Product("Blonde Roast", "Hot Coffee", "Lightly roasted coffee that's soft, mellow and flavorful.", 3.05m), 3);
            shoppingCart.Add(new Product("Mocha Frappucino", "Frappuccino", "Roast coffee, milk and ice.", 2.55m), 2);
            decimal amount = 15.50m;
            decimal change = Cart.Change(shoppingCart, amount);
            Assert.Equal(0.39m, change);
        }
    }
}
