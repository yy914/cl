<%@ Page Title="系统管理——菜单管理" Language="C#" MasterPageFile="~/jwj_MyMasterPage.Master" AutoEventWireup="true" CodeBehind="jwj_menu_manager.aspx.cs" Inherits="jinweijie.jwj_menu_manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellsapcing="0" style="width:100%;">
        <tr>
            <td class="oper_title">菜单管理</td>
        </tr>
        <tr>
            <td style="text-align:center; height:30px;">菜品类型：<asp:DropDownList ID="drop_type" runat="server" CssClass="textInput2" AutoPostBack="True">
                    <asp:ListItem Value="%">全部</asp:ListItem>
                    <asp:ListItem>冷菜</asp:ListItem>
                    <asp:ListItem>荤菜</asp:ListItem>
                    <asp:ListItem>素菜</asp:ListItem>
                    <asp:ListItem>海鲜</asp:ListItem>
                    <asp:ListItem>酒水类</asp:ListItem>
                    <asp:ListItem>主食</asp:ListItem>
                    <asp:ListItem>甜品与点心</asp:ListItem>
                    <asp:ListItem>汤类</asp:ListItem>
                </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 菜品名称：<asp:TextBox ID="txt_search" runat="server" CssClass="textInput2" Height="22px" Width="180px"></asp:TextBox>
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageAlign="AbsBottom" ImageUrl="~/images/testschedule.jpg" Width="23px" />
                <input id="Button1" class="btn_add" type="button" value="添加" onclick="location.href='jwj_menu_add.aspx'"/></td>
        </tr>
        <tr>
            <td style="text-align:center; vertical-align:top;">
                <asp:GridView ID="GridView1" runat="server" CssClass="grid" RowStyle-CssClass="row" AlternatingRowStyle-CssClass="alternating" SelectedRowStyle-CssClass="selecting" HeaderStyle-CssClass="header" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" DataKeyNames="Menu_id" PageSize="25" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
<AlternatingRowStyle CssClass="alternating"></AlternatingRowStyle>

                    <Columns>
                        <asp:BoundField DataField="Menu_name" HeaderText="菜品名称" SortExpression="Menu_name">
                            <ItemStyle  Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Menu_price" HeaderText="价格" SortExpression="Menu_price">
                            <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Menu_discount" HeaderText="折扣" SortExpression="Menu_discount">
                            <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Menu_taste" HeaderText="菜品口味" SortExpression="Menu_taste">
                            <ItemStyle Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Menu_style" HeaderText="类型" SortExpression="Menu_style">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Menu_material" HeaderText="菜品原料" SortExpression="Menu_material" />
                        <asp:CommandField HeaderText="查看" SelectText="详细" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:CommandField>
                        <asp:CommandField HeaderText="操作" ShowDeleteButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:CommandField>
                    </Columns>
                    <PagerStyle CssClass="cssPager" />
                    <HeaderStyle CssClass="header"></HeaderStyle>

                    <RowStyle CssClass="row"></RowStyle>

                    <SelectedRowStyle CssClass="selecting"></SelectedRowStyle>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conname %>" SelectCommand="SELECT * FROM [t_menu] WHERE (([Menu_style] LIKE '%' + @Menu_style + '%') AND ([Menu_name] LIKE '%' + @Menu_name + '%')) ORDER BY [Menu_id]">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="drop_type" DefaultValue="%" Name="Menu_style" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="txt_search" DefaultValue="%" Name="Menu_name" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" CssClass="edit_panel" Visible="False">
        <table cellpadding="0" cellspacing="0" class="style1" >
            <tr>
            <td  colspan="3" class="pane_tilte">
                菜品查看与编辑</td>
        </tr>
              <tr>
            <td style="width:20%; height:30px; text-align:right;">
                菜品名称：</td>
            <td style="width:65%; text-align:left;">
                <asp:TextBox ID="txt_menuname" runat="server" CssClass="textInput"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txt_menuname" ErrorMessage="* 必须填"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td  style="width:20%; height:30px; text-align:right;">
                菜品定价：</td>
            <td style="width:65%; text-align:left;">
                <asp:TextBox ID="txt_price" runat="server" CssClass="textInput2" Width="60px"></asp:TextBox>
            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1"  
                    runat="server" ErrorMessage="数值" ValidationExpression="^\d+$" 
                    ControlToValidate="txt_price"></asp:RegularExpressionValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 菜品折扣：<asp:TextBox ID="txt_discount" 
                    runat="server" CssClass="textInput2" Width="60px">1</asp:TextBox>
            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2"  
                    runat="server" ErrorMessage="数值0～1" ValidationExpression="^1|(0\.[0-9]*[1-9])$" 
                    ControlToValidate="txt_discount"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:20%; height:30px; text-align:right;">
                菜品口味：</td>
            <td>
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
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 菜品类型：<asp:DropDownList ID="drop_type2" runat="server" CssClass="textInput2">
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
            <td style="width:20%; height:30px; text-align:right; padding-top:10px;" valign="top">
                制作原料：</td>
            <td>
                <asp:TextBox ID="txt_material" runat="server" CssClass="multi_textbox" Rows="10" 
                    TextMode="MultiLine"></asp:TextBox>
                                    </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:20%; height:30px; text-align:right;padding-top:10px;" valign="top" >
                菜品描述：</td>
            <td >
                <asp:TextBox ID="txt_desc" runat="server" CssClass="multi_textbox" Rows="7" 
                    TextMode="MultiLine"></asp:TextBox>
                                    </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                </td>
            <td  style="height:60px; vertical-align:middle; padding-left:40px;">
                <asp:ImageButton ID="imgbtn_xiugai" runat="server" 
                    ImageUrl="~/images/xiugai.gif" onclick="imgbtn_xiugai_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="imgbtn_close" runat="server" 
                    ImageUrl="~/images/guanbi.gif" onclick="imgbtn_close_Click" />
                </td>
           
               
        </tr>
    </table> 
    </asp:Panel>
</asp:Content>
