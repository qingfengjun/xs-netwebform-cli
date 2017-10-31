<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="Product_Add.aspx.cs" Inherits="xs_System.Page.P_Product.Product_Add"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/style/xsPop.css" rel="stylesheet" type="text/css" />
    <script src="/js/xsPop.jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .table
        {
            width: 100%;
        }
        
        .table td
        {
            padding: 5px;
            vertical-align: top;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#help").click(function () {
                var options = {
                    title: "上传图片步骤",
                    width: 600,
                    heigth: 500,
                    close: "关闭"
                }
                $("#uploadHelp").xsPop(options);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <table class="table">
        <tr>
            <td width="20%">
                类别：
            </td>
            <td width="80%">
                <asp:DropDownList ID="ddlType" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <span class="required">*</span>图片地址:<span id="help" style="cursor: help; color: Blue">（上传帮助)</span>
            </td>
            <td>
                <asp:TextBox ID="txtPic" runat="server" Width="80%" MaxLength="200" CssClass="inputText"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="图片地址不能为空"
                    ControlToValidate="txtPic" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <span class="required">*</span>产品名称：
            </td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="80%" MaxLength="100" CssClass="inputText" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="产品名称不能为空"
                    ControlToValidate="txtTitle" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <span class="required">*</span>产品说明：
            </td>
            <td>
                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="80%" Rows="4" CssClass="inputText"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="产品说明不能为空"
                    ControlToValidate="txtRemark" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <p>
        <span class="required">*</span>商品信息：
    </p>
    <p style="height: 700px">
        <asp:TextBox ID="txtContent" runat="server" CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox>
    </p>
    <div style="text-align: center">
        <asp:Button ID="btnSave" runat="server" Text="新增" CssClass="button" OnClick="btnSave_Click"
            ValidationGroup="Save" actionid="02" />
        <asp:Button ID="btnModify" runat="server" CssClass="button" ValidationGroup="Save"
            Text="修改" OnClick="btnModify_Click" actionid="03" />
        <asp:HiddenField ID="hidID" runat="server" />
    </div>
    <div id="uploadHelp" style="display: none">
        <p>
            1:点选下面高级输入框的图片
        </p>
        <p>
            <img src="../../images/proudct/1.gif" width="100%" alt="1" /></p>
        <p>
            2:选择要上传的文件，上传到服务器</p>
        <p>
            <img src="../../images/proudct/2.gif" width="100%" alt="2" /></p>
        <p>
            3:此时会得到一个图片地址，将该地址copy到上传文件输入框中</p>
        <p>
            <img src="../../images/proudct/3.gif" width="100%" alt="3" /></p>
    </div>
</asp:Content>
