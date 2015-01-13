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

public partial class _404 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // set up variables
        string request = "";
        string referrer = "";
        string remote_address = "";

        // get referrer
        if (Request.UrlReferrer != null)
        {
            referrer = Request.UrlReferrer.ToString();
        }

        // grab x-forwarded (set by load balancer) if it's there
        if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
        {
            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Length > 0)
            {
                remote_address = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
        }
        else
        // if not, grab remote-addr
        {
            if (Request.ServerVariables["REMOTE_ADDR"] != null)
            {
                remote_address = Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
        }

        // get attempted-page (works for .aspx files via IIS setting 'errorpath')
        if (Request.QueryString["aspxerrorpath"] != null)
        {
            request = Request.ServerVariables["HTTP_HOST"].ToString() + Request.QueryString["aspxerrorpath"].ToString();
        }
        else
        {
            request = Request.ServerVariables["QUERY_STRING"].ToString().Replace("404;http://", "").Replace(":80", "");
        }
        
        string body = "<h1>404 on IULab</h1><strong>Referrer: </strong>" + referrer + "<br/><br/><strong>Request: </strong>" + request + "<br/><br/><strong>Remote Address: </strong>" + remote_address;
        //Email.SimpleSend("404 on News", body, "cwis37@colostate.edu", "matthew.goodrich@colostate.edu");
    }
}
