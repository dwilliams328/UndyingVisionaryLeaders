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
            string memberid = "1";
            //string memberid = Request.Form("memberid");
            string queryString = String.Format("SELECT e.HasMedical, e.[Plan code], m.FirstName, m.LastName, m.DOB, m.[RelationshipTo Subscriber], m.[Subscriber Name], e.hplan, e.EligibilityStatus, e.teamcare, e.coverage, e.[PPO Network], e.[Pre-CertificationNumber] FROM Members AS m, Eligibility AS e WHERE e.EligibilityID = m.EligibilityID AND m.id = '{0}'", memberid);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    Response.Write("{\"Records\":[");
                    int x = 0;
                    string HasMedical = "";
                    string Plan_Code = "";
                    string DOB = "";
                    string Relationship_To_Subscriber = "";
                    string Subscriber_Name = "";
                    string hplan = "";
                    string Eligibility_Status = "";
                    string teamcare = "";
                    string coverage = "";
                    string PPO_Network = "";
                    string Pre_Certification_Number = "";
                    string Member_name = "";
                    

                    while (reader.Read())
                    {
                        
                        Member_name = reader[2] + " " + reader[3];
                        HasMedical = reader[0].ToString();
                        Plan_Code = reader[1].ToString();
                        Subscriber_Name = reader[6].ToString();
                        Relationship_To_Subscriber = reader[5].ToString();
                        hplan = reader[7].ToString();
                        Eligibility_Status = reader[8].ToString();
                        teamcare = reader[9].ToString();
                        coverage = reader[10].ToString();
                        PPO_Network = reader[11].ToString();
                        Pre_Certification_Number = reader[12].ToString();
                        DOB = Convert.ToDateTime(reader[4]).ToString("MM/dd/yyyy");
                        Response.Write("{");
                        Response.Write(String.Format("\"Member_name\":\"{0}\"", Member_name));
                        Response.Write(",");
                        Response.Write(String.Format("\"HasMedical\":\"{0}\"", HasMedical));
                        Response.Write(",");
                        Response.Write(String.Format("\"Plan_Code\":\"{0}\"", Plan_Code));
                        Response.Write(",");
                        Response.Write(String.Format("\"DOB\":\"{0}\"", DOB));
                        Response.Write(",");
                        Response.Write(String.Format("\"Subscriber_Name\":\"{0}\"", Subscriber_Name));
                        Response.Write(",");
                        Response.Write(String.Format("\"Relationship_To_Subscriber\":\"{0}\"", Relationship_To_Subscriber));
                        Response.Write(",");
                        Response.Write(String.Format("\"H_Plan\":\"{0}\"", hplan));
                        Response.Write(",");
                        Response.Write(String.Format("\"TeamCare\":\"{0}\"", teamcare));
                        Response.Write(",");
                        Response.Write(String.Format("\"Coverage\":\"{0}\"", coverage));
                        Response.Write(",");
                        Response.Write(String.Format("\"PPO_Network\":\"{0}\"", PPO_Network));
                        Response.Write(",");
                        Response.Write(String.Format("\"Pre_Certification_Number\":\"{0}\"", Pre_Certification_Number));
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



                    