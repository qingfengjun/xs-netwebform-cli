<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="News_Edit.aspx.cs" Inherits="XSSystem.Page.P_News.News_Edit" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <p>
        <span class="required">*</span>新闻标题：<asp:TextBox ID="txtTitle" runat="server" CssClass="inputText"
            Width="70%" MaxLength="100"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入新闻标题"
            ForeColor="Red" ValidationGroup="Save" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
    </p>
    <p>
        <span class="required">*</span>新闻类别：<asp:DropDownList ID="ddlNewType" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="无新闻类别，请先添加类别"
            ForeColor="Red" ValidationGroup="Save" ControlToValidate="ddlNewType"></asp:RequiredFieldValidator>
    </p>
    <p>
        新闻等级：
        <asp:DropDownList ID="ddlSort" runat="server">
            <asp:ListItem Value="1">一般</asp:ListItem>
            <asp:ListItem Value="2">重要</asp:ListItem>
            <asp:ListItem Value="3">非常重要</asp:ListItem>
            <asp:ListItem Value="0">无关</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <span class="required">*</span>新闻内容：</p>
    <p style="height: 700px">
        <asp:TextBox ID="txtContent" runat="server" CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSave" runat="server" Text="新增" CssClass="button" 
            ValidationGroup="Save" onclick="btnSave_Click" actionid="02" />
        <asp:Button ID="btnModify" runat="server"
                Text="维护" CssClass="button" onclick="btnModify_Click" ValidationGroup="Save" actionid="03" />
        <asp:HiddenField ID="hidID" runat="server" />
    </p>
</asp:Content>
