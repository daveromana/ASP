using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // make sure query stringis provided
        if (Request.QueryString["prodID"] != null)
        {
            // get a specific product based on the query string provided
            // in the URL
            product prod = new product(
                Convert.ToInt64(Request.QueryString["prodID"]),
                Server.MapPath("~/data/products.xml"));

            // populate the controls to display this prduct
            lblName.Text = prod.name;
            imgProduct.Src = prod.imageLocation;
            lblDescription.Text = prod.description;
            lblPrice.Text = string.Format("{0:C}", prod.amount);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ArrayList cart = (ArrayList)Session["Cart"];

        if (cart == null)
            cart = new ArrayList();

        eStore.cartItem ci = new eStore.cartItem();
        ci.quantity = 1;
        ci.product = new product(Convert.ToInt64(Request.QueryString["prodID"]), Server.MapPath("data/products.xml"));

        cart.Add(ci);

        Session["Cart"] = cart;

        lblOutput.Text = String.Format("{0} {1} prints have been added to your cart.", ci.quantity, ci.product.name);


    }
}