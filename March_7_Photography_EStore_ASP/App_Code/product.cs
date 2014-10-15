using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for product
/// </summary>
public class product
{
    /* members give us somewhere to keep our data
     * in memory
     */
    #region members
    private long _id;
    private string _name;
    private string _description;
    private Single _amount;
    private string _imageLocation;
    #endregion

    /* properties give us a way to access the private
     * data stored in our object 
     * */
    #region properties
    public long id { get { return this._id; } }
    public string name { get { return this._name; } }
    public string description { get { return this._description; } }
    public Single amount { get { return this._amount; } }
    public string imageLocation { get { return this._imageLocation; } }
    #endregion 
    
    /* Constructor
     * used to instantiate our object in memory */
    public product(
        long pId, 
        string pName, 
        string pDescription,
        Single pAmount,
        string pImageLocation
    )
	{
        // set the values of the member variables with what got passed in
        this._id = pId;
        this._name = pName;
        this._description = pDescription;
        this._amount = pAmount;
        this._imageLocation = pImageLocation;
	}

    /* overloaded constructor to get a single product */
    public product(long pId, string pFileLocation)
    {
        // load the xml file
        System.Xml.XmlDocument data = new System.Xml.XmlDocument();
        data.Load(pFileLocation);

        // get the prouct from the loaded XML document (aka data)
        // using xpath
        //  - the double slash (//) indicates to get every product node
        //      from our document. Inside the square bracets limits what
        //      nodes we get back similar to a where clause. The @ indicates 
        //      we are searching the attributes of the product
        System.Xml.XmlNode prod = 
            data.SelectSingleNode("//product[@id = '" + pId + "']");

        // load the variables from the xml node
        _id = Convert.ToInt64(prod.Attributes["id"].Value);
        _name = prod.SelectSingleNode("name").InnerText;
        _description = prod.SelectSingleNode("description").InnerText;
        _amount = Convert.ToSingle(prod.SelectSingleNode("price").InnerText);
        _imageLocation = prod.SelectSingleNode("imageLocation").InnerText;
    }

    /*
     * public - everyone can see it
     * static - I don't need an instance of an object to use this
     * returns - this will return an ArrayList object
     * fileLocation - this will indicate where the datafile is located
     */
    public static System.Collections.ArrayList GetProducts(string pFileLocation)
    {
        // ArrayList and XmlDocument used below are definded
        //  in the .NET Framework

        // create an arraylist called productList and give it a space in memory
        // this will house the data we return to the aspx
        System.Collections.ArrayList productList = new System.Collections.ArrayList();

        // load the xml file
        System.Xml.XmlDocument data = new System.Xml.XmlDocument();
        data.Load(pFileLocation);

        // get all products from the loaded XML document (aka data)
        //  using XPath
        // - the double slash (//) indicates to get every product node 
        //      from our document
        System.Xml.XmlNodeList products = data.SelectNodes("//product");

        // loop through each node and create the object
        foreach (System.Xml.XmlNode prod in products)
        {
            // execute this for each product returned from the xml
            long prodID = Convert.ToInt64(prod.Attributes["id"].Value);
            string prodName = prod.SelectSingleNode("name").InnerText;
            string prodDescription = prod.SelectSingleNode("description").InnerText;
            Single prodAmount = Convert.ToSingle(prod.SelectSingleNode("price").InnerText);
            string prodImgLocation = prod.SelectSingleNode("imageLocation").InnerText;

            // add the product to our return variable with the values from above
            productList.Add(new product(prodID, prodName, prodDescription,
                prodAmount, prodImgLocation));
        }


        // return the list of products
        return productList;

    }
}