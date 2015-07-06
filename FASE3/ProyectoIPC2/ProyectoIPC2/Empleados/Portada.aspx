<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Portada.aspx.cs" Inherits="ProyectoIPC2.Empleados.Portada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Bienvenido al Panel de Empleados de Quetzal Express" CssClass="TLetraVerde"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Image ID="Image1" runat="server" Height="527px" ImageAlign="Middle" ImageUrl="~/Img/Q.jpg" Width="389px" />
</asp:Content>
