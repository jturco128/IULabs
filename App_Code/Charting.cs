using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Charting
/// </summary>
public class Charting
{
	public Charting()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static double getNumber(string sql_string)
    {
        double returnDouble = 0.0;

        DataRowCollection GetRS = SQLstar.GetRecordset("Lab", sql_string);
        if(GetRS != null)
            returnDouble = Convert.ToDouble(GetRS[0][0]);

        return returnDouble;
    }

    public static string getColumn1(string sql_string)
    {
        string returnString = "";

        DataRowCollection Column1RS = SQLstar.GetRecordset("Lab", sql_string);

        if (Column1RS != null)
        {
            for (int i = 0; i < Column1RS.Count; i++)
            {
                returnString += "\"" + Column1RS[i][0] + ":00\",";
            }
        }

        return returnString.Substring(0, returnString.Length - 1);
    }

    public static string getColumn2(string sql_string)
    {
        string returnString = "";

        DataRowCollection Column2RS = SQLstar.GetRecordset("Lab", sql_string);

        if (Column2RS != null)
        {
            for (int i = 0; i < Column2RS.Count; i++)
            {
                returnString += Column2RS[i][1] + ",";
            }
        }

        return returnString.Substring(0, returnString.Length - 1);
    }
}