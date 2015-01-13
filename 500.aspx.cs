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

public partial class _500 : System.Web.UI.Page
{
    string email_message_html_body = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string request = "";
        string referrer = "";
        string formdata = "";
        string querydata = "";
        string more = "";
        string oldSchoolURL = "";
        string[] firstDelimiter = new string[1];
        firstDelimiter[0] = "url=";




        // no old school ?url= business, or it had it but we don't have a record of it.
        // we have to set them a 404 and log the 404 and e-mail the 404

        // prep the e-mail
        if (Request.UrlReferrer != null)
        {
            referrer = Request.UrlReferrer.ToString().Replace("'", "''");
        }

        // the entire form collection
        if (Request.Form.ToString() != null)
        {
            formdata = Request.Form.ToString();
        }

        // the entire querystring collection
        if (Request.QueryString.ToString() != null)
        {
            querydata = Request.QueryString.ToString();
        }

        if (Request.QueryString["aspxerrorpath"] != null)
        {
            request = Request.ServerVariables["HTTP_HOST"].ToString().Replace("'", "''") + ":" + Request.ServerVariables["SERVER_PORT"].ToString().Replace("'", "''") + Request.QueryString["aspxerrorpath"].ToString().Replace("'", "''");
        }
        else
        {
            request = Request.ServerVariables["QUERY_STRING"].ToString().Replace("404;http://", "").Replace("'", "''");
        }

        if (Request.ServerVariables["ALL_HTTP"] != null)
        {
            more = Request.ServerVariables["ALL_HTTP"].ToString();
        }


        email_message_html_body = "<p>500 on IULab.</p><ul><li>Page Requested: <strong>" + request + "</strong></li><li>Query Data: <strong>" + querydata + "</strong></li><li>Form Data: <strong>" + formdata + "</strong></li><li>Referer: <strong>" + referrer + "</strong></li><li>Referer: <strong>" + referrer + "</strong></li><li>Remote Address: <strong>" + Request.ServerVariables["REMOTE_ADDR"] + "</strong></li><li>More: <strong>" + more + "</strong></li></ul>";

        // send the e-mail

        //Email.SimpleSend("500 on IULab", email_message_html_body, "cwis37@colostate.edu", "matthew.goodrich@colostate.edu");
    }
}
