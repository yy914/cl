<%@ Page Title="系统管理—菜单管理—菜品添加" Language="C#" MasterPageFile="~/jwj_MyMasterPage.Master" AutoEventWireup="true" CodeBehind="jwj_menu_add.aspx.cs" Inherits="jinweijie.jwj_menu_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .td1{
            width:30%; 
            height:30px; 
            text-align:right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellsapcing="0" style="width:100%;">
        <tr>
            <td class="oper_title" colspan="3">
                <a class="son_link" href="jwj_menu_manager.aspx">&gt;&gt;返回菜单管理&lt;&lt;</a>
                菜单菜品添加</td>
        </tr>
        <tr>
            <td style="width:30%; height:30px; text-align:right;">菜品名称：</td>
            <td style="width:45%; text-align:left;">
                <asp:TextBox ID="txt_menuname" runat="server" CssClass="textInput" Width="400px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_menuname" ErrorMessage="*必须填"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="td1">菜品定价：</td>
            <td style="width:45%; text-align:left;">
                <asp:TextBox ID="txt_price" runat="server" Width="80px" CssClass="textInput2"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_price" ErrorMessage="数值" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 菜品折扣：<asp:TextBox ID="txt_discount" runat="server" Width="80px" CssClass="textInput2">1</asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="数值0~1" ValidationExpression="^1|(0\.[0-9]*[1-9])$" ControlToValidate="txt_discount" ></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="td1">菜品口味：</td>
            <td dir="ltr">
                <asp:DropDownList ID="drop_taste" runat="server" CssClass="textInput2">
                    <asp:ListItem>湘菜</asp:ListItem>
                    <asp:ListItem>杭帮菜</asp:ListItem>
                    <asp:ListItem>川菜口味</asp:ListItem>
                    <asp:ListItem>酸辣味</asp:ListItem>
                    <asp:ListItem>清淡口味</asp:ListItem>
                    <asp:ListItem>老北京</asp:ListItem>
                    <asp:ListItem>墨西哥</asp:ListItem>
                    <asp:ListItem>广式菜</asp:ListItem>
                    <asp:ListItem>香辣重口味</asp:ListItem>
                    <asp:ListItem>糖醋口味</asp:ListItem>
                    <asp:ListItem>普通辣味</asp:ListItem>
                    <asp:ListItem>浙菜</asp:ListItem>
                    <asp:ListItem>满汉全席</asp:ListItem>
                </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 菜品类型：<asp:DropDownList ID="drop_type" runat="server" CssClass="textInput2">
                    <asp:ListItem>冷菜</asp:ListItem>
                    <asp:ListItem>荤菜</asp:ListItem>
                    <asp:ListItem>素菜</asp:ListItem>
                    <asp:ListItem>海鲜</asp:ListItem>
                    <asp:ListItem>酒水类</asp:ListItem>
                    <asp:ListItem>主食</asp:ListItem>
                    <asp:ListItem>甜品与点心</asp:ListItem>
                    <asp:ListItem>汤类</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="td1" style="padding-top:10px;" valign="top">制作原材料：</td>
            <td>
                <asp:TextBox ID="txt_material" runat="server" CssClass="multi_textbox" Rows="10" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="td1" style="padding-top:10px;" valign="top">菜品描述：</td>
            <td>
                <asp:TextBox ID="txt_desc" runat="server" CssClass="multi_textbox" Rows="10" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="imgbtn_ok" runat="server" ImageUrl="~/images/button_ok.gif" OnClick="imgbtn_ok_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="imgbtn_clear" runat="server" ImageUrl="~/images/button_clear.gif" OnClick="imgbtn_clear_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
