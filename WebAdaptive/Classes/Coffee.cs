using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdaptive.Classes
{
    internal class Coffee
    {
        private int id;
        public string name;
        internal bool isDecaf;
        protected double price;
        protected internal char size;

        public Coffee(int id, string name, bool isDecaf, double price, char size)
        {
            this.id = id;
            this.name = name;
            this.isDecaf = isDecaf;
            this.price = price;
            this.size = size;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public double BuyCoffee(int quantity)
        {
            double totalPrice = price * quantity;
            Console.WriteLine($"You bought {quantity} {name}(s) for ${totalPrice}");
            return totalPrice;
        }

        public void ShowFullInfo()
        {
            string decafMessage = isDecaf ? "decaffeinated" : "not decaffeinated";
            Console.WriteLine($"Your coffee is {name}, price is {price}. It's {decafMessage} and size is {size}");
        }
    }

}
