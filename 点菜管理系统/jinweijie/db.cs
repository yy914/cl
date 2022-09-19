using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace jinweijie
{
    public class jwj_db
    {
        private SqlConnection conn; //定义数据成员conn 即数据库连接对象
        public jwj_db()
        {

        }
        private Boolean linkDB()
        {//编写数据库连接函数
            string conname = ConfigurationManager.ConnectionStrings["conname"].ConnectionString.ToString();
            conn = new SqlConnection(conname);
            if (conn != null) return true;
            else return false;
        }
        public DataSet OpenDS(string tablename, string sql)
        {//添加查询功能函数，返回dataset对象
            DataSet ds = null;
            if (linkDB())
            {
                SqlDataAdapter mycommand;
                mycommand = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                mycommand.Fill(ds, tablename);

            }
            return ds;
        }
        public SqlDataReader OpenDR(string sql)
        {//添加查询功能函数，返回SqlDataReader对象
            SqlDataReader dr = null;
            if (linkDB())
            {
                SqlCommand mysqlcommand;
                mysqlcommand = new SqlCommand(sql, conn);
                mysqlcommand.Connection.Open();
                dr = mysqlcommand.ExecuteReader(CommandBehavior.CloseConnection);

            }
            return dr;
        }
        public int InsertDB(string sql)
        {//插入
            int insertnum = 0;
            if (linkDB())
            {
                SqlCommand mysqlcommand;
                mysqlcommand = new SqlCommand(sql, conn);
                mysqlcommand.Connection.Open();
                insertnum = mysqlcommand.ExecuteNonQuery();
                conn.Close();
            }
            return insertnum;
        }
        public int UpdateDB(string sql)
        {//修改
            int updatenum = 0;
            if (linkDB())
            {
                SqlCommand mysqlcommand;
                mysqlcommand = new SqlCommand(sql, conn);
                mysqlcommand.Connection.Open();
                updatenum = mysqlcommand.ExecuteNonQuery();
                conn.Close();
            }
            return updatenum;
        }
        public int DeleteDB(string sql)
        {//删除
            int deletenum = 0;
            if (linkDB())
            {
                SqlCommand mysqlcommand;
                mysqlcommand = new SqlCommand(sql, conn);
                mysqlcommand.Connection.Open();
                deletenum = mysqlcommand.ExecuteNonQuery();
                conn.Close();
            }
            return deletenum;
        }
        public Boolean closeDB()
        {//关闭数据库
            conn.Close();
            conn.Dispose();
            return true;
        }
    }
}