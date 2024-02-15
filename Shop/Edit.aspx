<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/BaseTemplate.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Shop.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="TxtDescription" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="TxtImage" runat="server"></asp:TextBox>
    <br />
    <asp:DropDownList ID="DrpCategories" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
    </asp:Content>
