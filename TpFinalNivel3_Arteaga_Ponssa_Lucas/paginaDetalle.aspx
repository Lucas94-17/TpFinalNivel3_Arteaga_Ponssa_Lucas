<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="paginaDetalle.aspx.cs" Inherits="TpFinalNivel3_Arteaga_Ponssa_Lucas.Pagina_detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card" style="width: 30rem;">
        <contenttemplate>
            <div class="card-body">
                <asp:Label runat="server" ID="lblNombre"></asp:Label>
                <div>
                    <asp:Image runat="server" ID="imgArticulo" Width="60%" /></div>
                <asp:Label CssClass="card-text" ID="lblDescripcion" runat="server"></asp:Label>
            </div>
        </contenttemplate>
    </div>
</asp:Content>
