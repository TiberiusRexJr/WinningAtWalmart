using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace McDonalds.Models
{
    public class Order
    {
        #region Properties
        public Guid OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public Guid CustomerId { get; set; }
        #endregion
        #region Constructor
        public Order()
        { 
        }
        #endregion
    }
}
