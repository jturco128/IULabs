<%@ Page Title="" Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="admin-laptopcheckout.aspx.cs" Inherits="admin_laptopcheckout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="left">
  <div class="left_top">
    <div class="left_bottom">
        <h2>Check-In Laptop</h2>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Lab %>" 
            SelectCommand="SELECT id, name FROM Laptop WHERE checkedOut = 1"></asp:SqlDataSource>
            <div id="contactform">
            <ol>
        <li><label>Laptop: </label>
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="id" AppendDataBoundItems="true">
            <asp:ListItem>Please Select</asp:ListItem>
        </asp:DropDownList>
        </li>
        <li><asp:Button ID="Button1" runat="server" Text="Check-In" OnClick="Button1_OnClick" /></li>
        </ol>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
        <div class="clr"></div>
    </div>
  </div>
</div>
<div class="left">
  <div class="left_top">
    <div class="left_bottom">
        <h2>Check-Out Laptop</h2>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Lab %>" 
            SelectCommand="SELECT id, name, checkedOut FROM Laptop WHERE checkedOut = 0"></asp:SqlDataSource>
            <div id="contactform">
        <ol>
            <li><label>Laptop: </label>
                <asp:DropDownList ID="DropDownList2" runat="server" 
                    DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="id" AppendDataBoundItems="true">
                    <asp:ListItem>Please Select</asp:ListItem>
                </asp:DropDownList>
                <div class="clr"></div>
            </li>
            <li>
                <label>CSUID:</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="text"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="CSUID is a 9 digit number. Do not enter dashes or spaces!" ValidationExpression="[0-9]{9}" ControlToValidate="TextBox1" ></asp:RegularExpressionValidator>
            </li>
            <li><asp:Button ID="Button2" runat="server" Text="Check Out" OnClick="Button2_OnClick" /></li>
            
        </ol>
        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
        </div>
        <div class="clr"></div>
    </div>
  </div>
</div>
</asp:Content>