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

    <div class="row">
        <div class="col-md-12">
            <P>Encrypted Patient Fields</P>

            <table>
                <tr>
                    <td>First Name</td>
                    <td><asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td><asp:TextBox ID="tbLastName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Birth Year</td>
                    <td>
                        <asp:DropDownList ID="ddlBirthYear" runat="server">
                            <asp:ListItem>1996</asp:ListItem>
                            <asp:ListItem>1997</asp:ListItem>
                            <asp:ListItem>1998</asp:ListItem>
                            <asp:ListItem>1999</asp:ListItem>
                            <asp:ListItem>2000</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Birth Month</td>
                    <td>
                        <asp:DropDownList ID="ddlBirthMonth" runat="server">
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Birth Day</td>
                    <td>
                        <asp:DropDownList ID="ddlBirthDay" runat="server">
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
               
            </table>

            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <p></p>
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>
