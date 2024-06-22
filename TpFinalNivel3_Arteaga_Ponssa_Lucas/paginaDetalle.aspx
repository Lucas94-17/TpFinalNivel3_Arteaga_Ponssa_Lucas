<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="paginaDetalle.aspx.cs" Inherits="TpFinalNivel3_Arteaga_Ponssa_Lucas.Pagina_detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card" style="width: 30rem;">
        <contenttemplate>
            <div class="card-body">
                <asp:Label runat="server" ID="lblNombre"></asp:Label>
                <div>
                    <%--<img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="..." id="imgEstilo" onerror='handleImageError(this, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr64U1qrn_mnXFwQoOmiuJs1zp0aLvApc1WmtDk-_IywS0eg7pzlSCsqDNbUzJuPSRupo&usqp=CAU")'>--%>
                    
                    <asp:Image runat="server" ID="imgArticulo" Width="60%" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr64U1qrn_mnXFwQoOmiuJs1zp0aLvApc1WmtDk-_IywS0eg7pzlSCsqDNbUzJuPSRupo&usqp=CAU"/>
                </div>
                <asp:Label CssClass="card-text" ID="lblDescripcion" runat="server"></asp:Label>
            </div>
        </contenttemplate>
    </div>
</asp:Content>
