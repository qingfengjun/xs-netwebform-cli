<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="Hire_Update.aspx.cs" Inherits="xs_System.Page.P_Hire.Hire_Update"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <p>
        职位名称：<asp:TextBox ID="txtName" runat="server" MaxLength="20" CssClass="inputText"
            Width="50%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="职位名称不能为空"
            ForeColor="Red" ControlToValidate="txtName" ValidationGroup="update"></asp:RequiredFieldValidator>
    </p>
    <p>
        招聘人数：<asp:TextBox ID="txtCount" runat="server" MaxLength="10" CssClass="inputText"
            Width="50%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="招聘人数不能为空"
            ForeColor="Red" ControlToValidate="txtCount" ValidationGroup="update"></asp:RequiredFieldValidator>
    </p>
    <p>
        工作地点：<asp:TextBox ID="txtPlace" runat="server" MaxLength="20" CssClass="inputText"
            Width="50%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="工作地点不能为空"
            ForeColor="Red" ControlToValidate="txtPlace" ValidationGroup="update"></asp:RequiredFieldValidator>
    </p>
    <p style="height: 720px">
        内容：
        <asp:TextBox ID="txtRemark" runat="server" CssClass="ckeditor" TextMode="MultiLine"
            Height="600px"></asp:TextBox>
    </p>
    <div>
        <asp:Button ID="btnModify" runat="server" Text="更新" CssClass="button" ValidationGroup="update"
            OnClick="btnModify_Click" />
        <input id="brnCancle" type="button" value="返回" class="buttonCancle" onclick="seturl('/Page/P_Hire/Hire.aspx')" />
    </div>
</asp:Content>
