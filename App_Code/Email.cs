using System;
using System.Diagnostics; // this is for StackFrame/StackTrace
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Generic;

public class Email
{
	private Email()
	{
	}
	
	public static void SimpleSend(string my_subject, StringBuilder my_text, string from_addr, string to_addr)
	// takes in body as a STRINGBUILDER, assumes true for html and sends to the big one
	{
		Email.SimpleSend(my_subject, my_text, from_addr, to_addr, true);
	}	
	
	public static void SimpleSend(string my_subject, StringBuilder my_text, string from_addr, string to_addr, bool isHtml)
	// takes in body as a STRINGBUILDER
	{
		System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(from_addr);
		System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress(to_addr);
		System.Net.Mail.MailMessage email_message = new System.Net.Mail.MailMessage(from, to);
		email_message.Subject = my_subject;
		email_message.Body = my_text.ToString();
		email_message.IsBodyHtml = isHtml;
		email_message.BodyEncoding = System.Text.Encoding.ASCII;
        System.Net.Mail.SmtpClient smtp_client = new System.Net.Mail.SmtpClient("lamar.colostate.edu");
		smtp_client.Send(email_message);
	}
	
	public static void SimpleSend(string my_subject, StringBuilder my_text, string from_addr, string to_addr, string[] cc_addr, bool isHtml)
	// takes in body as a STRINGBUILDER
	{
		System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(from_addr);
		System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress(to_addr);
		
		// create the message
		System.Net.Mail.MailMessage email_message = new System.Net.Mail.MailMessage(from, to);
		
		// set its other properties
		foreach (string foo in cc_addr)
		{
			System.Net.Mail.MailAddress newCC = new System.Net.Mail.MailAddress(foo);
			email_message.CC.Add(foo);
		}
		email_message.Subject = my_subject;
		email_message.Body = my_text.ToString();
		
		// and its encoding
		email_message.IsBodyHtml = isHtml;
		email_message.BodyEncoding = System.Text.Encoding.ASCII;
		
		// send
        System.Net.Mail.SmtpClient smtp_client = new System.Net.Mail.SmtpClient("lamar.colostate.edu");
		smtp_client.Send(email_message);

	}
	
	public static void SimpleSend(string my_subject, string my_text, string from_addr, string to_addr)
	// takes in body as a STRING
	{
		System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(from_addr);
		System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress(to_addr);
		System.Net.Mail.MailMessage email_message = new System.Net.Mail.MailMessage(from, to);
		email_message.Subject = my_subject;
		email_message.Body = my_text;
		email_message.IsBodyHtml = true;
		email_message.BodyEncoding = System.Text.Encoding.ASCII;
		System.Net.Mail.SmtpClient smtp_client = new System.Net.Mail.SmtpClient("lamar.colostate.edu");
		smtp_client.Send(email_message);
	}
	
	public static void SimpleSend(string my_subject, StringBuilder my_text)
	// the ULTIMATE easy case
	{
		Email.SimpleSend(my_subject, my_text, "IULabs@colostate.edu", "michael.brake@colostate.edu");
	}
	public static void SimpleSend(string my_subject, string my_text)
	{
		Email.SimpleSend(my_subject, my_text, "IULabs@colostate.edu", "michael.brake@colostate.edu");
	}

    public static void SendToList(Dictionary<string, string> recipients , string from_address, string subject, string body)
    {
        // from
        System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(from_address);

        // server, with port number that is listening
        
		
		//// edited by adam:
		//System.Net.Mail.SmtpClient smtp_client = new System.Net.Mail.SmtpClient("yuma.colostate.edu", 169);
		
		System.Net.Mail.SmtpClient smtp_client = new System.Net.Mail.SmtpClient("lamar.colostate.edu");
//		System.Net.Mail.SmtpClient smpt_client = new System.Net.Mail.SmtpClient("wsnet.colostate.edu");
		//// edit by adam: the listserv port 169 is faster with ~600 recipients

        foreach (KeyValuePair<string, string> str in recipients)
        {
            try
            {
                // set the to address
                System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress(str.Value);

                // create a new MailMessage ojbect. Have to do this for each recipient, since TO is required in the constructor.
                System.Net.Mail.MailMessage email_message = new System.Net.Mail.MailMessage(from, to);

                // set the body and subject properties
                email_message.Body = body;
                email_message.Subject = subject;

                // set some other parameters
                email_message.IsBodyHtml = true;
                email_message.BodyEncoding = System.Text.Encoding.ASCII;

                // send it
                smtp_client.Send(email_message);

                // must garbage collect
                email_message.Dispose();

                //debug
                //Response.Write(i + ". " + recipient["email"].ToString() + "<br />");
                //Response.Flush();

                // count
                //i++;
            }
            catch (Exception ex)
            {
                // do something with the exception like e-mail ex.ToString()
            }
            //sub,text,from,to
            //Email.SimpleSend(subject, email_body, from, str.Value);
        }
    }
  	
	public static void SendException(Exception the_exception, string my_subject, string from_addr, string to_addr)
	// build the body and call SimpleSend while using a plain string as the body text.
	{
		// TODO: REMOVE THIS and REPLACE with OVERLOADED METHOD CALL with NULL or EMPTY ARRAY
		
		// Here we want some more information
		// Let's get the Context in order to use the Request object
		// Using "url" only right now. 
		// Might want to create a new SendException override method to handle this (append the exception to the message)
		HttpContext ctx = HttpContext.Current;		
		StringBuilder sb = new StringBuilder();
		sb.Append("Url: " + ctx.Request.Url + "<br /><br />");
		sb.Append("Exception: <br />" + the_exception.Message + "<br /><br />");
		sb.Append("Stack Trace: <br />" + the_exception.StackTrace + "<br /><br />");						
		sb.Append("Source: <br />" + the_exception.Source + "<br /><br />");
		sb.Append("TargetSite: <br />" + the_exception.TargetSite + "<br /><br />");
		Email.SimpleSend(my_subject, sb, from_addr, to_addr);
	} 
	
	public static void SendException(Exception the_exception, string my_subject, string from_addr, string to_addr, string[] cc_addr, bool isHtml)
	// build the body and call SimpleSend while using a plain string as the body text.
	{
		// Here we want some more information
		// Let's get the Context in order to use the Request object
		// Using "url" only right now. 
		// Might want to create a new SendException override method to handle this (append the exception to the message)
		HttpContext ctx = HttpContext.Current;		
		StringBuilder sb = new StringBuilder();
		sb.Append("Url: " + ctx.Request.Url + "<br /><br />");
		sb.Append("Exception: <br />" + the_exception.Message + "<br /><br />");
		sb.Append("Stack Trace: <br />" + the_exception.StackTrace + "<br /><br />");		
		System.Diagnostics.StackTrace st =  new System.Diagnostics.StackTrace(true); 
		StackFrame sf = st.GetFrame(0);
		sb.Append("<br />File: " + sf.GetFileName());
		sb.Append("<br />Method: " + sf.GetMethod().Name);
		sb.Append("<br />Line Number: " + sf.GetFileLineNumber());
		sb.Append("<br />Column Number: " + sf.GetFileColumnNumber());		
		Email.SimpleSend(my_subject, sb, from_addr, to_addr, cc_addr, isHtml);
	} 
	
	public static void SendException(Exception the_exception, string my_subject)
	// call the one without the body, giving it the addresses
	{
		// if only one "to" email then use this first call
		//Email.SendException(the_exception, my_subject, "cwis37@colostate.edu", "steven.tranby@colostate.edu");
		// if more than one email then uncomment below
		string[] cc_emails = {  };
		Email.SendException(the_exception, my_subject, "IULabs@colostate.edu", "michael.brake@colostate.edu", cc_emails, true);
	}

    public static bool IsValidEmailAddress(string address)
    {
        string pattern = "\\A(?:^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$)\\z";
        if(Regex.IsMatch(address, pattern))
        {
            try
            {
                string DN = address.Substring(address.IndexOf("@") + 1);
                IPHostEntry he = Dns.Resolve(DN);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        else
        {
            return false;
        }
    }
}