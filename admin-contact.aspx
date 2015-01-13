<%@ Page Title="" Language="C#" MasterPageFile="~/support/MasterPage.master" AutoEventWireup="true" CodeFile="admin-contact.aspx.cs" Inherits="admin_contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="support/css/table.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="left">
          <div class="left_top">
            <div class="left_bottom">
              <h2>Edit Staff Contact Information</h2>
              <p><a href="admin.aspx">Back to Admin</a></p>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ connectionStrings:Lab %>"
                SelectCommand="SELECT * FROM LabContact ORDER BY name"
                UpdateCommand="UPDATE LabContact SET name=@name, phone=@phone, email_addres=@email_address, date_modified=@date_modified WHERE id=@id"
                DeleteCommand="DELETE FROM LabContact WHERE id=@id"
                InsertCommand="INSERT INTO LabContact (name, phone, email_address, date_modified) VALUES (@name, @phone, @email_address, @date_modified)" 
                OnInserting="SqlDataSource1_Inserting">
                    <UpdateParameters>
                        <asp:Parameter Name="name" />
                        <asp:Parameter Name="phone" />
                        <asp:Parameter Name="email_address" />
                        <asp:Parameter Name="date_modified" DefaultValue='<%=DateTime.Now %>' />
                        <asp:Parameter Name="id" />
                    </UpdateParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="id" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="name" />
                        <asp:Parameter Name="phone" />
                        <asp:Parameter Name="email_address" />
                        <asp:Parameter Name="date_modified" DefaultValue='<%=DateTime.Now %>' />
                    </InsertParameters>
                </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
                    EnableModelValidation="True" DataKeyNames="id" ShowFooter="true" AutoGenerateColumns="false" OnRowCommand="GridView1_OnRowCommand">
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
                            <FooterTemplate>
                                <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="InsertNew"
                                    ImageUrl="support/images/16-em-plus.png" Text="Insert"/>
                            </FooterTemplate>
                            <ItemStyle Width="75px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" SortExpression="name">
                            <ItemTemplate>
                                <%# Eval("name") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertName" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone" SortExpression="phone">
                            <ItemTemplate>
                                <%# Eval("phone") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("phone") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertPhone" runat="server" Text='<%# Bind("phone") %>'></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email Address" SortExpression="email_address">
                            <ItemTemplate>
                                <%# Eval("email_address") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("email_address") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="InsertEmailAddress" runat="server" Text='<%# Bind("email_address") %>'></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
              <div class="clr"></div>
            </div>
          </div>
        </div>
</asp:Content>

