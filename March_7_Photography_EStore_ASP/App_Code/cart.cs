using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace eStore
{
    /// <summary>
    /// Summary description for cart
    /// </summary>
    public class cart
    {
        /* create a spot in our object's memory to store the cart items */
        private ArrayList _cartItems;

        /* properties to expose state */
        public bool IsInstantiated { get { return (_cartItems != null); } }
        /* expose the member variable (_cartItems) so it is accessible outside of our object */
        public ArrayList cartItems { get { return this._cartItems; } }

        public Single subTotal
        {
            get
            {
                Single runningTotal = 0;
                foreach (eStore.cartItem ci in this._cartItems)
                {
                   runningTotal += ci.total; 
                }
                return runningTotal;
              
            }
        }
        public Single tax { get { return this.subTotal * (Single)0.13; } }
        public Single total { get { return this.subTotal + this.tax; } }
        public int itemCount { get { return this._cartItems.Count; } }

        /* get an xml version of the cart */
        public string xml
        {
            get
            {
                String xml = "";
                /* create an instance of each item in _cartItems and store it for use in ci */
                foreach (eStore.cartItem ci in this._cartItems)
                {
                    /* build each item node based on the items in our cart */
                    xml += "<item>";
                    xml += string.Format("<quantity>{0}</quantity>", ci.quantity.ToString());
                    xml += string.Format("<productName>{0}</productName>", ci.product.name);
                    xml += "</item>";
                }
                /* wrap all items in a container node. **** node this is not incremental aka = not += **** */
                xml = string.Format("<orderItems>{0}</orderItems>", xml);
                /* add the total */
                xml += string.Format("<grandTotal>{0}</grandTotal>", this.total);
                return xml;
            }
        }


        /* create the cart in memory */
        public cart()
        {
            /* get the cart from the current http session */
            _cartItems = (ArrayList)System.Web.HttpContext.Current.Session["Cart"];

            /* if the cart has never been created in the session instantiate it */
            if (this.IsInstantiated == false)
                _cartItems = new ArrayList();
        }

        /* behaviours of our cart object */
        public void Add(cartItem pCartItem)
        {
            _cartItems.Add(pCartItem);
        }
        public void Remove(int pIndex)
        {
            /* if there is an item at the index provided in the pIndex parameter..*/
            if (_cartItems[pIndex] != null)
                /* remove it */
                _cartItems.RemoveAt(pIndex);
        }
        public void Save()
        {
            // save the cart items to the session
            System.Web.HttpContext.Current.Session["Cart"] = _cartItems;
        }

        /* pass a grid in by reference so that we can bind to it.
         * by reference means the actual object. by default parameters are 
         * passed by values which means a copy is made. performing the behaviour 
         * on a copy will not affect the original object whereas by reference will
         */
        public void BindToGrid(ref System.Web.UI.WebControls.GridView grid)
        {
            grid.DataSource = this._cartItems;
            grid.DataBind();
        }

        // get the cart item at the index provided
        public cartItem GetCartItem(int pIndex)
        {
            if (this._cartItems[pIndex] != null)
                return (cartItem)this._cartItems[pIndex];
            else
                throw new Exception("Cannot find that item.");
        }
    }
}