using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_contact : System.Web.UI.Page
{
    private List<SqlParameter> insertParameters = new List<SqlParameter>();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Auth.AuthorizeByType("Super");
    }

    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "InsertNew")
        {
            TextBox name = GridView1.FooterRow.FindControl("InsertName") as TextBox;
            TextBox phone = GridView1.FooterRow.FindControl("InsertPhone") as TextBox;
            TextBox email = GridView1.FooterRow.FindControl("InsertEmailAddress") as TextBox;

            SqlParameter Sname = new SqlParameter("@name", name.Text);
            insertParameters.Add(Sname);

            SqlParameter Sphone = new SqlParameter("@phone", phone.Text);
            insertParameters.Add(Sphone);

            SqlParameter Semail = new SqlParameter("@email_address", email.Text);
            insertParameters.Add(Semail);

            SqlParameter Sdate = new SqlParameter("@date_modified", DateTime.Now);
            insertParameters.Add(Sdate);

            SqlDataSource1.Insert();
        }
    }

    protected void SqlDataSource1_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {
        e.Command.Parameters.Clear();
        foreach (SqlParameter p in insertParameters)
            e.Command.Parameters.Add(p);
    }
}