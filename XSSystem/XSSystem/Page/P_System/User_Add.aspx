<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true" CodeBehind="User_Add.aspx.cs" Inherits="xs_System.Page.P_System.User_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function check() {
            if ($.trim($("#ContentMain_txtUserid").val()).length == 0) {
                $("#ContentMain_txtUserid").addClass("inputTextError");
                $("#spanNameError").text("群组名称不能为空");
                return false;
            }
            if ($.trim($("#ContentMain_txtPassword").val()).length == 0) {
                $("#ContentMain_txtPassword").addClass("inputTextError");
                $("#spanPassword").text("密码不能为空");
                return false;
            }
        }
        $(document).ready(function () {
            $("#ContentMain_txtUserid").focus(function () {
                $("#spanNameError").text("");
            });
            $("#ContentMain_txtPassword").focus(function () {
                $("#spanPassword").text("");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div>

        <p>登陆用户：<asp:TextBox ID="txtUserid" runat="server" CssClass="inputText" MaxLength="20"></asp:TextBox><span style="color: red">*</span><span id="spanNameError" style="color: red"></span></p>
        <p>用户姓名：<asp:TextBox ID="txtUserName" runat="server" CssClass="inputText" MaxLength="20"></asp:TextBox></p>
        <p>用户密码：<asp:TextBox ID="txtPassword" runat="server" CssClass="inputText" MaxLength="20"></asp:TextBox><span style="color: red">*</span><span id="spanPassword" style="color: red"></span></p>
        <p>
            用户群组:
            <asp:DropDownList ID="ddlGroup" runat="server"></asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="btnSave" runat="server" Text="确定" CssClass="button" OnClick="btnSave_Click" OnClientClick="return check()" />
            <input type="button" class="buttonCancle" value="取消" id="btnCancel" onclick="seturl('/Page/P_System/User.aspx')" />
        </p>
    </div>
</asp:Content>
