<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="Message.aspx.cs" Inherits="XSSystem.Page.P_Message.Message" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <p>
        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p style="height: 720px">
        <asp:TextBox ID="txtRemark" runat="server" CssClass="ckeditor" TextMode="MultiLine"
            Height="600px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnUpdate" runat="server" Text="更新" OnClick="btnUpdate_Click" CssClass="button" actionid="03" />
    </p>
</asp:Content>
