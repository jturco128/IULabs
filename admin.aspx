<%@ Page Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" Title="Admin - Intra University Computer Labs - Colorado State University" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>I work in: 
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
        <asp:ListItem Text="Durrell" Value="Durrell" Enabled="true" Selected="True"/>
        <asp:ListItem Text="E-Cave" Value="E-Cave" Enabled="true" Selected="True"/>
    </asp:CheckBoxList></p>
<asp:Panel ID="AdminPanel" runat="server">
<div class="left">
  <div class="left_top">
    <div class="left_bottom">
        <h2>Super User Tools</h2>
        <ul>
        <li><a href="admin-editecaveschedule.aspx">Edit e-Cave Schedule</a></li>
        <li><a href="admin-editdurrellschedule.aspx">Edit Durrell Schedule</a></li>
        <li><a href="admin-users.aspx">User Management</a></li>
        <li><a href="admin-printing.aspx">Print Management</a></li>
        <li><a href="admin-contact.aspx">User Contact Management</a></li>
        </ul>
        <div class="clr"></div>
    </div>
  </div>
</div>
</asp:Panel>
<asp:Panel ID="DurrellPanel" runat="server">
<div class="left">
  <div class="left_top">
    <div class="left_bottom">
<h2>Durrell Tools</h2>
<ul>
<li><a href="admin-durrellschedule.aspx">View Durrell Schedule</a></li>
<li><a href="admin-durrelllog.aspx">Durrell Log</a></li>
</ul>
<div class="clr"></div>
    </div>
  </div>
</div>
</asp:Panel>
<asp:Panel ID="ECavePanel" runat="server">
<div class="left">
  <div class="left_top">
    <div class="left_bottom">
<h2>E-Cave Tools</h2>
<ul>
<li><a href="admin-ecaveschedule.aspx">View e-Cave Schedule</a></li>
<li><a href="admin-ecavelog.aspx">e-Cave Log</a></li>
<li><a href="admin-laptopcheckout.aspx">Laptop Checkout</a></li>
</ul>
<div class="clr"></div>
    </div>
  </div>
</div>
</asp:Panel>
<div class="left">
  <div class="left_top">
    <div class="left_bottom">
<h2>Generic Tools</h2>
<ul>
<li><a href="admin-getcovered.aspx">Get Your Shift Covered</a></li>
<li><a href="admin-cover.aspx">View/Cover a Shift</a></li>
</ul>
<div class="clr"></div>
    </div>
  </div>
</div>
              
</asp:Content>

