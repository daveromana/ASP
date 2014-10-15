<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpSidebar" Runat="Server">
    <h1 class="catsbarlink"><a href="Cart.aspx">Go to your Cart</a></h1>
   
     <div id="divOutput" runat="server" class="important">
        <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpContent" Runat="Server">
    <h1><asp:Label ID="lblName" runat="server" /></h1>
    <div>
        <img id="imgProduct" runat="server" />
    </div>
    <div>
        <asp:Label ID="lblDescription" runat="server" CssClass="defhead"></asp:Label>
    </div>
    <div>
        Only <asp:Label ID="lblPrice" runat="server" Font-Size="20px"></asp:Label>
    </div>
    <div> <asp:Button ID="Button1" runat="server" Text="Buy Me!!" OnClick="Button1_Click" Width="175" Height="50" Font-Size="20px" BackColor="white" /></div>
    <div>
        <a href="Catalogue.aspx">Back to Catalogue</a>
    </div>
</asp:Content>


