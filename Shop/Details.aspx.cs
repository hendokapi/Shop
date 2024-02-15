using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
    public partial class Details : System.Web.UI.Page
    {
        private string ProductId;

        protected void Page_Load(object sender, EventArgs e)
        {
            // recuperare l'id del prodotto dalla query string
            if (Request.QueryString["product"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            ProductId = Request.QueryString["product"].ToString();

            BtnAnchorEdit.HRef = "Edit.aspx?product=" + ProductId;

            try
            {
                Db.conn.Open();
                SqlCommand cmd = new SqlCommand($@"
                    SELECT Products.*, Categories.Name AS CategoryName
                    FROM Products
                    JOIN Categories ON Products.CategoryId = Categories.Id
                    WHERE Products.Id={ProductId}", Db.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                // recuperare i dati relativi al prodotto dal db

                if (dataReader.HasRows) {
                    // popolare l'interfaccia con i dati
                    dataReader.Read();
                    TtlName.InnerText = dataReader["Name"].ToString();
                    LblCategory.InnerText = dataReader["CategoryName"].ToString();
                    ImgProduct.Src = dataReader["Image"].ToString();
                    ParContent.InnerHtml = dataReader["Description"].ToString();
                } else
                {
                    Response.Redirect("NotFound.aspx"); // cambia l'indirizzo
                    // Server.Transfer("NotFound.aspx"); // non cambia l'indirizzo, da vedere il warning
                }
            } catch (Exception ex)
            {
                Response.Write(ex.ToString());
            } finally { Db.conn.Close(); }
            
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx?product=" + ProductId);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            // eliminare la riga dal database
            try
            {
                Db.conn.Open();
                SqlCommand cmd = new SqlCommand($@"DELETE FROM Products WHERE Products.Id={ProductId}", Db.conn);
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows != 0)
                {
                    // ridirezionare alla Indexv
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Response.Write("Eliminazione non riuscita");
                }
            } catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}