<%@ Application Language="C#" %>

<script runat="server">

    public override void Init()
    {

    }

    void BeginRequest_Upload(object sender, EventArgs e)
    {

    } 
    
    void Application_Start(object sender, EventArgs e) 
    { 

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    } // supercalifragilisticexpialidocious
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        Exception ex = Server.GetLastError();
        string body = "<strong>Message: </strong>" + ex.InnerException.Message + "<br /><br /><strong>Data: </strong>" + ex.InnerException.Data +  "<br /><br /><strong>Stack Trace: </strong>" + ex.InnerException.StackTrace;
        Email.SimpleSend("Error on IULab", body, "IULab@colostate.edu", "matthew.goodrich@colostate.edu");
        //HttpContext.Current.Response.Redirect("500.aspx");
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    
        
</script>
