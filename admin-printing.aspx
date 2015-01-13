<%@ Page Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="admin-printing.aspx.cs" Inherits="admin" Title="Admin - Intra University Computer Labs - Colorado State University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="left">
          <div class="left_top">
            <div class="left_bottom">
              <h2>Print Management</h2>
              <ul>
                <li><a href="admin-printinguserquota.aspx">User Quota Lookup</a></li>
                <li><a href="admin-printingstats.aspx">Printing Stats</a></li>
              </ul>
              <div class="clr"></div>
            </div>
          </div>
        </div>
</asp:Content>

