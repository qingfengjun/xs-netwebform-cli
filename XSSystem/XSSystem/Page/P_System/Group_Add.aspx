<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true" CodeBehind="Group_Add.aspx.cs" Inherits="xs_System.Page.P_System.Group_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //进行检核
        function Check() {
            if ($.trim($("#ContentMain_txtgroupName").val()).length == 0) {
                $("#ContentMain_txtgroupName").addClass("inputTextError");
                $("#spanNameError").text("群组名称不能为空");
                return false;
            }
            return true;
        }
        $(document).ready(function () {
            $("#ContentMain_txtgroupName").focusin(function () {
                $("#spanNameError").text("");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div>
        <p><span style="color: red">新增群组</span></p>
        <p>群组名称：<asp:TextBox ID="txtgroupName" runat="server" CssClass="inputText" MaxLength="50"></asp:TextBox><span id="spanNameError" style="color: red"></span></p>
        <p>群组说明：<asp:TextBox ID="txtgroupRemark" runat="server" CssClass="inputText" MaxLength="100" Width="80%"></asp:TextBox></p>
        <p>
            <asp:Button ID="btnSave" runat="server" Text="确定" CssClass="button" OnClick="btnSave_Click" OnClientClick="return Check()" actionid="02" onmouseover="" />
            <input type="button" class="buttonCancle" value="取消" id="btnCancel" onclick="seturl('/Page/P_System/Group.aspx')" />
        </p>
    </div>
</asp:Content>
