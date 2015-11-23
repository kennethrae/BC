<%@ Page Title="Edit DVD" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditDVD.aspx.cs" Inherits="KenRaeDVD.Admin.EditDVD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Here you can edit an existing DVD</h2>
    <p>
        <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
        Select a DVD to edit:<br />
        <asp:DropDownList ID="DropDownListDVD" runat="server"></asp:DropDownList>
        <asp:Button ID="ButtonDVDselect" runat="server" Text="Select" OnClick="ButtonDVDselect_Click" />
    </p>
    <p>
        <span class="widelabel">Title:</span>
        <asp:TextBox ID="TextBoxDVDtitle" runat="server" Width="250px"></asp:TextBox>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDVDtitle" runat="server" ErrorMessage="DVD Title must be entered!" ControlToValidate="TextBoxDVDtitle" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonUpdateDVD"></asp:RequiredFieldValidator>
        <br />
        <span class="widelabel">Artist:</span>
        <asp:TextBox ID="TextBoxDVDartist" runat="server" Width="250px"></asp:TextBox>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDVDartist" runat="server" ErrorMessage="Artist must be entered!" ControlToValidate="TextBoxDVDartist" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonUpdateDVD"></asp:RequiredFieldValidator>
        <br />
        <span class="widelabel">Rating:</span>
        <asp:TextBox ID="TextBoxDVDrating" runat="server"></asp:TextBox>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDVDrating" runat="server" ErrorMessage="Rating must be entered!" ControlToValidate="TextBoxDVDrating" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonUpdateDVD"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidatorDVDrating" runat="server" ErrorMessage="Rating must be between 1 and 5!" MaximumValue="5" MinimumValue="1" Type="Integer" ControlToValidate="TextBoxDVDrating" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonUpdateDVD"></asp:RangeValidator>
        <br />
        <span class="widelabel">Price:</span>
        <asp:TextBox ID="TextBoxDVDprice" runat="server"></asp:TextBox>
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDVDprice" runat="server" ErrorMessage="DVD Price must be entered!" ControlToValidate="TextBoxDVDprice" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonUpdateDVD"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="DVD Price must be in dollars and cents!" Type="Currency" Operator="DataTypeCheck" ControlToValidate="TextBoxDVDprice" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ButtonUpdateDVD"></asp:CompareValidator>
    </p>
    <p>
        <asp:Button ID="ButtonUpdateDVD" runat="server" OnClick="ButtonUpdateDVD_Click" Text="Update DVD" ValidationGroup="ButtonUpdateDVD" />
        <asp:Button ID="ButtonDeleteDVD" runat="server" OnClick="ButtonDeleteDVD_Click" Text="Delete DVD" />
    </p>
    <p>
        <asp:Button ID="ButtonLogOut" runat="server" OnClick="ButtonLogOut_Click" Text="Log Out" />
    </p>
</asp:Content>
