<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/BaseTemplate.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Shop.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <h2 id="TtlName" runat="server"></h2>
    <h3 id="LblCategory" runat="server"></h3>
    <img id="ImgProduct" runat="server" />
    <p id="ParContent" runat="server"></p>
    <a class="btn btn-primary" href="Index.aspx">Index</a>
    <a id="BtnAnchorEdit" class="btn btn-warning" runat="server" href="">Edit anchor</a>
    <asp:Button ID="BtnEdit" runat="server" Text="Edit" CssClass="btn btn-warning" OnClick="BtnEdit_Click" />
    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="BtnDelete_Click" />
</asp:Content>
