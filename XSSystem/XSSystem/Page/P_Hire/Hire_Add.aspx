<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="Hire_Add.aspx.cs" Inherits="xs_System.Page.P_Hire.Hire_Add" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <p>
        职位名称：<asp:TextBox ID="txtName" runat="server" MaxLength="20" CssClass="inputText" Width="50%"></asp:TextBox>
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
    <p>
        模板选择：
        <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"
            AutoPostBack="true">
        </asp:DropDownList>
    </p>
    <p>
        内容：</p>
    <p style="height: 760px">
        <asp:TextBox ID="txtRemark" runat="server" CssClass="ckeditor" TextMode="MultiLine"
            Height="600px"></asp:TextBox>
    </p>
    <div>
        <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="button" OnClick="btnAdd_Click"
            ValidationGroup="update" />
        <input id="brnCancle" type="button" value="返回" class="buttonCancle" onclick="seturl('/Page/P_Hire/Hire.aspx')" />
    </div>
</asp:Content>
