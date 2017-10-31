<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="User.aspx.cs" Inherits="xs_System.Page.P_System.User" %>

<%@ Register Assembly="xsFramework.UserControl" Namespace="xsFramework.UserControl.Pager"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Cancle() {
            $("#divData").show();
            $("#divupdate").hide();
            doSize();
        }
        function update(id, name, type) {
            $("#ContentMain_txtUserid").val(id);
            $("#ContentMain_txtUserName").val(name);
            $("#ContentMain_ddlType").val(type);
            $("#divData").hide();
            $("#divupdate").show();
            doSize();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div id="divData">
        <div style="margin: auto">
            <asp:DropDownList ID="ddlGroup" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="button" OnClick="btnQuery_Click"
                actionid="01" />
            <input type="button" id="btnAdd" class="button" value="新增群组" actionid="02" onclick="seturl('/Page/P_System/User_add.aspx')"
                style="float: right" />
            <br />
            <br />
        </div>
        <asp:GridView ID="gvUser" runat="server" CssClass="xs_table" AutoGenerateColumns="false"
            ShowHeaderWhenEmpty="true" EmptyDataText="查无用户">
            <Columns>
                <asp:BoundField HeaderText="登陆用户" DataField="user_no" HeaderStyle-Width="20%" />
                <asp:BoundField HeaderText="用户姓名" DataField="user_name" HeaderStyle-Width="20%" />
                <asp:BoundField HeaderText="密码" DataField="user_password" HeaderStyle-Width="20%" />
                <asp:BoundField HeaderText="用户群组" DataField="group_name" HeaderStyle-Width="20%" />
                <asp:TemplateField HeaderText="操作" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <a href="#" onclick="update('<%#Eval("user_no") %>','<%#Eval("user_name") %>','<%#Eval("group_id") %>')"
                            actionid="03">更新</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="删除" CssClass="buttonCancle" CommandArgument='<%#Eval("user_no") %>'
                            OnClientClick="return confirm('是否删除？')" actionid="04" OnClick="btnDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <cc1:xsPageControl ID="xsPage" runat="server" OnPageChanged="xsPage_PageChanged">
        </cc1:xsPageControl>
    </div>
    <div id="divupdate" style="display: none">
        <p>
            登陆用户：<asp:TextBox ID="txtUserid" runat="server" CssClass="inputText" MaxLength="20"></asp:TextBox><span
                id="spanNameError" style="color: red"></span></p>
        <p>
            用户姓名：<asp:TextBox ID="txtUserName" runat="server" CssClass="inputText" MaxLength="20"></asp:TextBox></p>
        <p>
            用户群组:
            <asp:DropDownList ID="ddlType" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="btnSave" runat="server" Text="确定" CssClass="button" action="03" OnClick="btnSave_Click" />
            <input type="button" class="buttonCancle" value="取消" id="btnCancel" onclick="Cancle()" />
        </p>
    </div>
</asp:Content>
