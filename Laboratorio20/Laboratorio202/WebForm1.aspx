<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio202.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Matriz Diagonal Inversa</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblN" runat="server" Text="Ingrese N: "></asp:Label>
            <asp:TextBox ID="txtN" runat="server"></asp:TextBox>

            <asp:Button ID="btnGenerar" runat="server" 
                        Text="Generar Matriz" 
                        OnClick="btnGenerar_Click" />
            <br /><br />

            <asp:Literal ID="litMatriz" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>