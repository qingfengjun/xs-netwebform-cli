<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="XSSystem.Page.P_Public.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table style="width: 90%">
        <tr>
            <td width="20%">
                原密码：
            </td>
            <td width="80%">
                <asp:TextBox ID="txtOldPassword" runat="server" CssClass="inputText" Width="90%"
                    TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                新密码：
            </td>
            <td>
                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="inputText" Width="90%"
                    TextMode="Password"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        runat="server" ErrorMessage="请输入修改后的密码" ForeColor="Red" ControlToValidate="txtNewPassword" ValidationGroup="Save"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                再次输入密码：
            </td>
            <td>
                <asp:TextBox ID="txtAgain" runat="server" CssClass="inputText" Width="90%" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="button" 
            onclick="btnSave_Click" ValidationGroup="Save" /></div>
</asp:Content>
