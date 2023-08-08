using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.OnlineStore.Business.Catalog
{
    public class CatalogItem
    {

        public int Id { get; set; }
        public int CatalogId { get; set; }
        public int ProductId { get; set; }

        public CatalogItem(int catalogId, int productId)
        {
            CatalogId = catalogId;
            ProductId = productId;
        }
    }
}
