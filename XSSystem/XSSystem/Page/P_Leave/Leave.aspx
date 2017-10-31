<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true" CodeBehind="Leave.aspx.cs" Inherits="xs_System.Page.P_Leave.Leave" %>

<%@ Register assembly="xsFramework.UserControl" namespace="xsFramework.UserControl.Pager" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div>
    <div id="NoData" runat="server" visible="false">查无留言.</div>
        <asp:Repeater ID="rptLeave" runat="server">
            <ItemTemplate>
                <div class="dataCss">
                    <div class="dataHead">
                        <%#Eval("leave_user")%>（<%#Eval("leave_contact")%>）
                    </div>
                    <div class="dataMain">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    留言信息<%#Eval("leave_Content")%></div>
                    <div class="dataFoot">
                        <div class="footleft">
                            于
                        <%#Eval("leave_time")%>
                        </div>
                        <div class="footright">
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="删除" CommandArgument='<%#Eval("leave_id") %>' OnClick="btnDelete_Click"
                                OnClientClick="return confirm('是否删除？');" actionid="04"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div>
        <cc1:xsPageControl ID="xsPage" runat="server" 
            onpagechanged="xsPage_PageChanged">
        </cc1:xsPageControl>
    </div>
</asp:Content>
