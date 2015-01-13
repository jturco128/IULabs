<%@ Page Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="admin-durrelllog.aspx.cs" Inherits="admin" Title="Durrell Log - Admin - Intra University Computer Labs - Colorado State University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="support/css/table.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="left">
          <div class="left_top">
            <div class="left_bottom">
              <h2>Durrell Log</h2>
                <p><a href="admin.aspx">Back to Admin</a></p>
                <p><a href="javascript:void()" class="addlink normal">Add Log Entry</a></p>
                    <div id="contactform" class="addlog">
                    <ol>
                    <li>
                    <label>From:</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<p>* Required Field</p>" ControlToValidate="TextBox1" Display="Dynamic" ValidationGroup="MyValidationGroup"></asp:RequiredFieldValidator>
                    </li>
                    <li>
                    <label>To:</label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<p>* Required Field</p>" ControlToValidate="TextBox2" Display="Dynamic" ValidationGroup="MyValidationGroup"></asp:RequiredFieldValidator>
                    </li>
                    <li>
                    <label>Issue: </label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="text" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<p>* Required Field</p>" ControlToValidate="TextBox3" Display="Dynamic" ValidationGroup="MyValidationGroup"></asp:RequiredFieldValidator>
                    </li>
                    <li><label>Resolved: </label>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" CssClass="blanktable">
                            <asp:ListItem Text="Yes" Value="true" />
                            <asp:ListItem Text="No" Value="false" />
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="<p>* Required Field</p>" ControlToValidate="RadioButtonList1" Display="Dynamic" ValidationGroup="MyValidationGroup"></asp:RequiredFieldValidator>
                        </li>
                        <li><asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" CssClass="blanktable">
                            <asp:ListItem Text="Durrell" Value="2" Selected="True" />
                            <asp:ListItem Text="E-Cave" Value="1" />
                        </asp:CheckBoxList>
                        </li>
                        <li>
                            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_OnClick" ValidationGroup="MyValidationGroup" />
                        </li>
                    </ol>
                    </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Lab %>"
                SelectCommand="SELECT LL.id, LL.log_from, LL.log_to, LL.date_logged, LL.issue, LL.resolved FROM LabLog LL, LabLogLab LLL WHERE LL.id = LLL.log_id AND LLL.lab_id = 2 ORDER BY LL.date_logged DESC"
                DeleteCommand="DELETE FROM LabLog WHERE id=@id">
                    <DeleteParameters>
                        <asp:Parameter Name="id" />
                    </DeleteParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" DataSourceID="SqlDataSource1" AutoGenerateColumns="false" DataKeyNames="id"  OnRowDeleting="GridView1_OnDeleting">
                    <Columns>
                        <asp:BoundField HeaderText="ID" Visible="false" DataField="id" />
                        <asp:BoundField HeaderText="From" DataField="log_from" SortExpression="log_from" />
                        <asp:BoundField HeaderText="To" DataField="log_to" SortExpression="log_to" />
                        <asp:BoundField HeaderText="Date" DataField="date_logged" SortExpression="date_logged" />
                        <asp:BoundField HeaderText="Issue" DataField="issue" SortExpression="issue" />
                        <asp:TemplateField HeaderText="Resolved">
                            <ItemTemplate>
                                <asp:ImageButton ID="DisplayImageButton" ImageUrl='<%# ((bool)Eval("resolved")==true ? "support/images/16-circle-green.png" : "support/images/16-circle-red.png") %>'
                                        runat="server" OnClick="DisplayEnabled_OnClick" CommandArgument='<%# Eval("resolved") %>'
                                        CommandName='<%# Eval("id") %>' ToolTip="Toggle whether the media image is shown." />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
              <div class="clr"></div>
            </div>
          </div>
        </div>
</asp:Content>

