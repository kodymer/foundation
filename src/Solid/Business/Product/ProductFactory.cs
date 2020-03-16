using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.OnlineStore.Business
{
    public class ProductFactory
    {

        public static Product CreateBook(string code, string name, string description, string isbn, string author)
        {
            return new BookProduct(code, name, description, isbn, author);
        }

        public static Product CreateDefault(string code, string name, string description)
        {
            return new Product(code, name, description);
        }
    }
}
