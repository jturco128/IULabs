using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_laptopcheckout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Auth.AuthorizeByType("Contributor");
    }

    protected void Button1_OnClick(object sender, EventArgs e)
    {
        Literal1.Text = "";
        Literal2.Text = "";
        if (DropDownList1.SelectedIndex != 0)
        {
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@laptopId", DropDownList1.SelectedValue) };
            SQLstar.Execute_P("Lab", "UPDATE Laptop SET checkedOut = 0 WHERE id = @laptopId", p);
            Literal1.Text = "<p>Laptop Checked In Successfully!</p>";
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList1.Items.Add(new ListItem("Please Select"));
            DropDownList2.Items.Add(new ListItem("Please Select"));
            DropDownList1.DataBind();
            DropDownList2.DataBind();
        }
    }

    protected void Button2_OnClick(object sender, EventArgs e)
    {
        Literal1.Text = "";
        Literal2.Text = "";
        if (DropDownList2.SelectedIndex != 0)
        {
            SqlParameter[] p = new SqlParameter[] { new SqlParameter("@laptopId", DropDownList2.SelectedValue), new SqlParameter("@csuid", TextBox1.Text), new SqlParameter("@dateUsed", DateTime.Now) };
            SQLstar.Execute_P("Lab", "INSERT INTO LaptopUser (laptopId, csuid, dateUsed) VALUES (@laptopId, @csuid, @dateUsed); UPDATE Laptop SET checkedOut = 1 WHERE id = @laptopId;", p);
            Literal2.Text = "<p>Laptop Checked Out Successfully!</p>";
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList1.Items.Add(new ListItem("Please Select"));
            DropDownList2.Items.Add(new ListItem("Please Select"));
            DropDownList1.DataBind();
            DropDownList2.DataBind();
        }
    }
}
