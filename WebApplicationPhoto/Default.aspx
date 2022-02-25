<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationPhoto._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
        <div class="col-md-12">
            <h2>PNG To SQL Server Varbinary(Max) Encrypted Column</h2>
            <p>
                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AllowPaging="True" OnPageIndexChanging="DetailsView1_PageIndexChanging" OnModeChanging="DetailsView1_ModeChanging" OnItemDeleting="DetailsView1_ItemDeleting" OnItemUpdating="DetailsView1_ItemUpdating" OnItemInserting="DetailsView1_ItemInserting">
                    <Fields>
                        <%--
                        <asp:BoundField DataField="Title" HeaderText="Title:" />
                        <asp:TemplateField HeaderText="Description :">
                           <EditItemTemplate>
                              <asp:TextBox ID="TextBox1" runat="server" Columns="40" Rows="5" Text='<%# Bind("Description") %>' TextMode="MultiLine">
                              </asp:TextBox>
                           </EditItemTemplate>
                           <InsertItemTemplate>
                              <asp:TextBox ID="TextBox1" runat="server" Columns="40" Rows="5" Text='<%# Bind("Description") %>' TextMode="MultiLine">
                              </asp:TextBox>
                           </InsertItemTemplate>
                           <ItemTemplate>
                              <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'>
                              </asp:Label>
                           </ItemTemplate>
                        </asp:TemplateField>
                        --%>
                        <asp:TemplateField HeaderText="Photo">
                           <EditItemTemplate>
                              <asp:FileUpload ID="FileUpload1" runat="server" />
                           </EditItemTemplate>
                           <InsertItemTemplate>
                              <asp:FileUpload ID="FileUpload2" runat="server" />
                           </InsertItemTemplate>
                           <ItemTemplate>
                              <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("PhotoID","~/showphoto.aspx?photoid={0}") %>' />
                           </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </p>
        </div>
    </div>

</asp:Content>
