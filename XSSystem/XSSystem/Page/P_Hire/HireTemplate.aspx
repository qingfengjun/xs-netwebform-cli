<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="HireTemplate.aspx.cs" Inherits="xs_System.Page.P_Hire.HireTemplate"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <p>
        <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"
            AutoPostBack="true">
        </asp:DropDownList>
        <asp:Button ID="btnDelete" runat="server" Text="删除招聘模板" CssClass="button buttonDelete"
            OnClick="btnDelete_Click" actionid="04" />
    </p>
    <p>
        模板名称: &nbsp;<asp:TextBox ID="txtName" runat="server" Width="50%" MaxLength="20" CssClass="inputText"></asp:TextBox>
    </p>
    <div style="height: 700px">
        <asp:TextBox ID="txtTemplate" runat="server" CssClass="ckeditor" TextMode="MultiLine"
            Height="680px"></asp:TextBox>
    </div>
    <p>
        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="button" OnClick="btnSave_Click"
            actionid="02,03" /></p>
    <asp:HiddenField ID="hidType" runat="server" Value="add" />
</asp:Content>
