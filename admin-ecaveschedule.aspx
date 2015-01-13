<%@ Page Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="admin-ecaveschedule.aspx.cs" Inherits="admin" Title="eCave Schedule - Admin - Intra University Computer Labs - Colorado State University" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" href='/support/css/weekly_screen.css' type="text/css" media="screen, projection" />
<script type="text/javascript">
    $(document).ready(function() {
        $('.usershift').parent().css({ 'background-color': '#00dd00' });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="left">
          <div class="left_top">
            <div class="left_bottom">
              <h2>eCave Schedule</h2>
              <p><a href="admin.aspx">Back to Admin</a></p>
                <table cellspacing="0">
                    <colgroup>
                        <col />
                        <col id="Sun" />
                        <col id="Mon" />
                        <col id="Tue" />
                        <col id="Wed" />
                        <col id="Thu" />
                        <col id="Fri" />
                        <col id="Sat" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th class="blank">&nbsp;</th>
                            <th scope="col">Sun</th>
                            <th scope="col">Mon</th>
                            <th scope="col">Tues</th>
                            <th scope="col">Wed</th>
                            <th scope="col">Thurs</th>
                            <th scope="col">Fri</th>
                            <th scope="col">Sat</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </tbody>
                </table>
              <div class="clr"></div>
            </div>
          </div>
        </div>
</asp:Content>

