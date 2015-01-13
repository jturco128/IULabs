<%@ Page Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="admin-editdurrellschedule.aspx.cs" Inherits="admin" Title="Admin - Intra University Computer Labs - Colorado State University" MaintainScrollPositionOnPostback="true" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="support/css/table.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="left">
          <div class="left_top">
            <div class="left_bottom">
              <h2>Edit Durrell Schedule</h2>
              <p><a href="admin.aspx">Back to Admin</a></p>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:Lab %>"
                SelectCommand="SELECT * FROM LabUsers INNER JOIN LabUserType ON LabUsers.type_id = LabUserType.type_id ORDER BY ename">
                </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                    AutoGenerateColumns="False" DataKeyNames="user_id">
                    <Columns>
                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                    ImageUrl="support/images/16-tool-a.png" Text="Edit"></asp:ImageButton>
                                <asp:ImageButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                                    ImageUrl="support/images/16-em-cross.png" Text="Delete"></asp:ImageButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Update"
                                    ImageUrl="support/images/16-floppy.png" Text="Update"></asp:ImageButton>
                                <asp:ImageButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                    ImageUrl="support/images/16-cancel.png" Width="16" Height="16" Text="Cancel"></asp:ImageButton>
                            </EditItemTemplate>
                            <ItemStyle Width="75px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="user_id" HeaderText="user_id" InsertVisible="False" 
                            ReadOnly="True" SortExpression="user_id" Visible="false" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%# GetUsers(Eval("ename").ToString()) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shifts">
                            <ItemTemplate>
                                <%# GetShifts(Eval("user_id").ToString()) %>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="support/images/16-em-plus.png" />
                                <asp:Panel ID="Panel1" runat="server" CssClass="popupControl">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div style="background-color:White; border:1px solid #000; padding:10px; width:300px;">
                                            <strong>Add Shift</strong><br /><br />
                                                <asp:Label ID="Label1" runat="server" Text="Start Time:"></asp:Label>
                                                <asp:TextBox ID="StartTextBox" runat="server"></asp:TextBox><br />
                                                <asp:Label ID="Label2" runat="server" Text="End Time: "></asp:Label>
                                                <asp:TextBox ID="EndTextBox" runat="server"></asp:TextBox><br />
                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Durrell" Value="2" />
                                                    <asp:ListItem Text="E-Cave" Value="1" />
                                                </asp:RadioButtonList>
                                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Sat" Value="sat" />
                                                    <asp:ListItem Text="Sun" Value="sun" />
                                                    <asp:ListItem Text="Mon" Value="mon"/>
                                                    <asp:ListItem Text="Tue" Value="tues"/>
                                                    <asp:ListItem Text="Wed" Value="wed"/>
                                                    <asp:ListItem Text="Thur" Value="thurs"/>
                                                    <asp:ListItem Text="Fri" Value="fri"/>
                                                </asp:CheckBoxList>
                                                <asp:Button ID="Button1" runat="server" Text="Add Shift" 
                                                    onclick="Button1_Click" CommandName='<%# Eval("user_id") %>' />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                                <cc1:popupcontrolextender ID="Popupcontrolextender1" runat="server" TargetControlID="ImageButton1" PopupControlID="Panel1" Position="Bottom"></cc1:popupcontrolextender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
              <div class="clr"></div>
            </div>
          </div>
        </div>
</asp:Content>

