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

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Session.Abandon();

        Response.Cookies["labs"]["user"] = "";
        Response.Cookies["labs"]["type"] = "";
        Response.Cookies["labs"]["typepower"] = Encrypt(Convert.ToInt16(0));
        Response.Cookies["labs"].Domain = "colostate.edu";
        Response.Cookies["labs"].Expires = DateTime.Now.AddDays(-1);
        

        
        
    }

    public static string Encrypt(int id)
    {
        byte[] sourceConverted;
        System.Text.ASCIIEncoding sourceEncoder = new System.Text.ASCIIEncoding();

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
}
