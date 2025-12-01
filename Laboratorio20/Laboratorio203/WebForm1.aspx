<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio203.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Laboratorio 203</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <!-- CAMPOS -->
            <asp:Label ID="Label1" runat="server" Text="Código del producto:"></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="Label2" runat="server" Text="Nombre del producto:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="Label3" runat="server" Text="Precio:"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br /><br />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <br /><br />

            
            <asp:Label ID="Label4" runat="server" Text="Buscar por Código:"></asp:Label>
            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            <br /><br />

            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="true"></asp:GridView>

        </div>
    </form>
</body>
</html>
