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

public partial class CreditsCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Auth.RequireLogin("CreditsCheck.aspx");
        string eName = Auth.GetCurrentUser();
        SqlParameter[] p = new SqlParameter[1] {new SqlParameter("ename", eName)};
        DataRowCollection StudentInfo = SQLstar.GetRecordset_P("StudentInfo", "SELECT * FROM CSUG_DIRECTORY_ALL_LOCAL WHERE ENAME = @ename", p);
        Literal1.Text = StudentInfo[0]["FIRST_NAME"] + " " + StudentInfo[0]["LAST_NAME"];

        SqlDataSource1.SelectParameters[0].DefaultValue = eName;
        SqlDataSource1.DataBind();
        GridView1.DataBind();
        if (HttpContext.Current.Request.Cookies["labRequest"] != null)
        {
            if (HttpContext.Current.Request.Cookies["labRequest"]["request"] != null)
            {
                HttpContext.Current.Request.Cookies["labRequest"]["request"] = null;
            }
        }
    }

    protected void SqlDataSource1_OnSelected(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.AffectedRows < 1)
        {
            Literal2.Text = "<p>You do not appear to have any credits. Please check our <a href=\"/\" class=\"normal\">printing policy</a> to determine if you qualify.</p>";
        }
    }
}
