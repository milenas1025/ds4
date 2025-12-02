<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Parcial3._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Preguntas y Respuestas</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin:20px;">

            <h2>Preguntas</h2>

            <asp:Repeater ID="RepeaterPreguntas" runat="server">
                <ItemTemplate>
                    <asp:Button 
                        ID="btnPregunta" 
                        runat="server" 
                        Text='<%# Eval("Pregunta") %>' 
                        CommandArgument='<%# Eval("Id") %>' 
                        OnClick="btnPregunta_Click" 
                        Width="500px"
                        Style="margin-bottom:10px;" />
                    <br/>
                </ItemTemplate>
            </asp:Repeater>

            <br/><br/>

            <h3>Respuesta:</h3>
            <asp:Label ID="LabelRespuesta" runat="server" Font-Size="18px"></asp:Label>

        </div>
    </form>
</body>
</html>
