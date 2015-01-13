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

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Auth.AuthorizeByType("Contributor");

        AdminPanel.Visible=false;
        ECavePanel.Visible=false;
        DurrellPanel.Visible=false;

        if (Auth.GetUserType() == "Super")
        {
            AdminPanel.Visible = true;
            ECavePanel.Visible = true;
            DurrellPanel.Visible = true;
        }

        if (CheckBoxList1.Items[0].Selected)
        {
            DurrellPanel.Visible = true;
        }
        else
        {
            DurrellPanel.Visible = false;
        }

        if (CheckBoxList1.Items[1].Selected)
        {
            ECavePanel.Visible = true;
        }
        else
        {
            ECavePanel.Visible = false;
        }
    }
}
