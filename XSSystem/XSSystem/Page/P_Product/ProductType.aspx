<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true" CodeBehind="ProductType.aspx.cs" Inherits="xs_System.Page.P_Product.ProductType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <p>
        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <span class="required">*</span>产品类别名称：
        <asp:TextBox ID="txtName" runat="server"
            MaxLength="20" CssClass="inputText"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="产品类别名称不能为空" ValidationGroup="Save" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
    </p>
    <p>
        产品类别说明：<asp:TextBox ID="txtRemark" runat="server" MaxLength="100" Width="80%" CssClass="inputText"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSave" runat="server" Text="新增产品类别" CssClass="button" ValidationGroup="Save" OnClick="btnSave_Click" actionid="02,03" /> &nbsp; <asp:Button ID="btnDelete" runat="server" Text="删除产品类别" CssClass="button" OnClick="btnDelete_Click" OnClientClick="return confirm('会一起删除此类别的产品，请谨慎操作，是否继续删除？')" actionid="04" />
    </p>
</asp:Content>
