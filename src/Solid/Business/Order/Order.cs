using System;
using System.Collections.Generic;
using System.Text;
using Contoso.OnlineStore.Logging;

namespace Contoso.OnlineStore.Business
{
    public class Order
    {
        
        private ILogger Logger { get; }

        private string Number { get; set; }

        private readonly List<OrderDetail> _details;

        public Order(string number)
        {
            Check.NotNull(number, nameof(number));

            Logger = NullLogger.Instance;
            _details = new List<OrderDetail>();
        }

        public virtual void AddDetail(string description, int quantity, decimal price)
        {
            var orderDetail = OrderDetail.Create(description, quantity, price);

            _details.Add(orderDetail);

            Logger.Write(string.Concat($"Order #{Number} - Detail: ", orderDetail.ToString()));

        }        
    }
}
