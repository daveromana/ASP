<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpSidebar" Runat="Server">
      <h1 class="catsbarlink"><a href="Catalogue.aspx">Keep Shopping</a></h1>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpContent" Runat="Server">
    <asp:Label ID="lblOutput" runat="server"></asp:Label>

    <div  class="col">
    <asp:GridView AutoGenerateColumns ="False" ID="gvCart" runat="server" Height="94px" Width="688px" OnRowDeleting="gvCart_RowDeleting" OnRowDataBound="gvCart_RowDataBound" ForeColor="#333333" GridLines="None" ShowFooter="true">
       
         <AlternatingRowStyle CssClass="col" />
         <RowStyle CssClass="col2" />
        
             <Columns>
            <asp:TemplateField HeaderText="Product">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("product.name") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <div>Subtotal:</div>
                    <div>Tax:</div>
                    <div>Total:</div>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="quantity" HeaderText="Qty" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="product.amount" HeaderText="Price" ItemStyle-HorizontalAlign="Right" >
<ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
                <FooterStyle BackColor="#7e7d7d" HorizontalAlign="Right" />
                <FooterTemplate>
                    <div><asp:Label ID="lblSubtotal" runat="server"></asp:Label></div>
                    <div><asp:Label ID="lblTax" runat="server"></asp:Label></div>
                    <div><asp:Label ID="lblTotal" runat="server"></asp:Label></div>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:ButtonField Text="Remove" CommandName="delete" />
        </Columns>      
       
    </asp:GridView>

</div>


    <asp:Panel ID="pnlCheckout" runat="server" Visible="false"></asp:Panel>


    
    <div class="form">Name:
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Please provide your name." ControlToValidate="txtName" CssClass="error" SetFocusOnError="true">*</asp:RequiredFieldValidator>
    </div>
    
    <div class="form">Address:
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Please provide an address." ControlToValidate="txtAddress" CssClass="error" SetFocusOnError="true">*</asp:RequiredFieldValidator>
    </div>

    <div class="form">Email:
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please provide a valid email address." ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" ControlToValidate="txtEmail" CssClass="error">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="rvfEmail" runat="server" ErrorMessage="Email Required"  CssClass="error" SetFocusOnError="true" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
    </div>

        <div class="form">
            Telephone:
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
               <asp:RegularExpressionValidator ID="revTel" runat="server" ErrorMessage="Please provide a valid Telephone number" ValidationExpression="^(1\s*[-\/\.]?)?(\((\d{3})\)|(\d{3}))\s*[-\/\.]?\s*(\d{3})\s*[-\/\.]?\s*(\d{4})\s*(([xX]|[eE][xX][tT])\.?\s*(\d+))*$" ControlToValidate="txtPhone" CssClass="error">*</asp:RegularExpressionValidator>
               <asp:RequiredFieldValidator ID="rfvTel" runat="server" ErrorMessage="Telephone Number required." ControlToValidate="txtPhone">*</asp:RequiredFieldValidator>
        </div>
        
    <div><asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" Width="175" Height="50" Font-Size="20px" BackColor="white" />

        <asp:ValidationSummary ID="vsSummary" runat="server" />
    </div>
</asp:Content>