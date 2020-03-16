using System;
using Contoso.OnlineStore.Business;

namespace Contoso.OnlineStore
{
    class Program
    {
        static void Main(string[] args)
        {


            var product = ProductFactory.CreateBook(
                "000001", 
                "50 Sombras de Gray", 
                "Libro para adultos", 
                "823474", "Pedro Moreno");

            var order = new Order("123456");
            order.AddDetail(product.ToString(), 1, 10.60M);

        }
    }
}
