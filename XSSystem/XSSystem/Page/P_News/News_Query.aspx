<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Page/P_Public/Main.Master"
    CodeBehind="News_Query.aspx.cs" Inherits="xs_System.Page.P_News.News_Query" %>

<%@ Register Assembly="xsFramework.UserControl" Namespace="xsFramework.UserControl.Pager"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <p>
        <span>类别</span>
        <asp:DropDownList ID="ddlNewType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNewType_SelectedIndexChanged">
        </asp:DropDownList>
        <span>名称：</span><asp:TextBox ID="txtNewName" runat="server" CssClass="inputText"></asp:TextBox><asp:Button
            ID="btnQuery" runat="server" Text="查询" CssClass="button" 
            onclick="btnQuery_Click" />
    </p>
    <div>
        <div style="text-align: center" runat="server" id="Nodata" visible="false">
            查无数据.</div>
        <asp:Repeater ID="rptNews" runat="server">
            <ItemTemplate>
                <div class="dataCss">
                    <div class="dataHead">
                        <a href="New.aspx?id=<%#Eval("new_id") %>" target="_blank">
                            <%#Eval("new_title")%></a>
                    </div>
                    <br />
                    <div class="dataFoot">
                        <div class="footleft">
                            <%#Eval("user_name")%>发布于
                            <%#Eval("create_time")%>
                        </div>
                        <div class="footright">
                            <a href="news_edit.aspx?type=modify&id=<%#Eval("new_id") %>" target="_self" actionid="03">编辑</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="删除" CommandName='<%#Eval("new_id") %>'
                                OnClick="btnDelete_Click" OnClientClick="return confirm('是否删除？');" actionid="04"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <cc1:xsPageControl ID="xsPage" runat="server" OnPageChanged="xsPage_PageChanged">
            
        </cc1:xsPageControl>
    </div>
</asp:Content>
