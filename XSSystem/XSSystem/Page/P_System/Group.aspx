<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="Group.aspx.cs" Inherits="xs_System.Page.P_System.Group" %>

<%@ Register Assembly="xsFramework.UserControl" Namespace="xsFramework.UserControl.Pager"
    TagPrefix="xs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div style="text-align: right" id="divaddbutton">
        <input type="button" id="btnAdd" class="button" value="新增群组" actionid="02" onclick="seturl('/Page/P_System/Group_Add.aspx')" />
        <br />
    </div>
    <br />
    <div id="divdata">
        <asp:GridView ID="gvGroup" runat="server" CssClass="xs_table" AutoGenerateColumns="false"
            OnRowDataBound="gvGroup_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="群组名称" DataField="group_name" HeaderStyle-Width="15%" />
                <asp:BoundField HeaderText="群组说明" DataField="group_remark" HeaderStyle-Width="40%" />
                <asp:TemplateField HeaderText="操作" HeaderStyle-Width="15%">
                    <ItemTemplate>
                        <a href="#" onclick="seturl('/Page/P_System/Group_Update.aspx?id=<%#Eval("group_id") %>')"
                            actionid="03">更新</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作" HeaderStyle-Width="15%">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="删除" CssClass="buttonCancle" OnClick="btnDelete_Click"
                            actionid="04" CommandArgument='<%#Eval("group_id") %>' OnClientClick="return confirm('是否删除？')" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作" HeaderStyle-Width="15%">
                    <ItemTemplate>
                        <a href="#" actionid="03" onclick="seturl('/Page/P_System/Group_Function.aspx?id=<%#Eval("group_id") %>')">
                            群组功能</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <xs:xsPageControl ID="xsPage" runat="server" TotalVisable="True" OnPageChanged="xsPage_PageChanged">
    </xs:xsPageControl>
</asp:Content>
