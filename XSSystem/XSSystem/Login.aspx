<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="xs_System.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="js/jquery-1.8.0.js" type="text/javascript"></script>
    <link href="/style/Login.css" rel="stylesheet" />
    <title>后台系统登录</title>
    <script type="text/javascript">
        function Checked() {
            if ($("#txtAdmin").val().length == 0) {
                $("#lblMsg").text("账号不能为空白");
                return false;
            }
            if ($("#txtPassword").val().length == 0) {
                $("#lblMsg").text("密码不能为空白.");
                return false;
            }
            if ($("#txtAuth").val().length == 0) {
                $("#lblMsg").text("验证码不能为空白.");
                return false;
            }
            return true;

        }
    </script>
</head>
<body>
    <div id="nav">
        后台管理系统登录</div>
    <div id="nav1">
    </div>
    <div id="main">
        <div id="img">
        </div>
        <div id="login">
            <form id="form1" runat="server">
            <table class="logintable">
                <tbody>
                    <tr>
                        <td>
                            账号
                        </td>
                        <td>
                            <input id="txtAdmin" type="text" class="logininput" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密码
                        </td>
                        <td>
                            <input id="txtPassword" type="password" class="logininput" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            验证码
                        </td>
                        <td>
                            <asp:TextBox ID="txtAuth" runat="server" Width="150" CssClass="logininput"></asp:TextBox>
                            <img src="/Page/P_Public/YZM.aspx" alt="验证码" onclick="this.src='/Page/P_Public/YZM.aspx?'+ Math.random()"
                                width="50" height="25" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="chkRemember" runat="server" Text="下次自动登陆" />
                            <asp:DropDownList ID="ddlTime" runat="server">
                                <asp:ListItem Value="1">十天</asp:ListItem>
                                <asp:ListItem Value="2">一个月</asp:ListItem>
                                <asp:ListItem Value="3">半年</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnLogin" runat="server" CssClass="loginbtn" Text="登录" OnClick="btnLogin_Click"
                                OnClientClick="return Checked()" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                </tbody>
            </table>
            </form>
        </div>
    </div>
</body>
</html>
