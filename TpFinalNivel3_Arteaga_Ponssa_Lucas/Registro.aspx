﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TpFinalNivel3_Arteaga_Ponssa_Lucas.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <div class="form-control " data-bs-theme="dark">
        <div class="mb-3">
            <label for="lblEmail" class="form-label">Correo Electrónico</label>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Ingrese un Email !"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <label for="lblPassword" class="form-label">Contraseña</label>
            <asp:TextBox runat="server" ID="txtPass" TextMode="Password" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtPass"
                ErrorMessage="La contraseña es necesaria!"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <label for="lblNombre" class="form-label">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ControlToValidate="txtNombre"
                ErrorMessage="El nombre es necesario"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <label for="lblApellido" class="form-label">Apellido</label>
            <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                ControlToValidate="txtApellido"
                ErrorMessage="El Apellido es necesario! "
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="mb-3">
                    <label for="lblImagenUrl" class="form-label">Url Imagen de Perfil</label>
                    <asp:TextBox runat="server" ID="txtUrlImagen" OnTextChanged="txtUrlImagen_TextChanged" CssClass="form-control"
                        AutoPostBack="true"></asp:TextBox>
                </div>
                <asp:Image runat="server" ID="imgArticulo" Width="60%" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
            ControlToValidate="txtUrlImagen"
            ErrorMessage="Es necesario la url de una imagen"
            ForeColor="Red">
        </asp:RequiredFieldValidator>
        <asp:Button runat="server" Text="Registrarse" ID="btnRegistro" OnClick="btnRegistro_Click" CssClass="btn btn-success"/>
    </div>
</asp:Content>
