<%@ Page Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="CreditsCheck.aspx.cs" Inherits="CreditsCheck" Title="Credits Check - Intra University Computer Labs - Colorado State University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PMP %>"
    SelectCommand="SELECT [UserID],[UserName],[TotalPagesPrinted],(1000 - TotalPagesPrinted) AS Remaining,[Balance] From UserQuotas WHERE UserName=@UserName"
     OnSelected="SqlDataSource1_OnSelected">
        <SelectParameters>
            <asp:Parameter Name="UserName" DefaultValue="0" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="left">
          <div class="left_top">
            <div class="left_bottom">
              <h2>Printing Credits for <asp:Literal ID="Literal1" runat="server"></asp:Literal></h2>
                <div style="padding-left:50px;">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                    AutoGenerateColumns="false" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="eName" 
                            SortExpression="UserName" />
                        <asp:BoundField DataField="TotalPagesPrinted" HeaderText="Pages Printed" 
                            SortExpression="TotalPagesPrinted" />
                        <asp:BoundField DataField="Remaining" HeaderText="Remaining Pages" 
                            SortExpression="Remaining" />
                        <asp:BoundField DataField="Balance" HeaderText="Balance (Out of 50)" 
                            SortExpression="Balance" />
                    </Columns>
                </asp:GridView>
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </div>
              <div class="clr"></div>
            </div>
          </div>
        </div>
    
</asp:Content>

