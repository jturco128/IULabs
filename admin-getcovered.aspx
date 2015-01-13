<%@ Page Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="admin-getcovered.aspx.cs" Inherits="admin" Title="Admin - Intra University Computer Labs - Colorado State University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="left">
          <div class="left_top">
            <div class="left_bottom">
              <h2>Get Your Shift Covered</h2>
              <p><a href="admin.aspx">Back to Admin</a></p>
              <p><strong><asp:Literal ID="Literal1" runat="server"></asp:Literal></strong></p>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Lab %>" 
                    SelectCommand="SELECT * FROM [LabSchedule]"></asp:SqlDataSource>

              <div class="clr"></div>   
            </div>
          </div>
        </div>
</asp:Content>

