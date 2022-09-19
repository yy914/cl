using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jinweijie
{
    public partial class jwj_employee_manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //删除处理代码
            string employee_id = GridView1.DataKeys[e.RowIndex][0].ToString();
            SqlDataSource1.DeleteCommand = "delete from t_emmploy where employee_id=" + employee_id;
            SqlDataSource1.Delete();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)(e.Row.Cells[9].Controls[0])).Attributes.Add("onclick", "return confirm('确定要删除吗？');");
            }
        }
    }
}