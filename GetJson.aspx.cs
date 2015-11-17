using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace David
{
    public partial class GetJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["David2"].ConnectionString;
            string queryString = "SELECT dbo.Benefits.[First Name], dbo.Benefits.[Last Name] FROM dbo.Benefits WHERE ID=2";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    Response.Write("{\"Records\":[");
                    int x = 0;
                    string Patient_name = "";
                    
                    while (reader.Read())
                    {
                        Patient_name = reader[0] + " " + reader[1];
                        
                        Response.Write("{");
                        Response.Write(String.Format("\"first_name\":\"{0}\"", Patient_name));
                        
                        Response.Write("}");
                        Response.Write("]");
                        Response.Write("}");
                        x = x + 1;
                    }
                }
                //format should look like this: ]}
                // Response.Write(String.Format("{0} {1}", "]", "}")); 
            
                  finally
            {
                // Always call Close when done reading. 
                reader.Close();
            }
        }
      }
    }
 }



                    