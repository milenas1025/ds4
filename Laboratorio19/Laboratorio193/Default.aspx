<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio193._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Laboratorio 19-3 – Consumir API REST (Dato específico)</h2>

    <asp:Button ID="btnCargarTodos" runat="server" Text="Cargar Todos" OnClick="btnCargarTodos_Click" />

    <asp:Button ID="btnCargarID2" runat="server" Text="Cargar ID 2" OnClick="btnCargarID2_Click" />

    <br /><br />

    <asp:GridView ID="GridDatos" runat="server"></asp:GridView>

</asp:Content>
