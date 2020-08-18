using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace McDonalds.Models
{
    public class Customer
    {
        #region Properties
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public DateTime OrderDate { get; set; }

        public Order[] Orders { get; set; }
        #endregion


        #region Constructor
        public Customer()
        { 
        
        }
        #endregion
    }
}
