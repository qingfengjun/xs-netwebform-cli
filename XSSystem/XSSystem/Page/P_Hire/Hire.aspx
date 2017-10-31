<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true" CodeBehind="Hire.aspx.cs" Inherits="xs_System.Page.P_Hire.Hire" %>

<%@ Register Assembly="xsFramework.UserControl" Namespace="xsFramework.UserControl.Pager"
    TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../style/Hire.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div style="text-align: right">
        <input type="button" id="btnAdd" class="button" value="发布招聘信息" actionid="02" onclick="seturl('/Page/P_Hire/Hire_Add.aspx')" />
        <br />
    </div>
    <asp:GridView ID="gvhire" runat="server" AutoGenerateColumns="false" CssClass="xs_table">
        <Columns>
            <asp:TemplateField HeaderText="招聘职位" HeaderStyle-Width="60%">
                <ItemTemplate>
                    <a actionid="03" href="Hire_Update.aspx?id=<%#Eval("hire_id") %>" onclick="seturl('/Page/P_Hire/Hire_Add.aspx?id=<%#Eval("hire_id") %>')"><%#Eval("hire_name") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="招聘人数" DataField="hire_count" HeaderStyle-Width="10%" />
            <asp:BoundField HeaderText="工作地点" DataField="hire_place" HeaderStyle-Width="10%" />
            <asp:BoundField HeaderText="发布时间" DataField="hire_time" HeaderStyle-Width="10%" />
            <asp:TemplateField  HeaderStyle-Width="10%">
                <ItemTemplate>
                     <asp:Button ID="btnDelete" runat="server" Text="删除" CssClass="buttonCancle" CommandArgument='<%#Eval("hire_id") %>' OnClientClick="return confirm('是否删除？')"
                            OnClick="btnDelete_Click" actionid="04" /> 
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <cc1:xsPageControl ID="xsPage" runat="server" 
    onpagechanged="xsPage_PageChanged">
</cc1:xsPageControl>
</asp:Content>
