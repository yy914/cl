<%@ Page Title="前台营业-点菜" Language="C#" MasterPageFile="~/jwj_MyMasterPage.Master" AutoEventWireup="true" CodeBehind="jwj_order_add.aspx.cs" Inherits="jinweijie.jwj_order_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellsapcing="0" style="width:98%;">
        <tr>
            <td class="oper_title" colspan="4">点菜</td>
        </tr>
        <tr>
            <td align="right" height="25px" width="20%">订单编号：</td>
            <td width="30%">
                <asp:Label ID="L_ordernum" Font-Size="12px" Text="订单编号数据" runat="server"></asp:Label>
            </td>
            <td width="20%">桌号：<asp:Label ID="L_tablenum" Font-Size="12px" Text="未选" runat="server"></asp:Label></td>
            <td>
                <asp:Button ID="Btn_tablechoose" CausesValidation="False" Text="选择桌号"    CssClass="btn_orange" runat="server" /></td>
        </tr>
        <tr>
            <td align="left" height="30px" bgcolor="#F3F3F3" style="padding-left:10px;background:url(./images/bg3.jpg); ">
                <img alt="" src="images/myfav.jpg" height="12px" width="12px" />热菜菜谱：</td>
            <td bgcolor="#F3F3F3" style="background:url(./images/bg3.jpg); ">&nbsp;</td>
            <td style=" background:url(./images/bg3.jpg); ">
                <img alt="" src="images/myfav.jpg" height="12px" width="12px" /> 冷菜菜谱：</td>
            <td style="background:url(./images/bg3.jpg); ">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" height="25px" bgcolor="#F3F3F3">
                <asp:TextBox ID="TextBox1"　CssClass="textInput2" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:ImageButton ID="imgbtn_add1"  CausesValidation="False" ImageAlign="AbsBottom"  Height="20px" Width="24px" ImageUrl="~/images/move_right.gif" runat="server" />
            </td>
            <td bgcolor="#F3F3F3">
                <asp:Label ID="L_help1" runat="server" Text="0,0"></asp:Label></td>
            <td align="center">
                <asp:TextBox ID="TextBox2"　CssClass="textInput2" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:ImageButton ID="imgbtn_add2"  CausesValidation="False" ImageAlign="AbsBottom"  Height="20px" Width="24px" ImageUrl="~/images/move_right.gif" runat="server" /></td>
            <td bgcolor="#F3F3F3">
                <asp:Label ID="L_help2" runat="server" Text="0,0"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" bgcolor="#F3F3F3" >
                <div style="height:330px; width:100%; overflow:auto; margin-top:5px;">
                    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="false" Rows="20" Width="85%" Font-Size="12px"></asp:ListBox>
                </div></td>
            <td align="center" bgcolor="#F3F3F3" >
               <div style="height:330px; width:100%; overflow:auto; margin-left:10px;">
<asp:GridView ID="GridView1" runat="server" 
           AlternatingRowStyle-CssClass="alternating1" AutoGenerateColumns="False" 
           CssClass="grid1" DataKeyNames="menu_id" HeaderStyle-CssClass="header1" 
           RowStyle-CssClass="row" SelectedRowStyle-CssClass="selecting">
           <RowStyle CssClass="row" />
     <Columns>
          <asp:BoundField DataField="menu_name" HeaderText="菜品名称" ReadOnly="True">
               <HeaderStyle ForeColor="White" />
          </asp:BoundField>
          <asp:BoundField DataField="menu_price" HeaderText="价格" ReadOnly="True">
                <HeaderStyle ForeColor="White" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="份数">
                <ItemTemplate>
                     <asp:DropDownList ID="Drop_amount1" runat="server" CssClass="textInput2" 
                            Font-Size="12px" ForeColor="#0000CC" Width="40px">
                            <asp:ListItem Selected="True">1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                       </asp:DropDownList>
                  </ItemTemplate>
                   <ControlStyle Height="22px" Width="30px" />
                   <HeaderStyle ForeColor="White" />
                   <ItemStyle HorizontalAlign="Center" Width="40px" />
           </asp:TemplateField>
           <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/DELE.gif" 
                  HeaderText="删除" ShowDeleteButton="True">
                  <HeaderStyle ForeColor="White" />
                  <ItemStyle HorizontalAlign="Center" Width="30px" />
           </asp:CommandField>
      </Columns>
      <SelectedRowStyle CssClass="selecting" />
      <HeaderStyle CssClass="header1" />
      <AlternatingRowStyle CssClass="alternating1" />
</asp:GridView>
                </div></td>
            <td align="center">
                <div style="height:330px; width:100%; overflow:auto; margin-top:5px;">
                    <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="false" Rows="20" Width="85%" Font-Size="12px"></asp:ListBox>
                </div></td>
            <td align="center">
                <div style="height:330px; width:100%; overflow:auto">
                    <asp:GridView ID="GridView2" runat="server" 
           AlternatingRowStyle-CssClass="alternating1" AutoGenerateColumns="False" 
           CssClass="grid1" DataKeyNames="menu_id" HeaderStyle-CssClass="header1" 
           RowStyle-CssClass="row" SelectedRowStyle-CssClass="selecting">
           <RowStyle CssClass="row" />
     <Columns>
          <asp:BoundField DataField="menu_name" HeaderText="菜品名称" ReadOnly="True">
               <HeaderStyle ForeColor="White" />
          </asp:BoundField>
          <asp:BoundField DataField="menu_price" HeaderText="价格" ReadOnly="True">
                <HeaderStyle ForeColor="White" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="份数">
                <ItemTemplate>
                     <asp:DropDownList ID="Drop_amount1" runat="server" CssClass="textInput2" 
                            Font-Size="12px" ForeColor="#0000CC" Width="40px">
                            <asp:ListItem Selected="True">1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                       </asp:DropDownList>
                  </ItemTemplate>
                   <ControlStyle Height="22px" Width="30px" />
                   <HeaderStyle ForeColor="White" />
                   <ItemStyle HorizontalAlign="Center" Width="40px" />
           </asp:TemplateField>
           <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/DELE.gif" 
                  HeaderText="删除" ShowDeleteButton="True">
                  <HeaderStyle ForeColor="White" />
                  <ItemStyle HorizontalAlign="Center" Width="30px" />
           </asp:CommandField>
      </Columns>
      <SelectedRowStyle CssClass="selecting" />
      <HeaderStyle CssClass="header1" />
      <AlternatingRowStyle CssClass="alternating1" />
</asp:GridView>
                </div></td>
        </tr>
        <tr>
            <td align="left" height="30px" bgcolor="#F3F3F3" style="padding-left:10px;border-top:solid 1px #cbe9f4;background:url(./images/bg3.jpg); ">
                <img alt="" src="images/myfav.jpg" height="12px" width="12px" />酒水类：</td>
            <td bgcolor="#F3F3F3" style="border-top:solid 1px #cbe9f4;background:url(./images/bg3.jpg); ">&nbsp;</td>
            <td style="border-top:solid 1px #cbe9f4;background:url(./images/bg3.jpg); ">
                <img alt="" src="images/myfav.jpg" height="12px" width="12px" /> 甜品与主食：</td>
            <td style="border-top:solid 1px #cbe9f4;background:url(./images/bg3.jpg); ">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" height="25px" bgcolor="#F3F3F3">
                <asp:TextBox ID="TextBox3"　CssClass="textInput2" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton1"  CausesValidation="False" ImageAlign="AbsBottom"  Height="20px" Width="24px" ImageUrl="~/images/move_right.gif" runat="server" />
            </td>
            <td bgcolor="#F3F3F3">
                <asp:Label ID="L_help3" runat="server" Text="0,0"></asp:Label></td>
            <td align="center">
                <asp:TextBox ID="TextBox4"　CssClass="textInput2" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton2"  CausesValidation="False" ImageAlign="AbsBottom"  Height="20px" Width="24px" ImageUrl="~/images/move_right.gif" runat="server" /></td>
            <td bgcolor="#F3F3F3">
                <asp:Label ID="L_help4" runat="server" Text="0,0"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" bgcolor="#F3F3F3" >
                <div style="height:330px; width:100%; overflow:auto; margin-top:5px;">
                    <asp:ListBox ID="ListBox3" runat="server" AutoPostBack="false" Rows="10" Width="85%" Font-Size="12px"></asp:ListBox>
                </div></td>
            <td align="center" bgcolor="#F3F3F3" >
                <div style="height:330px; width:100%; overflow:auto">
                    <asp:GridView ID="GridView3" runat="server" 
           AlternatingRowStyle-CssClass="alternating1" AutoGenerateColumns="False" 
           CssClass="grid1" DataKeyNames="menu_id" HeaderStyle-CssClass="header1" 
           RowStyle-CssClass="row" SelectedRowStyle-CssClass="selecting">
           <RowStyle CssClass="row" />
     <Columns>
          <asp:BoundField DataField="menu_name" HeaderText="菜品名称" ReadOnly="True">
               <HeaderStyle ForeColor="White" />
          </asp:BoundField>
          <asp:BoundField DataField="menu_price" HeaderText="价格" ReadOnly="True">
                <HeaderStyle ForeColor="White" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="份数">
                <ItemTemplate>
                     <asp:DropDownList ID="Drop_amount1" runat="server" CssClass="textInput2" 
                            Font-Size="12px" ForeColor="#0000CC" Width="40px">
                            <asp:ListItem Selected="True">1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                       </asp:DropDownList>
                  </ItemTemplate>
                   <ControlStyle Height="22px" Width="30px" />
                   <HeaderStyle ForeColor="White" />
                   <ItemStyle HorizontalAlign="Center" Width="40px" />
           </asp:TemplateField>
           <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/DELE.gif" 
                  HeaderText="删除" ShowDeleteButton="True">
                  <HeaderStyle ForeColor="White" />
                  <ItemStyle HorizontalAlign="Center" Width="30px" />
           </asp:CommandField>
      </Columns>
      <SelectedRowStyle CssClass="selecting" />
      <HeaderStyle CssClass="header1" />
      <AlternatingRowStyle CssClass="alternating1" />
</asp:GridView>
                </div></td>
            <td align="center">
                <div style="height:200px; width:100%; overflow:auto; margin-top:5px;">
                    <asp:ListBox ID="ListBox4" runat="server" AutoPostBack="false" Rows="10" Width="85%" Font-Size="12px"></asp:ListBox>
                </div></td>
            <td align="center">
                <div style="height:330px; width:100%; overflow:auto">
                    <asp:GridView ID="GridView4" runat="server" 
           AlternatingRowStyle-CssClass="alternating1" AutoGenerateColumns="False" 
           CssClass="grid1" DataKeyNames="menu_id" HeaderStyle-CssClass="header1" 
           RowStyle-CssClass="row" SelectedRowStyle-CssClass="selecting">
           <RowStyle CssClass="row" />
     <Columns>
          <asp:BoundField DataField="menu_name" HeaderText="菜品名称" ReadOnly="True">
               <HeaderStyle ForeColor="White" />
          </asp:BoundField>
          <asp:BoundField DataField="menu_price" HeaderText="价格" ReadOnly="True">
                <HeaderStyle ForeColor="White" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="份数">
                <ItemTemplate>
                     <asp:DropDownList ID="Drop_amount1" runat="server" CssClass="textInput2" 
                            Font-Size="12px" ForeColor="#0000CC" Width="40px">
                            <asp:ListItem Selected="True">1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                       </asp:DropDownList>
                  </ItemTemplate>
                   <ControlStyle Height="22px" Width="30px" />
                   <HeaderStyle ForeColor="White" />
                   <ItemStyle HorizontalAlign="Center" Width="40px" />
           </asp:TemplateField>
           <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/DELE.gif" 
                  HeaderText="删除" ShowDeleteButton="True">
                  <HeaderStyle ForeColor="White" />
                  <ItemStyle HorizontalAlign="Center" Width="30px" />
           </asp:CommandField>
      </Columns>
      <SelectedRowStyle CssClass="selecting" />
      <HeaderStyle CssClass="header1" />
      <AlternatingRowStyle CssClass="alternating1" />
</asp:GridView>
                </div></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td align="right" valign="middle">
            <asp:Button  ID="btn_ok2" runat="server" Text="提交订单" CssClass="btn_blue" /></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
