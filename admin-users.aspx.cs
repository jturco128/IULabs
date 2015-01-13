using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Auth.AuthorizeByType("Contributor");
    }

    public string GetUsers(string eName)
    {
        SqlParameter[] p = new SqlParameter[1] {new SqlParameter("ename", eName)};
        DataRowCollection StudentInfo = SQLstar.GetRecordset_P("StudentInfo", "SELECT * FROM CSUG_DIRECTORY_ALL_LOCAL WHERE ENAME = @ename", p);
        if(StudentInfo != null)
            return StudentInfo[0]["FIRST_NAME"] + " " + StudentInfo[0]["LAST_NAME"];
        return "";
    }

    protected void GridView2_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        string ename = e.CommandArgument.ToString();

        SqlParameter[] p = new SqlParameter[1];
        p[0] = new SqlParameter("@ename", ename);

        DataRowCollection CheckExist = SQLstar.GetRecordset_P("Lab", "SELECT * FROM LabUsers WHERE ename = @ename", p);

        if (CheckExist == null)
        {
            SqlParameter[] p2 = new SqlParameter[2];
            p2[0] = new SqlParameter("@ename", ename);
            p2[1] = new SqlParameter("@type_id", 3);
            SQLstar.Execute_P("Lab", "INSERT INTO LabUsers (ename, type_id) VALUES ( @ename, @type_id)", p2);
            
            Response.Redirect("admin-users.aspx");
        }
        else
        {
            Literal1.Text = "User Already Exists.";
        }
    }

    protected void TextBox1_OnTextChanged(object sender, EventArgs e)
    {
        GridView2.DataSource = GetPeople(TextBox1.Text);
        GridView2.DataBind();
    }

    public static DataTable GetPeople(string prefixText)
    {
        string[] names = null;
        string firstname = "";
        string lastname = "";
        char delim = ' ';
        DataTable dt = new DataTable();
        if (prefixText.Contains(","))
        {
            try
            {
                // COMMA! If there is a comma, do a LAST, FIRST (or nickname) and do *NOT* do anything else					
                delim = ',';
                names = prefixText.Split(delim);

                firstname = names[1].Trim();
                lastname = names[0].Trim();

                if (lastname.Length > 0) // this disallows cheating: [, warren ] searches for example
                {
                    SqlParameter fname = new SqlParameter("@fname", firstname + "%");
                    SqlParameter lname = new SqlParameter("@lname", lastname + "%");
                    dt = new DataTable();
                    string sql = null;
                    if (string.IsNullOrEmpty(prefixText))
                        sql = "SELECT * FROM CSUG_DIRECTORY_ALL_LOCAL WHERE CSU_ID IS NULL";
                    else
                        sql = "SELECT TOP 100 * from CSUG_DIRECTORY_ALL_LOCAL WHERE ((FIRST_NAME LIKE @fname) OR (PREFERRED_FIRST_NAME LIKE @fname)) AND (LAST_NAME LIKE @lname) AND (ACCOUNT_TYPE = 'P') ORDER BY LAST_NAME, FIRST_NAME";
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StudentInfo"].ConnectionString);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(fname);
                    cmd.Parameters.Add(lname);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            catch { }
        }
        else
        {
            // NO COMMAS, so check for spaces	
            if (prefixText.Contains(" "))
            {
                try
                {
                    // SPACES! Do FIRST_NAME or PREFERRED_FIRST_NAME on the first word, LAST_NAME on the last word
                    delim = ' ';
                    names = prefixText.Split(delim);
                    firstname = names[0].Trim();
                    lastname = names[1].Trim();

                    SqlParameter fname = new SqlParameter("@fname", firstname + "%");
                    SqlParameter lname = new SqlParameter("@lname", lastname + "%");
                    dt = new DataTable();
                    string sql = null;
                    if (string.IsNullOrEmpty(prefixText))
                        sql = "SELECT * FROM CSUG_DIRECTORY_ALL_LOCAL WHERE CSU_ID IS NULL";
                    else
                        sql = "SELECT TOP 100 * from CSUG_DIRECTORY_ALL_LOCAL WHERE (((FIRST_NAME LIKE @fname) OR (PREFERRED_FIRST_NAME LIKE @fname)) AND (LAST_NAME LIKE @lname)) AND (ACCOUNT_TYPE = 'P') ORDER BY LAST_NAME, FIRST_NAME";
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StudentInfo"].ConnectionString);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(fname);
                    cmd.Parameters.Add(lname);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
                catch { }
            }
            // NO COMMAS *AND* NO SPACES
            else
            {
                try
                {
                    // do last name only, with tailing wildcard

                    SqlParameter lname = new SqlParameter("@lname", prefixText + "%");
                    dt = new DataTable();
                    string sql = null;
                    if (string.IsNullOrEmpty(prefixText))
                        sql = "SELECT * FROM CSUG_DIRECTORY_ALL_LOCAL WHERE CSU_ID IS NULL";
                    else
                        sql = "SELECT TOP 150 * FROM CSUG_DIRECTORY_ALL_LOCAL WHERE (LAST_NAME LIKE @lname) AND (ACCOUNT_TYPE = 'P') ORDER BY LAST_NAME, FIRST_NAME";
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["StudentInfo"].ConnectionString);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(lname);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Email.SimpleSend("Error", ex.ToString(), "michael.brake@colostate.edu", "michael.brake@colostate.edu"); 
                }
            }
        }

        return dt;
    }
}
