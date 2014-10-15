using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace eStore
{
    /// <summary>
    /// Summary description for cartItem
    /// </summary>
    public class cartItem
    {
        // members
        private product _prod;
        private int _quantity;

        // properties
        public product product { get { return _prod; } set { _prod = value; } }
        public int quantity { get { return _quantity; } set { _quantity = value; } }
        public Single total { get { return _quantity * _prod.amount; } }

        public cartItem()
        {
        }
    }
}