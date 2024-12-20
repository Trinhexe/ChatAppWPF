using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ZaTikFace
{
    public static class MainClass
    {
        static string KN = "Data Source=trinhlk;Initial Catalog=Login;Integrated Security=True;Encrypt=False";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(KN);

        }
        public static bool DangNhap(string tk, string mk)
        {
            bool ktr = false;
            string sql = @"Select UserName,Password from TaiKhoan
                        Where (UserName ='"+tk+"' and Password ='"+mk+"')";
            SqlCommand cmd = new SqlCommand(sql, MainClass.GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ktr = true;
            }
            return ktr;
        }
    }
}
