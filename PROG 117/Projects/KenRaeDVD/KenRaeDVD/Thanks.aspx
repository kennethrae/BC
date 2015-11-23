<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Thanks.aspx.cs" Inherits="KenRaeDVD.Thanks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Thank you for your order </h1> 
    <asp:Label ID="LabelFirstName" runat="server"></asp:Label>
    <asp:Label ID="LabelLastName" runat="server"></asp:Label>
    your Customer Number is: <asp:Label ID="LabelCustNum" runat="server"></asp:Label>
    <br />
    Your movie is: <asp:Label ID="LabelTitle" runat="server"></asp:Label>
    <br />
    You paid: <asp:Label ID="LabelPaid" runat="server"></asp:Label>
    <br />
    <br />

    <asp:Label ID="LabelStatus" runat="server"></asp:Label>

</asp:Content>
