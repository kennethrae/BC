<%@ Page Title="Add DVD" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddDVD.aspx.cs" Inherits="KenRaeDVD.Admin.AddDVD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Here you can add another DVD to the store</h2>
    <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
    <br />
    <br />
    <span class="widelabel">Title:</span>
    <asp:TextBox ID="TextBoxDVDtitle" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
    &nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDVDtitle" runat="server" ErrorMessage="DVD Title must be entered!" ControlToValidate="TextBoxDVDtitle" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonAddDVD"></asp:RequiredFieldValidator>
    <br />
    <span class="widelabel">Artist:</span>
    <asp:TextBox ID="TextBoxDVDartist" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
    &nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDVDartist" runat="server" ErrorMessage="Artist must be entered!" ControlToValidate="TextBoxDVDartist" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonAddDVD"></asp:RequiredFieldValidator>
    <br />
    <span class="widelabel">Rating:</span>
    <asp:TextBox ID="TextBoxDVDrating" runat="server"></asp:TextBox>
    &nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDVDrating" runat="server" ErrorMessage="Rating must be entered!" ControlToValidate="TextBoxDVDrating" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonAddDVD"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidatorDVDrating" runat="server" ErrorMessage="Rating must be between 1 and 5!" MaximumValue="5" MinimumValue="1" Type="Integer" ControlToValidate="TextBoxDVDrating" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonAddDVD"></asp:RangeValidator>
    <br />
    <span class="widelabel">Price:</span>
    <asp:TextBox ID="TextBoxDVDprice" runat="server"></asp:TextBox>
    &nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDVDprice" runat="server" ErrorMessage="DVD Price must be entered!" ControlToValidate="TextBoxDVDprice" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonAddDVD"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidatorDVDprice" runat="server" ErrorMessage="DVD Price must be in dollars and cents!" Type="Currency" Operator="DataTypeCheck" ControlToValidate="TextBoxDVDprice" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonAddDVD"></asp:CompareValidator>
    <br />
    <br />
    <asp:Button ID="ButtonAddDVD" runat="server" OnClick="ButtonAddDVD_Click" Text="Add DVD" Width="110px" ValidationGroup="ButtonAddDVD" />
    <br />
    <br />
    <asp:Button ID="ButtonLogOut" runat="server" OnClick="ButtonLogOut_Click" Text="Log Out" />
    <br />
</asp:Content>
