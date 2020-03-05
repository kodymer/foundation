using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    public class Product
    {
        public static Product Book = new Product("000001", "50 Sombras de Gray", "Libro para adultos");
        public static Product Mobile = new Product("000002", "Sansumg Galaxy Note 10+", "Teléfono movil de ultima generación");
        public static Product Mouse = new Product("000003", "50 Sombras de Gray", "Periferico para PC");

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Product(string code, string name, string description)
        {
            Check.NotNull(code, nameof(code));
            Check.NotNull(name, nameof(name));

            Code = code;
            Name = name;
            Description = description;
        }

        public static Product Create(string code, string name, string description)
        {
            return new Product(code, name, description);
        }

        public override string ToString()
        {
            return $"{Code} {Name}";
        }

    }
}
