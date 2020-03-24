using System;
using System.Collections.Generic;
using System.Text;
using Contoso.OnlineStore.Logging;

namespace Contoso.OnlineStore.Business
{
    public class Order
    {
        
        private ILogger _logger { get; }
        private readonly List<OrderDetail> _details;

        public string Number { get; set; }

        public Order(string number)
        {
            Check.NotNull(number, nameof(number));

            _logger = NullLogger.Instance;
            _details = new List<OrderDetail>();
        }

        public virtual void AddDetail(string description, int quantity, decimal price)
        {
            var orderDetail = OrderDetail.Create(description, quantity, price);

            _details.Add(orderDetail);

            _logger.Write(string.Concat($"Order #{Number} - Detail: ", orderDetail.ToString()));

        }
    }
}
