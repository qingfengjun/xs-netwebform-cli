<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="XSSystem.Page.P_Product.ProductView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商品预览</title>
    <link href="/style/new.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <h3>
            <asp:Label ID="lblTitle" runat="server"></asp:Label></h3>
        <div id="attach">
            &nbsp;&nbsp;备注：<asp:Label ID="lblRemark" runat="server"></asp:Label>
        </div>
        <hr />
        <p>
            <asp:Label ID="lblContent" runat="server"></asp:Label>
        </p>
    </div>
    </form>
</body>
</html>
