using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Order
{
    public class Order
    {
        
        private ILogger Logger { get; }
        private List<OrderDetail> Details { get; } 
        private string Number { get; set; }

        public Order(string number)
        {
            Check.NotNull(number, nameof(number));

            Logger = NullLogger.Instance;
            Details = new List<OrderDetail>();
        }

        public virtual void Add(string description, int quantity, decimal price)
        {
            var orderDetail = OrderDetail.Create(description, quantity, price);

            Details.Add(orderDetail);

            Logger.Write(string.Concat($"Order #{Number} - Add Item: ", orderDetail.ToString()));

        }

        
    }
}
