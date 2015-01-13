using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;

public class WebAuthProcess : System.Web.UI.Page
{
    protected System.Web.UI.WebControls.Label output;
    protected string html;
    DataRowCollection AuthCheck;
    string trackIP = "";

    private void Page_Load(object sender, System.EventArgs e)
    {
        //Only process the authentication once, if second time, send back to login
        if ((string)Session["ProcessedAuth"] != "No")
        {
            Response.Redirect("https://secure.colostate.edu/iulabs/login.aspx");
        }
        else
        {
            Session["ProcessedAuth"] = "Yes";

            string url = "https://eid.colostate.edu/eIDWebAuth/AuthenticateResultsV3.aspx?";

            url = url + "Token=" + Request.Form["Token"];

            url = url + "&AuthenticationID=" + Request.Form["AuthenticationID"];

            HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse HttpWRes = (HttpWebResponse)HttpWReq.GetResponse();
            Stream responseStream = HttpWRes.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            String data = reader.ReadToEnd().Trim();

            string[] results = data.Split(':');

            string Junk = results[0];
            string Token = results[1].Trim();
            string ValidUser = results[2].Trim();
            string LoginType = results[3].Trim();
            string eName = results[4].Trim();
            string PrimaryEID = results[5].Trim();
            string EIDIRID = results[6].Trim();
            string ISISIRID = results[7].Trim();
            string ARIESIRID = results[8].Trim();   // new with 3
            string HRIRID = results[9].Trim();
            string AssociatesIRID = results[10].Trim();
            string CSUID = results[11].Trim();      // new with 3
            string Error = results[12].Trim();
            string ErrorType = results[13].Trim();
            string ErrorDetail = results[14].Trim();
            string Junk2 = results[15];

            //Verify response came from eID
            if ((string)Session["AuthenticationToken"] != Token)
            {
                html = "<p>The authentication attempt is invalid.</p><p><a href=\"https://secure.casa.colostate.edu/iulabs/login.aspx\">Try again</a></p>";
            }
            //Check if there were any errors and display if neccessary
            else if (Error != "No")
            {
                html = "<p>The following error was detected:</p>";
                html += "<blockquote><p>Error Type: " + ErrorType + "<br />";
                html += "Error Detail: " + ErrorDetail + "</p></blockquote>";
                html += "<p><a href=\"https://secure.casa.colostate.edu/iulabs/login.aspx\">Try again</a></p>";
            }
            //Check if valid user
            else if (ValidUser != "Yes")
            {
                html = "<p>The authentication attempt is invalid.</p>";
                html += "<p><a href=\"https://secure.casa.colostate.edu/iulabs/login.aspx\">Try again</a></p>";
            }
            //Finally, display successful page
            else if (ValidUser == "Yes")
            {

                ///////////////////////
                // now we have to make a choice. 
                // let's consider the "default" behavior of this form to be for admins.
                // check for exceptional behavior - for people

                // if a person has been asked to login, they'll have a request cookie of kind "user"
                string destination = "";

                if (Request.Cookies["labRequest"] != null)
                {
                    if (Request.Cookies["labRequest"]["request"] != null)
                    {
                        // get the user's ename out of their cookie
                        destination = Request.Cookies["labRequest"]["request"];

                        // get their ename out of webauth and put that into a todayGeneral cookie
                        Response.Cookies["labGeneral"]["ename"] = EncryptString(eName);
                        Response.Cookies["labGeneral"].Domain = "colostate.edu";

                        // now if they have a real destination, send them where they want to go. Otherwise just send them to the today index
                        // but first clear the todayRequest cookie
                        Response.Cookies["labsRequest"].Expires = DateTime.Now.AddDays(-1);

                        if (destination.Length > 0)
                        {
                            Response.Redirect("http://iulabs.casa.colostate.edu/" + destination, true);
                        }
                        else
                        {
                            Response.Redirect("http://iulabs.casa.colostate.edu", true);
                        }
                    }
                }

                // if still here, now check to see if they're needing admin.


                AuthCheck = GetRecordset("Lab", "SELECT LabUsers.ename, LabUserType.type, LabUserType.type_power FROM LabUsers, LabUserType WHERE LabUsers.ename = '" + eName + "' AND LabUsers.type_id = LabUserType.type_id;");

                // all this does is set a cookie if they're in the table		
                ////////////////////////////////////////////////////////////////////////////////////////////////
                ///////// note 																				  //
                ///////// this page is firing on https://wsprod/blah. 										  //
                ///////// because of this, session won't work once the user goes to www.today.colostate.edu   //
                ///////// since the server will think it's a different "site" and won't play                  //
                ///////// so never use session                                                                //
                ////////////////////////////////////////////////////////////////////////////////////////////////
                if (AuthCheck != null)
                {
                    Response.Write("AuthCheck ! null");
                    Response.Cookies["labs"]["user"] = EncryptString(eName);
                    Response.Cookies["labs"]["type"] = EncryptString(AuthCheck[0]["type"].ToString());
                    Response.Cookies["labs"]["typepower"] = Encrypt(Convert.ToInt16(AuthCheck[0]["type_power"]));
                    Response.Cookies["labs"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["labs"].Domain = "colostate.edu";

                    //TODO: add log event
                    //Log.AddEvent("sqlprod_37", "NewsInfoTrackLog", "User Logged In", eName, HelperFunctions.getIP());

                    Response.Redirect("http://iulabs.casa.colostate.edu/Admin.aspx", true);
                }
                else
                {
                    html += "<p>Your eID is valid but you do not have permission to use this resource.</p>";
                }
            }
            // set text property of label in webauth_proc.aspx to "html" variable content
            output.Text = html;
        } // if processedauth neq no
    } //Page_Load

    public static string EncryptString(string id)
    {
        byte[] sourceConverted;
        ASCIIEncoding sourceEncoder = new ASCIIEncoding();

        try
        {
            sourceConverted = sourceEncoder.GetBytes(id);
            return Convert.ToBase64String(sourceConverted, 0, sourceConverted.Length);
        }
        catch
        {
            return "error";
        }
    }

    public static string Encrypt(int id)
    {
        byte[] sourceConverted;
        ASCIIEncoding sourceEncoder = new ASCIIEncoding();

        try
        {
            sourceConverted = sourceEncoder.GetBytes((id + 731415926).ToString());
            return Convert.ToBase64String(sourceConverted, 0, sourceConverted.Length);
        }
        catch
        {
            return "error";
        }
    }

    private static SqlConnection GetConnection(string connection_to_use)
    {
        // this opens a connection based on the passed connection string to use instead of assuming one.
        // connection_to_use better exist in web.config or else.
        SqlConnection DB_connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connection_to_use].ConnectionString);
        try
        {
            DB_connection.Open();
        }
        catch (Exception the_exception)
        {
            //Email.SendException(the_exception, "ERROR: (search) SQLstar.GetConnection(" + connection_to_use + ") failure in search");
            return null;
        }
        return DB_connection;
    }

    public static DataRowCollection GetRecordset(string connection_to_use, string sql_statement)
    {
        SqlConnection DB_connection = GetConnection(connection_to_use);
        if (DB_connection != null)
        {
            SqlCommand DB_command = new SqlCommand(sql_statement, DB_connection);
            SqlDataAdapter DB_adapter = new SqlDataAdapter(DB_command);
            DataTable DB_data_table = new DataTable();
            DB_adapter.Fill(DB_data_table);
            DB_connection.Close();
            if (DB_data_table.Rows.Count != 0)
            {
                return DB_data_table.Rows;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}  // class WebAuthProcess
