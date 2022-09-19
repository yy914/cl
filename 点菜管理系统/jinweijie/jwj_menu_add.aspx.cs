using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace jinweijie
{
    public partial class jwj_menu_add : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void imgbtn_ok_Click(object sender, ImageClickEventArgs e)
        {
            //保存添加的菜品
            string menuname = this.txt_menuname.Text.ToString();
            string price = this.txt_price.Text.ToString();
            string discount = this.txt_discount.Text.ToString();
            string taste = this.drop_taste.Text.ToString();
            string type = this.drop_type.Text.ToString();
            string material = this.txt_material.Text.ToString();
            string desc = this.txt_desc.Text.ToString();

            if (price.Equals("")) price = "0";
            if (discount.Equals("")) discount = "1";

            jwj_db mydb = new jwj_db();
            string sql = "insert into t_menu (Menu_name,Menu_price,Menu_discount,Menu_taste,Menu_style,Menu_material,Menu_description)" +
               " values('" + menuname + "'," + price + "," + discount + ",'" + taste + "','" + type + "','" + material + "','" + desc + "')";
            int i = mydb.InsertDB(sql);
            imgbtn_ok.Enabled = false;
            Response.Write("<script>alert('添加成功!')</script>");
        }

        protected void imgbtn_clear_Click(object sender, ImageClickEventArgs e)
        {
            //清空填写的内容
            txt_menuname.Text = txt_price.Text = txt_material.Text = txt_desc.Text = "";
            txt_discount.Text = "1";
            drop_taste.SelectedIndex = 0;
            drop_type.SelectedIndex = 0;
            imgbtn_ok.Enabled = true;
        }

        
    }
}