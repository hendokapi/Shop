using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // connesisone al db
            string connectionString = ConfigurationManager.ConnectionStrings["DbShopConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                // recuperare i dati dal database
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                // inizializziamo la variabile htmlContent
                string htmlContent = "";

                if (dataReader.HasRows)
                {
                    // cicliamo sulle righe ottenute dal db a aggiungiamo l'html delle cards
                    while (dataReader.Read())
                    {
                        htmlContent += $@"<div class=""col"">
                            <div class=""card h-100"">
                              <img src=""{dataReader["Image"]}"" class=""card-img-top"" alt=""{dataReader["Name"]}"">
                              <div class=""card-body"">
                                <h5 class=""card-title"">{dataReader["Name"]}</h5>
                                <p class=""card-text"">{dataReader["Description"]}</p>
                                <a href=""Details.aspx?product={dataReader["Id"]}"" class=""btn btn-primary"">Dettagli</a>
                              </div>
                            </div>
                        </div>";
                    }
                }

                // inseriamo in RowCards il contenuto di htmlContent
                RowCards.InnerHtml = htmlContent;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            } finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}