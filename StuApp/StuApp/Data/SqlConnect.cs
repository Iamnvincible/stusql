using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuApp.Data
{
    public class SqlConnect
    {
        SqlConnection _sqlConn;
        public async Task Connect()
        {
            string strConn = "Server=tcp:lin.database.windows.net,1433;Initial Catalog=StuWeb;Persist Security Info=False;User ID=***;Password=***;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _sqlConn = new SqlConnection();
            _sqlConn.ConnectionString = strConn;
            await _sqlConn.OpenAsync();
            if (_sqlConn.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("数据库连接成功");
            }
        }
        public async Task<List<Student>> Query()
        {
            List<Student> students = new List<Student>();
            string sqlstr = "select * from dbo.Student";
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = _sqlConn;
            sqlcomm.CommandText = sqlstr;
            //int rownum = sqlcomm.ExecuteNonQuery();
            SqlDataReader datareader = sqlcomm.ExecuteReader();
            while (await datareader.ReadAsync())
            {
                Student s = new Student();
                s.Number = (int)datareader[0];
                s.Name = datareader[1].ToString();
                s.ClassNum = datareader[2].ToString();
                s.Subject = datareader[3].ToString();
                s.Sex = datareader[4].ToString();
                students.Add(s);
            }
            datareader.Close();
            return students;
        }
    }
}
