<%@ Page Title="The DVD Store" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="KenRaeDVD._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Please browse the list of DVD’s.</h2>
    <h1>DVD Directory</h1> 
    <asp:DataList id="DVDRepeater" runat="server" OnItemCommand="DVDRepeater_ItemCommand">
       <ItemTemplate> 
          <span class="widelabel">Title:</span>
          <strong><%#Eval("DVDtitle")%></strong><br />
          <span class="widelabel">Artist:</span>
          <strong><%#Eval("DVDartist")%></strong><br />
          <span class="widelabel">Rating:</span>
          <strong><%#Eval("DVDRating")%></strong><br />
          <span class="widelabel">Price:</span>
          <strong><%#Eval("DVDprice", "{0:C}")%></strong><br />
          <asp:LinkButton ID ="DetailsButton" runat ="server" 
             Text="Details"
             CommandName ="DVDdetails" 
             CommandArgument = <%# Eval("DVDID")%> ForeColor="#FF3399" />
          <asp:LinkButton ID ="LinkButtonBuy" runat ="server" 
             Text="Buy"
             CommandName ="BuyDVD" 
             CommandArgument = <%# Eval("DVDID")%> ForeColor="#FF3399" />
       </ItemTemplate> 

       <SeparatorTemplate> 
          <hr /> 
       </SeparatorTemplate>  

    </asp:DataList>


</asp:Content>
