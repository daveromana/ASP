using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Xml;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /* Step 1 - Get the cart */
        // ArrayList cart = (ArrayList)Session["Cart"];
        eStore.cart myCart = new eStore.cart();

        /* Step 2 - make sure it is actually a cart */
        /* handled by the cart constructor
         * if (cart == null)
            cart = new ArrayList();
         * */

        /* Step 3 - tell out cart display object (aka gvCart) what items are in our cart */
        //gvCart.DataSource = myCart.cartItems;

        /* Step 4 - bind the items to the cart (aka make them display) */
        //gvCart.DataBind();
        myCart.BindToGrid(ref gvCart);
    }

    protected void gvCart_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /* Only process when we are working with a datarow. 
                * This will make he header row ignored */
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the data for this row and cast it to a product
            eStore.cartItem ci = (eStore.cartItem)e.Row.DataItem;

            // format the currency
            e.Row.Cells[2].Text = string.Format("{0:C}", ci.product.amount);
            e.Row.Cells[3].Text = string.Format("{0:C}", ci.total);


        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            eStore.cart cart = new eStore.cart();

            Label lblSubTotal = (Label)e.Row.FindControl("lblSubTotal");
            Label lblTaxl = (Label)e.Row.FindControl("lblTax");
            Label lblTotal = (Label)e.Row.FindControl("lblTotal");

            lblSubTotal.Text = string.Format("{0:C}", cart.subTotal);
            lblTaxl.Text = string.Format("{0:C}", cart.tax);
            lblTotal.Text = string.Format("{0:C}", cart.total);
        }


    }
    protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        /* Get the cart */
        /*ArrayList cart = (ArrayList)Session["Crat"];*/
        eStore.cart myCart = new eStore.cart();

        // get the current item to use it later
        eStore.cartItem currentItem = myCart.GetCartItem(e.RowIndex);

        /* make sure the cart exists in memory */
        //if (cart == null)
        //    cart = new ArrayList();

        /* check that the current index is available to be removed */
        //if (cart[e.RowIndex] != null)
        //    cart.RemoveAt(e.RowIndex);
        myCart.Remove(e.RowIndex);

        /* refresh the gridview so that it shows the changes */
        //gvCart.DataSource = myCart.cartItems;
        //gvCart.DataBind();
        myCart.BindToGrid(ref gvCart);

        /* save the cart */
        //Session["Crat"] = cart;
        myCart.Save();

        /* indicate success */
        lblOutput.Text = String.Format("The item {0} has been removed.", currentItem.product.name);

    }
    protected void btnBuyNow_Click(object sender, EventArgs e)
    {
        // find the number of items in the cart
        eStore.cart cart = new eStore.cart();
        if (cart.itemCount > 0)
        {
            /* there are items, show the checkout */
            pnlCheckout.Visible = true;
            
           
            Page.Validate();
        }
        else /* no items, checkout not available */
            lblOutput.Text = "There are no items in your cart.";
    }
        
    
    protected void btnCheckout_Click(object sender, EventArgs e)
       
    {
        
        if(Page.IsValid)
        {
            XmlDocument orders = new XmlDocument();
            orders.Load(Server.MapPath("~/data/orders.xml"));

            /* create a new order node */
            XmlNode order = orders.CreateNode(XmlNodeType.Element, "order", "");


 /* build the order content */
        order.InnerXml += string.Format("<orderSubmitted>{0}</orderSubmitted>", DateTime.Now);
       order.InnerXml += string.Format("<name>{0}</name>", txtName.Text);
        order.InnerXml += string.Format("<address>{0}</address>", txtAddress.Text);
        order.InnerXml += string.Format("<email>{0}</email>", txtEmail.Text);
        
        /* add the cart to the xml */
        eStore.cart cart = new eStore.cart();
         order.InnerXml += cart.xml;

        /* add the order to our xml document */
        orders.DocumentElement.AppendChild(order);

        /* save the document */
        orders.Save(Server.MapPath("~/data/orders.xml"));

        /* indicate we have the order */
        lblOutput.Text = "Thank you for your order.";

        /* clear the form */
        }
    }

}