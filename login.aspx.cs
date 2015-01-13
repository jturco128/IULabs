using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public class WebAuthForm : System.Web.UI.Page
{
    protected System.Web.UI.WebControls.Label login_form;

    private void Page_Load(object sender, System.EventArgs e)
    {

        //if (!Request.Url.ToString().Contains("https://wsnet.colostate.edu/cwis37/news/login"))
        //{
        //    Response.Redirect("https://wsnet.colostate.edu/cwis37/news/login.aspx", true);
        //}

        //set AuthenticationToken equal to user's session variable
        Session["AuthenticationToken"] = this.Session.SessionID;

        // set ProcessedAuth equal to "No" -- processing page checks to see it's "No"
        // then sets it to Yes -- used to make sure we don't do the auth attempt twice in a row.
        Session["ProcessedAuth"] = "No";

        //Setup the URL to "GET" the login form from
        //			string url = "https://ovid.colostate.edu/eidentity/authentication/authenticatev2.cfm?";
        string url = "https://eid.colostate.edu/eIDWebAuth/AuthenticateV3.aspx?";

        //The token assigned to you for this eService website
        url = url + "eServiceToken=31898575846274283404";

        //Add the token parameter generated above to verify response coming back is from the authenticator page
        url = url + "&Token=" + (string)Session["AuthenticationToken"];

        //Select how to display the submit button.  Can be [""||Default||URL to a graphic]
        //url = url + "&SubmitGraphic=Default";

        // setup an HTTPWebRequest to "GET" the login form
        HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse HttpWRes = (HttpWebResponse)HttpWReq.GetResponse();
        Stream responseStream = HttpWRes.GetResponseStream();
        StreamReader reader = new StreamReader(responseStream);

        // set text property of the label in auth.aspx to the results of the HTTP request
        login_form.Text = reader.ReadToEnd();

    } // Page_Load

} // class WebAuthForm
