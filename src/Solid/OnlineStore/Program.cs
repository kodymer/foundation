using System;

namespace OnlineStore
{
    class Program
    {
        static void Main(string[] args)
        {

            var order = new Order("123456");
            Product product = new BookProduct(
                "000001", 
                "50 Sombras de Gray", 
                "Libro para adultos", 
                "823474", "Pedro Moreno");

            order.Add(product.ToString(), 1, 10.60M);

        }
    }
}
