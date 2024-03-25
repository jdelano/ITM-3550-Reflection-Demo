using System;
namespace ReflectionDemoPrep2024
{
    public class Customer
    {
        private int balance;
        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        public int Id { get; set; }

        public void PlaceOrder()
        {
            Console.WriteLine("Order Placed.");
            Balance -= 100;
        }

        public void PlaceOrderFor(int amount)
        {
            Balance -= amount;
        }
    }
}

