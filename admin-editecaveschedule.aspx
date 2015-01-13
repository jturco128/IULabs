<%@ Page Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="admin-editecaveschedule.aspx.cs" Inherits="admin" Title="Edit eCave Schedule - Admin - Intra University Computer Labs - Colorado State University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="support/css/table.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="left">
          <div class="left_top">
            <div class="left_bottom">
              <h2>Edit eCave Schedule</h2>
              <p><a href="admin.aspx">Back to Admin</a></p>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:Lab %>" 
                SelectCommand="SELECT user_id, start_time, end_time, sat, sun, mon, tues, wed, thurs, fri FROM LabSchedule WHERE lab_id = '1'"
                UpdateCommand="UPDATE LabSchedule SET start_time = @start_time, end_time = @end_time, sat=@sat, sun=@sun, mon=@mon, tues=@tues, wed=@wed, thurs=@thurs, fri=@fri WHERE id = @id"
                InsertCommand="INSERT INTO LabSchedule (user_id, start_time, end_time, sat, sun, mon, tues, wed, thurs, fri) VALUES(@user_id, @start_time, @end_time, @sat, @sun, @mon, @tues, @wed, @thurs, @fri)"
                DeleteCommand="DELETE FROM LabSchedule WHERE id = @id">
                    <UpdateParameters>
                        <asp:Parameter Name="id" />
                        <asp:Parameter Name="start_time" />
                        <asp:Parameter Name="end_time" />
                        <asp:Parameter Name="sat" />
                        <asp:Parameter Name="sun" />
                        <asp:Parameter Name="mon" />
                        <asp:Parameter Name="tues" />
                        <asp:Parameter Name="wed" />
                        <asp:Parameter Name="thurs" />
                        <asp:Parameter Name="fri" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="user_id" />
                        <asp:Parameter Name="start_time" />
                        <asp:Parameter Name="end_time" />
                        <asp:Parameter Name="sat" />
                        <asp:Parameter Name="sun" />
                        <asp:Parameter Name="mon" />
                        <asp:Parameter Name="tues" />
                        <asp:Parameter Name="wed" />
                        <asp:Parameter Name="thurs" />
                        <asp:Parameter Name="fri" />
                    </InsertParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="id" />
                    </DeleteParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="false">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                        <asp:TemplateField HeaderText="User" SortExpression="user_id">
                            <ItemTemplate>
                                <asp:Literal ID="Literal1" runat="server" Text='<%#Auth.GetUserById(Convert.ToInt32(Eval("user_id"))) %>' />
                            </ItemTemplate> 
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Start Time" SortExpression="start_time">
                            <ItemTemplate>
                                <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("start_time") %>' />
                            </ItemTemplate> 
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End Time" SortExpression="end_time">
                            <ItemTemplate>
                                <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("end_time") %>' />
                            </ItemTemplate> 
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
              <div class="clr"></div>
            </div>
          </div>
        </div>
</asp:Content>

