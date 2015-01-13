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
using System.Data.SqlClient;
using System.Text;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Auth.AuthorizeByType("Contributor");
    }

    public string GetUsers(string eName)
    {
        SqlParameter[] p = new SqlParameter[1] { new SqlParameter("ename", eName) };
        DataRowCollection StudentInfo = SQLstar.GetRecordset_P("StudentInfo", "SELECT * FROM CSUG_DIRECTORY_ALL_LOCAL WHERE ENAME = @ename", p);
        if (StudentInfo != null)
            return StudentInfo[0]["FIRST_NAME"] + " " + StudentInfo[0]["LAST_NAME"];
        return "";
    }

    public string GetShifts(string userID)
    {
        StringBuilder sb = new StringBuilder();
        
        string labString = "";
        string Days = "";

        DataRowCollection RS = SQLstar.GetRecordset("Lab", "SELECT * FROM LabSchedule WHERE user_id = '" + userID + "'");
        if (RS != null)
        {
            sb.Append("<ul>");
            foreach (DataRow row in RS)
            {
                Days = "";
                if (row["lab_id"].ToString() == "1")
                    labString = "E-Cave";
                else
                    labString = "Durrell";

                if(Convert.ToBoolean(row["sat"]) == true)
                    Days += "Sat ";
                if(Convert.ToBoolean(row["sun"]) == true)
                    Days += "Sun ";
                if(Convert.ToBoolean(row["mon"]) == true)
                    Days += "Mon ";
                if(Convert.ToBoolean(row["tues"]) == true)
                    Days += "Tues ";
                if(Convert.ToBoolean(row["wed"]) == true)
                    Days += "Wed ";
                if(Convert.ToBoolean(row["thurs"]) == true)
                    Days += "Thur ";
                if (Convert.ToBoolean(row["fri"]) == true)
                    Days += "Fri";

                sb.Append("<li><strong>" + labString + "</strong> - " + row["start_time"] + " - " + row["end_time"] + " - " + Days + "</li>");
            }
            sb.Append("</ul>");
        }
        
        return sb.ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Get the control that called this method, which must be an ImageButton.
        Button b = (Button)sender;

        // Get the id of the record we stored in the CommandName attribute.
        int id = int.Parse(b.CommandName);

        SqlParameter[] p = new SqlParameter[11] { new SqlParameter("user_id", id), new SqlParameter("start_time", StartTextBox.Text), new SqlParameter("end_time", EndTextBox.Text), new SqlParameter("sat", CheckBoxList1.Items[0].Selected), new SqlParameter("sun", CheckBoxList1.Items[1].Selected), new SqlParameter("mon", CheckBoxList1.Items[2].Selected), new SqlParameter("tues", CheckBoxList1.Items[3].Selected), new SqlParameter("wed", CheckBoxList1.Items[4].Selected), new SqlParameter("thurs", CheckBoxList1.Items[5].Selected), new SqlParameter("fri", CheckBoxList1.Items[6].Selected), new SqlParameter("lab_id", RadioButtonList1.SelectedValue) };
        SQLstar.Execute_P("Lab", "INSERT INTO LabSchedule (user_id, start_time, end_time, sat, sun, mon, tues, wed, thurs, fri, lab_id) VALUES (@user_id, @start_time, @end_time, @sat, @sun, @mon, @tues, @wed, @thurs, @fri, @lab_id)", p);

        GridView1.DataBind();
    }
}
