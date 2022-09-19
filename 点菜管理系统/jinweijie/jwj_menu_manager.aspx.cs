using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace jinweijie
{
    public partial class jwj_menu_manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当详情被单击时处理代码：进入查看编辑界面

            //读取选中行记录的menu_id
            string menu_id = GridView1.SelectedDataKey[0].ToString();
            SqlDataReader dr = null;//定义数据结果集对象
            string sql = "select * from t_menu where menu_id=" + menu_id;//定义查询语句
            jwj_db mydb = new jwj_db();
            dr = mydb.OpenDR(sql);//执行查询
            if(dr.Read())   //读取记录，并把记录的值依次赋值给对应控件
            {
                this.txt_menuname.Text = dr["menu_name"].ToString();
                this.txt_price.Text = dr["Menu_price"].ToString();
                this.txt_discount.Text = dr["Menu_discount"].ToString();
                this.drop_taste.Text = dr["Menu_taste"].ToString();
                this.drop_type2.Text = dr["Menu_style"].ToString();
                this.txt_material.Text = dr["Menu_material"].ToString();
                this.txt_desc.Text = dr["Menu_description"].ToString();
            }
            dr.Close();//关闭结果集
            mydb.closeDB();//关闭连接
            Panel1.Visible = true;//允许修改panel
            GridView1.Enabled = false;//让GridView按钮失效
        }

        protected void imgbtn_xiugai_Click(object sender, ImageClickEventArgs e)
        {
            //修改按钮处理代码
            string menu_id = GridView1.SelectedDataKey[0].ToString();
            string menuname = this.txt_menuname.Text.ToString();
            string price = this.txt_price.Text.ToString();
            string discount = this.txt_discount.Text.ToString();
            string taste = this.drop_taste.Text.ToString();
            string type = this.drop_type2.Text.ToString();
            string metiale = this.txt_material.Text.ToString();
            string desc = this.txt_desc.Text.ToString();

            if (price.Equals("")) price = "0";
            if (discount.Equals("")) discount = "1";

            SqlDataSource1.UpdateCommand = "update t_menu set Menu_name='" + menuname + "',Menu_price=" + price + ",Menu_discount=" + discount + ",Menu_taste='" + taste + "',Menu_style='" + type + "',Menu_material='" + metiale + "',Menu_description='" + desc + "' where menu_id=" + menu_id;
            SqlDataSource1.Update();
            Response.Write("<script>alert('修改成功！')</script>");
        }

        protected void imgbtn_close_Click(object sender, ImageClickEventArgs e)
        {
            //关闭按钮处理代码
            Panel1.Visible = false;
            GridView1.Enabled = true;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //删除处理代码
            string menu_id = GridView1.DataKeys[e.RowIndex][0].ToString();
            SqlDataSource1.DeleteCommand = "delete from t_menu where menu_id=" + menu_id;
            SqlDataSource1.Delete();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)(e.Row.Cells[7].Controls[0])).Attributes.Add("onclick", "return confirm('确定要删除吗？');");
            }
        }
    }
}