<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="ShowUsers.aspx.cs" Inherits="ErrorHandlingWebForm.ShowUsers" %>
<%--ErrorPage="~/ServerError.aspx" should be written in PAge tag if you want customize errorpage just for this page--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <br />
<%--    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>--%>
</asp:Content>
