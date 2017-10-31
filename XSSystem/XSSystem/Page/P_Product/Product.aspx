<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="Product.aspx.cs" Inherits="xs_System.Page.P_Product.Product" %>

<%@ Register Assembly="xsFramework.UserControl" Namespace="xsFramework.UserControl.Pager"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/style/product.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <p>
        <span>类别</span>
        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlType_SelectedIndexChanged" >
        </asp:DropDownList>
        <span>名称：</span><asp:TextBox ID="txtName" runat="server" CssClass="inputText"></asp:TextBox><asp:Button
            ID="btnQuery" runat="server" Text="查询" CssClass="button" 
            onclick="btnQuery_Click" />
    </p>
    <div style="text-align: center" runat="server" id="Nodata" visible="false">
        查无数据.</div>
    <div>
        <asp:Repeater ID="rptProduct" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <div class="productpic">
                        <img src="<%#Eval("product_imgurl") %>" alt="11" />
                    </div>
                    <div class="productDesc">
                        <a href="ProductView.aspx?id=<%#Eval("product_id") %>" class="title" target="_blank">
                            <%#Eval("product_title")%></a>
                        <div class="desc">
                            <span>&nbsp;&nbsp;
                                <%#Eval("product_remark") %></span>
                        </div>
                        <div class="edit">
                            <a href="Product_Add.aspx?type=modify&id=<%#Eval("product_id") %>" actionid="03">编辑</a>
                            <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%#Eval("product_id") %>'
                                OnClick="lbtnDelete_Click" OnClientClick="return confirm('请确认是否删除？')" actionid="04">删除</asp:LinkButton>
                        </div>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div>
        <cc1:xsPageControl ID="xsPage" runat="server" OnPageChanged="xsPage_PageChanged"
            TotalVisable="True">
        </cc1:xsPageControl>
    </div>
</asp:Content>
