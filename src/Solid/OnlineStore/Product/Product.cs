using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    public abstract class Product
    { 
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

        public abstract Product Create(string code, string name, string description);

        public override string ToString()
        {
            return $"{Code} {Name}";
        }

    }
}
