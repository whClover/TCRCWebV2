<%@ Page Title="TCRC Dashboard" MasterPageFile="~/Site.Master" Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="TCRCWebV2.index" %>

<%@ Register Src="~/Views/Shared/MenuTCRC.ascx" TagPrefix="uc1" TagName="MenuTCRC" %>

<asp:Content runat="server" ContentPlaceHolderID="MenuContent">
    <uc1:MenuTCRC runat="server" ID="MenuTCRC" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    Dashboard will be shown here, soon...
</asp:Content>