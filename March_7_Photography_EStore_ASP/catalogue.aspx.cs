using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data;
using System.Text;
using System.IO;
using System.Data.SqlClient;

    public partial class Catalogue : System.Web.UI.Page
    {
        public static string dbConnect = @"integrated security=True;data source=(localdb)\Projects;persist security info=False;initial catalog=Store";
        public static string[] cartInfo = new string[10];
        public static int numItems = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();
            string sqlString = "";

            try
            {
                ds = new DataSet();
                connectFill = new SqlConnection(dbConnect);

                sqlString = "SELECT Description, PictureName, Price FROM Products";
                scmd = new SqlCommand(sqlString, connectFill);

                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = scmd;
                sqlDataAdapter.Fill(ds, "Products");
            }
            catch (Exception ex)
            {
              
            }

            // Generate rows and cells.           
            int numRows = ds.Tables["Products"].Rows.Count;
            int numCells = 6;
            for (int i = 0; i < numRows; i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < numCells; j++)
                {
                    TableCell cell = new TableCell();

                    if (j == 0)
                    {
                        string picName = ds.Tables["Products"].Rows[i]["PictureName"].ToString();
                        System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
                        image.ImageUrl = "images/" + picName;
                        image.Height = 50;
                        //image.Width = 100;
                        cell.Controls.Add(image);
                    }
                    else if (j == 1)
                    {
                        string descrip = ds.Tables["Products"].Rows[i]["Description"].ToString();
                        cell.Controls.Add(new LiteralControl(descrip));
                    }
                    else if (j == 2)
                    {
                        string price = ((decimal)ds.Tables["Products"].Rows[i]["Price"]).ToString();
                        cell.Controls.Add(new LiteralControl(price));
                    }
                  
                    row.Cells.Add(cell);
                }
                catalogTable.Rows.Add(row);
            }
                      
        }

    }



   
