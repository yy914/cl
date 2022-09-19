using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jinweijie
{
    public partial class jwj_order_add : System.Web.UI.Page
    {
        DataSet ds1 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack) //加入if判断，只有第一次打开页面时才绑定数据
            {
                get_data1();
                get_data2();
                get_data3();
                get_data4();
            }
        }

        protected void get_data1()
        {//热菜数据提取
            jwj_db mydb = new jwj_db();
            string sql = "SELECT *,menu_name+'   --  价格：'+CONVERT(varchar, menu_price)+ '-'+CONVERT(varchar, menu_discount) as multi_name FROM [t_menu] WHERE ([Menu_name] LIKE '%" + TextBox1.Text.ToString() + "%')  and menu_id not in(" + L_help1.Text.ToString() + ") and menu_style in ('蔬菜','荤菜','海鲜','汤类') ORDER BY [Menu_id]";
            ds1 = mydb.OpenDS("t_menu1", sql);
            ListBox1.DataSource = ds1.Tables["t_menu1"];//
            ListBox1.DataTextField = "multi_name";//
            ListBox1.DataValueField = "menu_id";//
            ListBox1.DataBind();//
            for(int i = 0; i < ListBox1.Items.Count; i++)
            {//
                ListBox1.Items[i].Attributes.Add("style", "padding-left:5px;height:24px;");
                if (i % 2 != 0) ListBox1.Items[i].Attributes.Add("style", "background-color:#E3EAEB;color:#D41F55;");
            }
        }

        protected void get_data2()
        { //冷菜数据提取
            jwj_db mydb = new jwj_db();
            string sql = "SELECT *,menu_name+'   --  价格：'+CONVERT(varchar, menu_price)+ '-'+CONVERT(varchar, menu_discount) as multi_name FROM [t_menu] WHERE ([Menu_name] LIKE '%" + TextBox2.Text.ToString() + "%')  and menu_id not in(" + L_help2.Text.ToString() + ") and menu_style in ('冷菜') ORDER BY [Menu_id]";
            ds1 = mydb.OpenDS("t_menu2", sql);
            ListBox2.DataSource = ds1.Tables["t_menu2"];//设置数据源
            ListBox2.DataTextField = "multi_name";  //设置显示部分的字段名
            ListBox2.DataValueField = "menu_id";  //设置真正的value部分的字段名
            ListBox2.DataBind();  //绑定数据到控件 
            for (int i = 0; i < ListBox2.Items.Count; i++) //通过循环，遍历listbox1的各个行，设置列表项的属性
            {
                ListBox2.Items[i].Attributes.Add("style", "padding-left:5px;height:24px;");
                if (i % 2 != 0) ListBox2.Items[i].Attributes.Add("style", "background-color:#E3EAEB;color:blue;");
            }
        }

        protected void get_data3()
        { //酒水类数据提取
            jwj_db mydb = new jwj_db();
            string sql = "SELECT *,menu_name+'   --  价格：'+CONVERT(varchar, menu_price)+ '-'+CONVERT(varchar, menu_discount) as multi_name FROM [t_menu] WHERE ([Menu_name] LIKE '%" + TextBox3.Text.ToString() + "%')  and menu_id not in(" + L_help3.Text.ToString() + ") and menu_style in ('酒水类') ORDER BY [Menu_id]";
            ds1 = mydb.OpenDS("t_menu3", sql);
            ListBox3.DataSource = ds1.Tables["t_menu3"];//设置数据源
            ListBox3.DataTextField = "multi_name";  //设置显示部分的字段名
            ListBox3.DataValueField = "menu_id";  //设置真正的value部分的字段名
            ListBox3.DataBind();  //绑定数据到控件 
            for (int i = 0; i < ListBox3.Items.Count; i++) //通过循环，遍历listbox1的各个行，设置列表项的属性
            {
                ListBox3.Items[i].Attributes.Add("style", "padding-left:5px;height:24px;");
                if (i % 2 != 0) ListBox3.Items[i].Attributes.Add("style", "background-color:#E3EAEB;color:green;");
            }
        }

        protected void get_data4()
        { //主食甜品类数据提取
            jwj_db mydb = new jwj_db();
            string sql = "SELECT *,menu_name+'   --  价格：'+CONVERT(varchar, menu_price)+ '-'+CONVERT(varchar, menu_discount) as multi_name FROM [t_menu] WHERE ([Menu_name] LIKE '%" + TextBox4.Text.ToString() + "%')  and menu_id not in(" + L_help4.Text.ToString() + ") and menu_style in ('甜品与点心','主食') ORDER BY [Menu_id]";
            ds1 = mydb.OpenDS("t_menu4", sql);
            ListBox4.DataSource = ds1.Tables["t_menu4"];//设置数据源
            ListBox4.DataTextField = "multi_name";  //设置显示部分的字段名
            ListBox4.DataValueField = "menu_id";  //设置真正的value部分的字段名
            ListBox4.DataBind();  //绑定数据到控件 
            for (int i = 0; i < ListBox4.Items.Count; i++) //通过循环，遍历listbox1的各个行，设置列表项的属性
            {
                ListBox4.Items[i].Attributes.Add("style", "padding-left:5px;height:24px;");
                if (i % 2 != 0) ListBox4.Items[i].Attributes.Add("style", "background-color:#E3EAEB;color:#FF1FAA;");
            }
        }
    }
}