<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="XSSystem.Page.P_News.New"
    EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻预览</title>
    <style type="text/css">
        #main
        {
            border: 2px solid #C0C0C0;
            width: 1000px;
            margin: auto;
            padding: 20px;
            text-align: center;
        }
        
        #main h3
        {
            text-align: center;
        }
        #main p
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <h3>
            <asp:Label ID="lblTitle" runat="server"></asp:Label></h3>
        <hr />
        <p>
            <asp:Label ID="lblContent" runat="server"></asp:Label>
        </p>
    </div>
    </form>
</body>
</html>
