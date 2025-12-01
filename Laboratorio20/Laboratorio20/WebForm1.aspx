<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio20.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tabla de Multiplicar</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblNumero" runat="server" Text="Ingrese un número:"></asp:Label>
            <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
            <asp:Button ID="btnCalcular" runat="server" Text="Mostrar Tabla" OnClick="btnCalcular_Click" /><br /><br />
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
