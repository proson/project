using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SqlServer
{
    public partial class SqlBulkCopyTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(int));//为新的Datatable添加一个新的列名
            dt.Columns.Add("Name", typeof(string));//为新的Datatable添加一个新的列名
            dt.Columns.Add("sex", typeof(int));//为新的Datatable添加一个新的列名
            dt.Columns.Add("phone", typeof(string));//为新的Datatable添加一个新的列名
            for (int i = 0; i < 100000; i++) //开始循环赋值
            {
                DataRow row = dt.NewRow(); //创建一个行
                row["ID"] = i + 1; //从总的Datatable中读取行数据赋值给新的Datatable
                row["Name"] = "sxd" + (i + 1).ToString();
                row["sex"] = i % 2 == 0 ? 1 : 0;
                row["phone"] = (13500000000 + i + 1).ToString();
                dt.Rows.Add(row);//添加次行
            }
            return dt;
        }


        private SqlBulkCopyColumnMapping[] GetMapping()
        {
            SqlBulkCopyColumnMapping[] mappings = new SqlBulkCopyColumnMapping[4];
            mappings[0] = new SqlBulkCopyColumnMapping("ID", "ID");
            mappings[1] = new SqlBulkCopyColumnMapping("Name", "Name");
            mappings[2] = new SqlBulkCopyColumnMapping("sex", "sex");
            mappings[3] = new SqlBulkCopyColumnMapping("phone", "phone");
            return mappings;
        }
        /// <summary>
        /// DataTable批量添加(有事务)
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="destinationTableName"></param>
        /// <returns></returns>
        private void MySqlBulkCopy(DataTable dataTable, string destinationTableName)
        {
            string connectionString = "server=172.16.8.208,1109;database=10W;uid=sa;pwd=sa";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction))
                    {
                        bulkCopy.DestinationTableName = destinationTableName;
                        //获取映射关系
                        SqlBulkCopyColumnMapping[] mapping = GetMapping();
                        if (mapping!=null)
                        {
                            foreach (SqlBulkCopyColumnMapping columnMapping in mapping)
                            {
                                bulkCopy.ColumnMappings.Add(columnMapping);
                            }
                        }
                        try
                        {
                            bulkCopy.WriteToServer(dataTable);
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = GetDataTable();
            DateTime dt1 = DateTime.Now;
            Label1.Text = dt1.ToString();
            MySqlBulkCopy(dt, "User_1");
            DateTime dt2 = DateTime.Now;
            Label2.Text = dt2.ToString();
            TimeSpan span = dt2 - dt1;
            string a = span.TotalSeconds.ToString();
            Label3.Text = a;
        }


    }
}