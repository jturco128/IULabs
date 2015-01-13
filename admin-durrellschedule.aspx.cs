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
using System.Text;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Auth.AuthorizeByType("Contributor");

        StringBuilder calendar = new StringBuilder();
        DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);

        DataRowCollection RS = SQLstar.GetRecordset("Lab", "SELECT * FROM LabSchedule WHERE lab_id = 2;");

        for (int i = 0; i < 17; i++)
        {
            calendar.Append("<tr>");
            calendar.Append("<td class=\"hour\" scope=\"row\">" + time.ToString("HH:mm") + "</td>");
            string sunday = "";
            string monday = "";
            string tuesday = "";
            string wednesday = "";
            string thursday = "";
            string friday = "";
            string saturday = "";
            if (RS != null)
            {
                foreach (DataRow row in RS)
                {
                    if (Convert.ToBoolean(row["sun"]) == true)
                    {
                        DateTime Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["start_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["start_time"].ToString().Substring(3, 2)), 0);
                        TimeSpan ts = time.Subtract(Start);
                        DateTime End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["end_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["end_time"].ToString().Substring(3, 2)), 0);
                        End = End.AddMinutes(-1);
                        TimeSpan ts2 = time.Subtract(End);
                        if ((ts.Minutes >= 0) && (ts.Hours >= 0) && (ts2.Minutes <= 0) && (ts2.Hours <= 0))
                        {
                            if (Auth.GetCurrentUser() == Auth.GetEnameById(Convert.ToInt32(row["user_id"])))
                                sunday += "<p class=\"usershift\">" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                            else
                                sunday += "<p>" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                        }
                    }
                    if (Convert.ToBoolean(row["mon"]) == true)
                    {
                        DateTime Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["start_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["start_time"].ToString().Substring(3, 2)), 0);
                        TimeSpan ts = time.Subtract(Start);
                        DateTime End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["end_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["end_time"].ToString().Substring(3, 2)), 0);
                        End = End.AddMinutes(-1);
                        TimeSpan ts2 = time.Subtract(End);
                        if ((ts.Minutes >= 0) && (ts.Hours >= 0) && (ts2.Minutes <= 0) && (ts2.Hours <= 0))
                        {
                            if (Auth.GetCurrentUser() == Auth.GetEnameById(Convert.ToInt32(row["user_id"])))
                                monday += "<p class=\"usershift\">" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                            else
                                monday += "<p>" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                        }
                    }
                    if (Convert.ToBoolean(row["tues"]) == true)
                    {
                        DateTime Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["start_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["start_time"].ToString().Substring(3, 2)), 0);
                        TimeSpan ts = time.Subtract(Start);
                        DateTime End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["end_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["end_time"].ToString().Substring(3, 2)), 0);
                        End = End.AddMinutes(-1);
                        TimeSpan ts2 = time.Subtract(End);
                        if ((ts.Minutes >= 0) && (ts.Hours >= 0) && (ts2.Minutes <= 0) && (ts2.Hours <= 0))
                        {
                            if(Auth.GetCurrentUser() == Auth.GetEnameById(Convert.ToInt32(row["user_id"])))
                                tuesday += "<p class=\"usershift\">" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                            else
                                tuesday += "<p>" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                        }
                    }
                    if (Convert.ToBoolean(row["wed"]) == true)
                    {
                        DateTime Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["start_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["start_time"].ToString().Substring(3, 2)), 0);
                        TimeSpan ts = time.Subtract(Start);
                        DateTime End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["end_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["end_time"].ToString().Substring(3, 2)), 0);
                        End = End.AddMinutes(-1);
                        TimeSpan ts2 = time.Subtract(End);
                        if ((ts.Minutes >= 0) && (ts.Hours >= 0) && (ts2.Minutes <= 0) && (ts2.Hours <= 0))
                        {
                            if (Auth.GetCurrentUser() == Auth.GetEnameById(Convert.ToInt32(row["user_id"])))
                                wednesday += "<p class=\"usershift\">" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                            else
                                wednesday += "<p>" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                        }
                    }
                    if (Convert.ToBoolean(row["thurs"]) == true)
                    {
                        DateTime Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["start_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["start_time"].ToString().Substring(3, 2)), 0);
                        TimeSpan ts = time.Subtract(Start);
                        DateTime End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["end_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["end_time"].ToString().Substring(3, 2)), 0);
                        End = End.AddMinutes(-1);
                        TimeSpan ts2 = time.Subtract(End);
                        if ((ts.Minutes >= 0) && (ts.Hours >= 0) && (ts2.Minutes <= 0) && (ts2.Hours <= 0))
                        {
                            if (Auth.GetCurrentUser() == Auth.GetEnameById(Convert.ToInt32(row["user_id"])))
                                thursday += "<p class=\"usershift\">" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                            else
                                thursday += "<p>" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                        }
                    }
                    if (Convert.ToBoolean(row["fri"]) == true)
                    {
                        DateTime Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["start_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["start_time"].ToString().Substring(3, 2)), 0);
                        TimeSpan ts = time.Subtract(Start);
                        DateTime End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["end_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["end_time"].ToString().Substring(3, 2)), 0);
                        End = End.AddMinutes(-1);
                        TimeSpan ts2 = time.Subtract(End);
                        if ((ts.Minutes >= 0) && (ts.Hours >= 0) && (ts2.Minutes <= 0) && (ts2.Hours <= 0))
                        {
                            if (Auth.GetCurrentUser() == Auth.GetEnameById(Convert.ToInt32(row["user_id"])))
                                friday += "<p class=\"usershift\">" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                            else
                                friday += "<p>" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                        }
                    }
                    if (Convert.ToBoolean(row["sat"]) == true)
                    {
                        DateTime Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["start_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["start_time"].ToString().Substring(3, 2)), 0);
                        TimeSpan ts = time.Subtract(Start);
                        DateTime End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(row["end_time"].ToString().Substring(0, 2)), Convert.ToInt32(row["end_time"].ToString().Substring(3, 2)), 0);
                        End = End.AddMinutes(-1);
                        TimeSpan ts2 = time.Subtract(End);
                        if ((ts.Minutes >= 0) && (ts.Hours >= 0) && (ts2.Minutes <= 0) && (ts2.Hours <= 0))
                        {
                            if (Auth.GetCurrentUser() == Auth.GetEnameById(Convert.ToInt32(row["user_id"])))
                                saturday += "<p class=\"usershift\">" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                            else
                                saturday += "<p>" + Auth.GetUserById(Convert.ToInt32(row["user_id"])) + "</p>";
                        }
                    }
                }
            }
            calendar.Append("<td class=\"Sun\">" + sunday + "</td>");
            calendar.Append("<td class=\"Mon\">" + monday + "</td>");
            calendar.Append("<td class=\"Tue\">" + tuesday + "</td>");
            calendar.Append("<td class=\"Wed\">" + wednesday + "</td>");
            calendar.Append("<td class=\"Thu\">" + thursday + "</td>");
            calendar.Append("<td class=\"Fri\">" + friday + "</td>");
            calendar.Append("<td class=\"Sat\">" + saturday + "</td>");



            calendar.Append("</tr>");
            time = time.AddHours(1);
        }
        Literal1.Text = calendar.ToString();
    }
}
