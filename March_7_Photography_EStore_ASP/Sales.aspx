<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="sales.aspx.cs" Inherits="Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpSidebar" Runat="Server">
     <h1 class="catsbarlink"><a href="catalogue.aspx">Order Now</a></h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpContent" Runat="Server">
    <h1>Return Policy</h1>
    <p>Our return policy is simple. If you are not happy with your canvas print, ship it back to us within 30 days of receiving it along with the following information and we will either ship you a replacement print or refund the charge for the print.</p> 
 
    <h1>Information to include with Returns:</h1>
 
    <ul>
        <li>Full Name</li> 
        <li>Address </li>
        <li>Phone Number </li>
        <li>Email </li>
        <li>Order Number</li>  
        <li>Refund/Replacement Print desired</li>
    </ul>
 
    <ul>
        <li>Please ship to:</li> 
        <li> 123 William St.</li>
        <li>Squamish BC</li>
        <li>V8B 0H6</li>
    </ul>

</asp:Content>

