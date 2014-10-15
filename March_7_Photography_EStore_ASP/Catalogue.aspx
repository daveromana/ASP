<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="catalogue.aspx.cs" Inherits="Catalogue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpSidebar" Runat="Server">
      <h1 class="catsbarlink"><a href="Cart.aspx">Go to your Cart</a></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpContent" Runat="Server">
    <div id="divOutput" runat="server" class="important">
         <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
    </div>
    <div>

       <asp:Table id="catalogTable" 
            GridLines="none"
            BackColor="AliceBlue"
            HorizontalAlign="Center" 
            Font-Names="Verdana" 
            Font-Size="12pt" 
            CellPadding="15" 
            CellSpacing="0" 
            Runat="server"
            CssClass="catalogStyle"/>
    </div>
    
   

</asp:Content>