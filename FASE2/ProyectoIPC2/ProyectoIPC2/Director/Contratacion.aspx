<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Contratacion.aspx.cs" Inherits="ProyectoIPC2.Director.Contratacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
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
                            <asp:Label ID="Label1" runat="server" Text="Contratar Empleado"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Archivo con Empledos"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_Nombre" runat="server" palceholder="Nombre"></asp:TextBox>
                        </td>
                        <td>
                            <asp:FileUpload ID="Flu_Archivo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_Apellido" runat="server" placehorlder="Apellido"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="Btn_Contratar_CSV" runat="server" Text="Agregar"  OnClick="Btn_Contratar_CSV_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_Sueldo" runat="server" TextMode="Number" placeHolder="Sueldo"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Btn_Contratar" runat="server" Text="Contratar" OnClick="Btn_Contratar_Click1" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Lbl_Mensaje" runat="server" ></asp:Label>
                        </td>
                        <td></td>
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
