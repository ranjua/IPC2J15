<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Gestion_Cobros.aspx.cs" Inherits="ProyectoIPC2.Administrador.Gestion_Cobros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/CSS/Botones.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Perfil.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Tipo de Cobro"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Porcentaje de Cobro"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="habilitado"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="Ddl_Tipo_Impuesto" runat="server" OnSelectedIndexChanged="Ddl_Tipo_Impuesto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                        <td>
                            <asp:TextBox ID="Txt_Impuesto_Porcentaje" runat="server" TextMode="Number" placeholder="Porcentaje de Impuesto"></asp:TextBox></td>
                        <td>
                            <asp:CheckBox ID="Cbx_Impuesto_DHab" runat="server"  /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Cobro por Libra"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="Txt_Peso_Cobro" runat="server" placeholder="Cobro por Libra"></asp:TextBox></td>
                        <td>
                            <asp:CheckBox ID="Cbx_Peso_DHab" runat="server"  /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Comision"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="Txt_Comision_Porcentaje" runat="server" placeholder="Porcentaje de Comision"></asp:TextBox></td>
                        <td>
                            <asp:CheckBox ID="Cbx_Comision_DHab" runat="server"  /></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="Btn_Modificar" runat="server" Text="Modificar Valores" OnClick="Btn_Modificar_Click" /></td>
                    </tr>
                </table>
            </td>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Agregar un Nuevo Impuesto"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_Nombre_Impuesto" runat="server" placeholder="Nombre de Impuesto" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="Txt_Porcentaje_Nuevo_Impuesto" runat="server" TextMode="Number" placeholder="Porcentaje %"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Btn_Agregar_Impuesto" runat="server" Text="Agregar Impuesto" OnClick="Btn_Agregar_Impuesto_Click" /></td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>


</asp:Content>
