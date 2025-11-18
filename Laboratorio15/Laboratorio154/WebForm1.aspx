<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio154.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Introduzca dos números</div>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="141px"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Resultado"></asp:Label>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 120px" Text="Suma" Width="174px" />
        </p>
    </form>
</body>
</html>
