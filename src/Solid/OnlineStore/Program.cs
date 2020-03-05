using System;

namespace OnlineStore
{
    class Program
    {
        static void Main(string[] args)
        {


            var order = new Order("123456");

            order.Add(Product.Book.ToString(), 1, 10.60M);

        }
    }
}
