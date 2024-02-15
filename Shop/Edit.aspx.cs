using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
    public partial class Edit : System.Web.UI.Page
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

            // Popolare la dropdown con tutte le categorie
            Db.conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Categories", Db.conn);
            DataTable tbCategories = new DataTable();
            dataAdapter.Fill(tbCategories);

            foreach (DataRow row in tbCategories.Rows)
            {
                ListItem listItem = new ListItem();
                listItem.Text = row["Name"].ToString();
                listItem.Value = row["Id"].ToString();
                DrpCategories.Items.Add(listItem);
            }

            // Popolare i campi del form con i dati relativi al prodotto in base all'id
            // nella query string
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Products WHERE Id={ProductId}", Db.conn);
            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                TxtName.Text = dataReader["Name"].ToString();
                TxtImage.Text = dataReader["Image"].ToString();
                TxtDescription.Text = dataReader["Description"].ToString();
                DrpCategories.SelectedValue = dataReader["CategoryId"].ToString();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            // eseguire la query update sulla riga con Id=ProductId

            // ridirezionare nella pagina di dettaglio
        }
    }
}