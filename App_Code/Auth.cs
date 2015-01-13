using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Auth
/// </summary>
public class Auth
{
	public Auth()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void AuthorizeByType(string type)
    {
        // the idea here is to see if someone's authorized at this type level or higher
        // if they are, do nothing
        // if they are not, send them to log in.

        int userPower = 0;
        string userType = "";
        int requestedPower = 1000;

        if (HttpContext.Current.Request.Cookies["labs"] != null)
        {
            if ((HttpContext.Current.Request.Cookies["labs"]["type"] != null) && (HttpContext.Current.Request.Cookies["labs"]["type"] != null))
            {
                // get the requested type power from the database 
                DataRowCollection minPower = SQLstar.GetRecordset("Lab", "SELECT type_power FROM LabUserType WHERE type = '" + type + "';");

                if (minPower != null)
                {
                    requestedPower = Convert.ToInt16(minPower[0]["type_power"]);
                }

                // get the user's type power out of their cookie
                userPower = AWHash.Decrypt(HttpContext.Current.Request.Cookies["labs"]["typepower"]);

                // the person is authorized if their type power is >= the requested type power
                // so if they are <, send them to log in
                if (userPower < requestedPower)
                {
                    HttpContext.Current.Response.Redirect("https://secure.casa.colostate.edu/iulabs/login.aspx", true);
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("https://secure.casa.colostate.edu/iulabs/login.aspx", true);
            }
        }
        else
        {
            HttpContext.Current.Response.Redirect("https://secure.casa.colostate.edu/iulabs/login.aspx", true);
        }
    }

    public static void RequireLogin(string destination)
    {
        // the idea here is to see if someone's logged in with an eID
        // if they are, do nothing
        // if they are not, send them to log in.

        string ename = "";

        if (HttpContext.Current.Request.Cookies["labGeneral"] != null)
        {
            if ((HttpContext.Current.Request.Cookies["labGeneral"]["ename"] != null) && (HttpContext.Current.Request.Cookies["labGeneral"]["ename"] != null))
            {
                // get the user's ename out of their cookie
                ename = AWHash.DecryptString(HttpContext.Current.Request.Cookies["labGeneral"]["ename"]);
            }
        }

        if (ename.Length > 0)
        {
            // send them where they wanted to go. don't worry about destination
            //System.Web.HttpContext.Current.Response.Redirect(destination, true);
        }
        else
        {
            // send them to login but first set a destination cookie


            HttpContext.Current.Response.Cookies["labRequest"]["kind"] = "user";
            HttpContext.Current.Response.Cookies["labRequest"]["request"] = destination;
            HttpContext.Current.Response.Cookies["labRequest"].Domain = "colostate.edu";

            HttpContext.Current.Response.Redirect("https://secure.casa.colostate.edu/iulabs/login.aspx", true);
        }

    }

    public static bool IsUserLoggedIn()
    {
        // the idea here is to see if someone's logged in with an eID


        string ename = "";

        if (HttpContext.Current.Request.Cookies["labs"] != null)
        {
            if ((HttpContext.Current.Request.Cookies["labs"]["user"] != null) && (HttpContext.Current.Request.Cookies["labs"]["user"] != null))
            {
                // get the user's ename out of their cookie
                ename = AWHash.DecryptString(HttpContext.Current.Request.Cookies["labs"]["user"]);
            }
        }

        if (ename.Length > 0)
        {
            // send them where they wanted to go. don't worry about destination
            //System.Web.HttpContext.Current.Response.Redirect(destination, true);
            return true;
        }
        return false;
    }

    public static string GetCurrentUser()
    {
        string ename = "";

        if (HttpContext.Current.Request.Cookies["labs"] != null)
        {
            if ((HttpContext.Current.Request.Cookies["labs"]["user"] != null) && (HttpContext.Current.Request.Cookies["labs"]["user"] != null))
            {
                // get the user's ename out of their cookie
                ename = AWHash.DecryptString(HttpContext.Current.Request.Cookies["labs"]["user"]);
            }
        }
        else if (HttpContext.Current.Request.Cookies["labGeneral"] != null)
        {
            if (HttpContext.Current.Request.Cookies["labGeneral"]["ename"] != null)
            {
                ename = AWHash.DecryptString(HttpContext.Current.Request.Cookies["labGeneral"]["ename"]);
            }
        }

        return ename;

    }

    public static string GetUserType()
    {
        string type = "";

        if (HttpContext.Current.Request.Cookies["labs"] != null)
        {
            if ((HttpContext.Current.Request.Cookies["labs"]["type"] != null) && (HttpContext.Current.Request.Cookies["labs"]["type"] != null))
            {
                // get the user's ename out of their cookie
                type = AWHash.DecryptString(HttpContext.Current.Request.Cookies["labs"]["type"]);
            }
        }

        return type;
    }

    public static string GetUserById(int id)
    {
        string User = "";

        SqlParameter[] p = new SqlParameter[1] { new SqlParameter("id", id) };

        DataRowCollection RS = SQLstar.GetRecordset_P("Lab", "SELECT ename FROM LabUsers WHERE user_id = @id", p);
        SqlParameter[] p2 = new SqlParameter[1] {new SqlParameter("ename", RS[0][0])};
        DataRowCollection StudentInfo = SQLstar.GetRecordset_P("StudentInfo", "SELECT * FROM CSUG_DIRECTORY_ALL_LOCAL WHERE ENAME = @ename", p2);

        if (StudentInfo != null)
            User = StudentInfo[0]["FIRST_NAME"] + " " + StudentInfo[0]["LAST_NAME"];

        return User;

    }

    public static string GetEnameById(int id)
    {
        string User = "";

        SqlParameter[] p = new SqlParameter[1] { new SqlParameter("id", id) };

        DataRowCollection RS = SQLstar.GetRecordset_P("Lab", "SELECT ename FROM LabUsers WHERE user_id = @id", p);

        if(RS != null)
            User = RS[0][0].ToString();

        return User;
    }
}
