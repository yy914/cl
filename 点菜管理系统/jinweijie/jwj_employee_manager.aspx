<%@ Page Title="" Language="C#" MasterPageFile="~/jwj_MyMasterPage.Master" AutoEventWireup="true" CodeBehind="jwj_employee_manager.aspx.cs" Inherits="jinweijie.jwj_employee_manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table style="width:100%;">
        <tr>
            <td colspan="3" class="oper_title">员工信息</td>
        </tr>
         <tr>
            <td style="text-align:center">员工职位：
                <asp:DropDownList ID="drop_type" runat="server" CssClass="textInput2" Font-Size="12px" AutoPostBack="True">
                    <asp:ListItem Value="%">全部</asp:ListItem>
                    <asp:ListItem>收银员</asp:ListItem>
                    <asp:ListItem>经理</asp:ListItem>
                    <asp:ListItem>服务员</asp:ListItem>
                    <asp:ListItem>外卖员</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;员工姓名：<asp:TextBox ID="txt_search" runat="server" CssClass="textInput2" Height="22px" Width="180px"></asp:TextBox>
&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageAlign="AbsBottom" ImageUrl="~/images/search1.png" Width="23px" />
                <input id="Button1" class="btn_add" type="button" value="添 加" onclick="location.href='mjn_menu_add.aspx'" /></td>
        </tr>
         <tr class="tr3">
            <td>
                <asp:GridView ID="GridView1" runat="server"  CssClass="grid" RowStyle-Cssclass="row" SelectedRowStyle-CssClass="selecting" HeaderStyle-CssClass="header" AlternatingRowStyle-CssClass="alternating"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Employee_id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
                        <asp:BoundField DataField="Sex" HeaderText="性别" SortExpression="Sex" />
                        <asp:BoundField DataField="IDno" HeaderText="身份证" SortExpression="IDno" />
                        <asp:BoundField DataField="Birth" HeaderText="生日" SortExpression="Birth" />
                        <asp:BoundField DataField="Duty" HeaderText="职位" SortExpression="Duty" />
                        <asp:BoundField DataField="Salary" HeaderText="工资" SortExpression="Salary" />
                        <asp:BoundField DataField="HireDate" HeaderText="雇佣日期 " SortExpression="HireDate" />
                        <asp:BoundField DataField="Tel" HeaderText="联系方式" SortExpression="Tel" />
                        <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
                        <asp:CommandField HeaderText="操作" ShowDeleteButton="True" />
                    </Columns>
                    <PagerStyle CssClass="cssPager" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conname %>" SelectCommand="SELECT * FROM [t_emmploy] WHERE (([Duty] LIKE '%' + @Duty + '%') AND ([Name] LIKE '%' + @Name + '%'))">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="drop_type" DefaultValue="%" Name="Duty" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="txt_search" DefaultValue="%" Name="Name" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
     </table>
</asp:Content>

