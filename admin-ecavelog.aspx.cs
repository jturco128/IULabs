﻿using System;
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
        //Auth.AuthorizeByType("Contributor");

        if (Auth.GetUserType() == "Super")
            GridView1.AutoGenerateDeleteButton = true;
    }

    protected void GridView1_OnDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SQLstar.Execute("Lab", "DELETE FROM LabLogLab WHERE log_id = '" + e.Keys[0] + "'");
    }

    protected void Button1_OnClick(object sender, EventArgs e)
    {
        SqlParameter[] p = new SqlParameter[] { new SqlParameter("from", TextBox1.Text), new SqlParameter("to", TextBox2.Text), new SqlParameter("date", DateTime.Now), new SqlParameter("issue", TextBox3.Text), new SqlParameter("resolved", Boolean.Parse(RadioButtonList1.SelectedValue)) };
        SQLstar.Execute_P("Lab", "INSERT INTO LabLog (log_from, log_to, date_logged, issue, resolved) VALUES (@from, @to, @date, @issue, @resolved)", p);

        DataRowCollection GetID = SQLstar.GetRecordset("Lab", "SELECT IDENT_CURRENT('LabLog')");

        foreach (ListItem li in CheckBoxList1.Items)
        {
            if (li.Selected)
                SQLstar.Execute("Lab", "INSERT INTO LabLogLab (lab_id, log_id) VALUES('" + li.Value + "', '" + GetID[0][0] + "')");
        }
    }

    public void DisplayEnabled_OnClick(Object sender, ImageClickEventArgs e)
    {
        // Get the control that called this method, which must be an ImageButton.
        ImageButton b = (ImageButton)sender;

        // Get the id of the record we stored in the CommandName attribute.
        int id = int.Parse(b.CommandName);

        // Update the record based on whether it was enabled before (stored in CommandArg).
        if (b.CommandArgument.ToLower().Equals("false"))
        {
            // It was false so set to true(1)
            SQLstar.Execute("Lab", "UPDATE LabLog SET resolved=1 WHERE id='" + id + "';");
        }
        else
        {
            // It was true so set to false(0)
            SQLstar.Execute("Lab", "UPDATE LabLog SET resolved=0 WHERE id='" + id + "';");
        }

        // Redirect Back on self to avoid "F5" "cntl-R" refresh events from re-submitting
        // This also makes rebinding unecessary here, as it gets done on the redirect.
        GridView1.DataBind();
        // Make sure to rebind the data, in order for the page to show the DB updates correctly.       
    }
}
