<%@ Page Title="" Language="C#" MasterPageFile="~/Page/P_Public/Main.Master" AutoEventWireup="true"
    CodeBehind="Group_Function.aspx.cs" Inherits="xs_System.Page.P_System.Group_Function" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //查询不勾选，其他也要取消.其他勾选，查询必选
        $(document).ready(function () {
            $(":checkbox").click(function () {
                var value = $(this).val();

                if (value == "01") {
                    if (!$(this).attr("checked")) {
                        $(this).parent().siblings("td").children(":checked").removeAttr("checked");
                    }
                }
                else {
                    if ($(this).attr("checked")) {
                        $(this).parent().siblings("td").children("input[value='01']").attr("checked", "checked");
                    }
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div>
        <p>
            群组名称：<asp:Label ID="lblName" runat="server"></asp:Label></p>
        <p>
            群组说明：<asp:Label ID="lblRemark" runat="server"></asp:Label></p>
        <asp:HiddenField ID="hidGroupID" runat="server" />
    </div>
    <asp:GridView ID="gvGroupFunction" runat="server" CssClass="xs_table" AutoGenerateColumns="false"
        OnRowDataBound="gvGroupFunction_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="功能名称" HeaderStyle-Width="20%" DataField="function_name" />
            <asp:TemplateField HeaderStyle-Width="80%" HeaderText="权限选择">
                <ItemTemplate>
                    <asp:CheckBoxList runat="server" ID="cblAction" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                    <asp:HiddenField ID="hidThisAction" runat="server" Value='<%#Eval("function_action") %>' />
                    <asp:HiddenField ID="hidFunctionID" runat="server" Value='<%#Eval("function_id") %>' />
                    <asp:HiddenField ID="hidParentId" runat="server" Value='<%#Eval("function_parent_id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p>
        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass=" button" OnClick="btnSave_Click" />
        <input type="button" class="buttonCancle" value="取消" id="btnCancel" onclick="seturl('/Page/P_System/Group.aspx')" />
    </p>
</asp:Content>
