<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="KenRaeDVD.Admin.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>This page shows Reports</h1>
    <p>
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Log Out" />&nbsp;
        <asp:Button ID="ButtonCustomers" runat="server" OnClick="ButtonCustomers_Click" Text="List Customers" />&nbsp;
        <asp:Button ID="ButtonOrders" runat="server" OnClick="ButtonOrders_Click" Text="List Orders" ValidationGroup="ButtonOrders" />
        For Customer #:
        <asp:TextBox ID="TextBoxCustNum" runat="server" Width="40px"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCustNum" runat="server" ErrorMessage="Please enter a Customer #!" ControlToValidate="TextBoxCustNum" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonOrders"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidatorCustNum" runat="server" ErrorMessage="Customer # must be a positive integer!" Type="Integer" Operator="DataTypeCheck" ControlToValidate="TextBoxCustNum" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonOrders"></asp:CompareValidator>
    </p>

    <h2>Customer List</h2> 
    <asp:Repeater id="CustomerRepeater" runat="server">
       <ItemTemplate> 
          <span class="widelabel2">Customer ID:</span>
          <strong><%#Eval("CustomerID")%></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <span class="widelabel2">First Name:</span>
          <strong><%#Eval("FirstName")%></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <span class="widelabel2">Last Name:</span>
          <strong><%#Eval("LastName")%></strong><br />
       </ItemTemplate> 
       <SeparatorTemplate> 
          <hr /> 
       </SeparatorTemplate>  
    </asp:Repeater>

    <br />

    <h2>Order List</h2> 
    <asp:Repeater id="OrderRepeater" runat="server">
       <ItemTemplate> 
          <span class="widelabel2">Customer ID:</span>
          <strong><%#Eval("CustomerID")%></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <span class="widelabel2">Order ID:</span>
          <strong><%#Eval("OrderID")%></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <span class="widelabel2">DVD ID:</span>
          <strong><%#Eval("DVDID")%></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <span class="widelabel2">Title:</span>
          <strong><%#Eval("DVDtitle")%></strong><br />
       </ItemTemplate> 
       <SeparatorTemplate> 
          <hr /> 
       </SeparatorTemplate>  
    </asp:Repeater>
    
</asp:Content>
