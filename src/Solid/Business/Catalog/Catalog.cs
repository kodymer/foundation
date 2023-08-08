using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.OnlineStore.Business.Catalog
{
    public class Catalog
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private readonly List<CatalogItem> _items;

        public Catalog()
        {
            _items = new List<CatalogItem>();
        }

        public Catalog(string name) 
            : this()
        {
            Name = name;
        }


    }
}
