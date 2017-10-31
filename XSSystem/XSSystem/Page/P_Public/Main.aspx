<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="Main.aspx.cs" Inherits="xs_System.Page.P_Public.Main1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <p>
        系统说明</p>
    <div>
        本后台系统主要功能有
        <ul>
            <li>管理公司说明</li>
            <li>管理联系方式</li>
            <li>管理新闻</li>
            <li>管理招聘信息</li>
            <li>管理用户，为每个用户设定功能权限</li>
        </ul>
    </div>
    <div>
        系统开发说明
        <ul>
            <li>开发技术：asp.net+sql server</li>
            <li>版本信息：V0.1</li>
        </ul>
    </div>
</asp:Content>
