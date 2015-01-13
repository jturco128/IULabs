<%@ Page Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="admin-users.aspx.cs" Inherits="admin" Title="Admin - Intra University Computer Labs - Colorado State University" %>
<%@ Register Assembly="RealTimeSearch" Namespace="RealTimeSearch" TagPrefix="rts" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="support/css/table.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="left">
          <div class="left_top">
            <div class="left_bottom">
              <h2>User Management</h2>
              <p><a href="admin.aspx">Back to Admin</a></p>
              <p><strong>Add New Users</strong></p>
              <div style="text-align:center;">
    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_OnTextChanged"></asp:TextBox>
    
    <rts:realtimesearchmonitor runat="server" ID="RealTimeSearch" Interval="200" AssociatedUpdatePanelID="ResultsUpdatePanel">
        <ControlsToMonitor>
            <rts:ControlMonitorParameter TargetId="TextBox1" EventName="TextChanged" />
        </ControlsToMonitor>
    </rts:realtimesearchmonitor>
            
            
     <asp:UpdatePanel ID="ResultsUpdatePanel" runat="server">
        <ContentTemplate>
            <p style="color:Red;"><asp:Literal ID="Literal1" runat="server"></asp:Literal></p>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" 
               OnRowCommand="GridView2_OnRowCommand" DataKeyNames="ename">
                <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" Text="Select" CommandArgument='<%#Eval("ename")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%# Eval("LAST_NAME")%>, <%# Eval("FIRST_NAME") %> ( <%#Eval("ename")%> )<br />
                        <%# ((Eval("EMPLOYEE_DEPARTMENT").ToString())!= "")?(Eval("EMPLOYEE_DEPARTMENT")):(Eval("STUDENT_MAJOR")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
              <p><strong>Current Users</strong></p>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:Lab %>"
                SelectCommand="SELECT * FROM LabUsers INNER JOIN LabUserType ON LabUsers.type_id = LabUserType.type_id ORDER BY ename"
                UpdateCommand="UPDATE LabUsers SET type_id=@type_id WHERE user_id=@user_id"
                DeleteCommand="DELETE FROM LabUsers WHERE user_id=@user_id" >
                    <UpdateParameters>
                        <asp:Parameter Name="type_id" />
                        <asp:Parameter Name="user_id" />
                    </UpdateParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="user_id" />
                    </DeleteParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                    AutoGenerateColumns="False" DataKeyNames="user_id">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="user_id" HeaderText="user_id" InsertVisible="False" 
                            ReadOnly="True" SortExpression="user_id" Visible="false" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%# GetUsers(Eval("ename").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Type">
                            <ItemTemplate>
                                <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("type") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" connectionString="<%$ connectionStrings:Lab %>"
                                SelectCommand="SELECT * FROM LabUserType"></asp:SqlDataSource>
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="type" DataValueField="type_id" SelectedValue='<%#Bind("type_id") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
              
              <div class="clr"></div>
            </div>
          </div>
        </div>
</asp:Content>

