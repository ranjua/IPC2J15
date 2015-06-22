<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Registro_de_Paquetes.aspx.cs" Inherits="ProyectoIPC2.Empleados.Registro_de_Paquetes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

.Txt_info 
{
    margin:auto;
    text-align:center;
    font-family:Tahoma;
    font-size:2em;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Registar Paquete" CssClass="Txt_info"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Cargar CSV con Paquetes" CssClass="Txt_info"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                <asp:TextBox ID="Txt_Precio" runat="server" CssClass="Txt_info" placeholder="Precio de Producto en Q"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                <asp:TextBox ID="Txt_Libras" runat="server" CssClass="Txt_info" placeholder="Peso en Libras"></asp:TextBox>
                        </td>
                        <td>
                            <asp:FileUpload ID="Flu_Archivo" CssClass="TxtGen" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
               <asp:DropDownList ID="Ddl_Tipo_Impuesto" CssClass="Txt_info" runat="server" Width="344px"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Lbl_Mensaje" runat="server"  CssClass="TxtCod"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_Casilla" CssClass="Txt_info" runat="server" placeholder="Casilla de Cliente"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                        <asp:Button ID="Btn_Registrar" runat="server" CssClass="button-jumbo button-flat-royal" Text="Registrar Paquete" OnClick="Btn_Registrar_Click" />
                        </td>
                        <td>
                        <asp:Button ID="Btn_Cargar_CSV" runat="server" CssClass="button-jumbo button-flat-highlight" Text="Cargar Archivo con Paquetes" OnClick="Btn_Cargar_CSV_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
