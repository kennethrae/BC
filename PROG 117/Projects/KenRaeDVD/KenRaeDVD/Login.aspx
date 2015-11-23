<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KenRaeDVD.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Please Login Here</h2>
    <asp:Label ID="LabelErrorMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    <p> 
        Username:<br /> 
        <asp:TextBox id ="TextBoxUsername" runat ="server" />
        &nbsp;
        <asp:RequiredFieldValidator id ="usernameReq" runat ="server" 
            ControlToValidate ="TextBoxUsername"  SetFocusOnError = "true"
            ErrorMessage ="Please enter your Username." ForeColor="Red"  /> 
    </p> 
    <p> 
        Password:<br />
        <asp:TextBox id ="TextBoxPassword" runat ="server" TextMode ="Password" />
        &nbsp;
        <asp:RequiredFieldValidator id ="passwordReq" runat ="server" 
            ControlToValidate ="TextBoxPassword" SetFocusOnError = "true"
            ErrorMessage ="Please enter your Password."  ForeColor="Red" />
    </p> 
    <p>
        <asp:Button id ="ButtonSubmit" runat ="server" Text ="Login" OnClick="ButtonSubmit_Click" />
    </p>

</asp:Content>
