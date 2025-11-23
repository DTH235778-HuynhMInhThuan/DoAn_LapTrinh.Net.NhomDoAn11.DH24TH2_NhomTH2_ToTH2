using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyCuaHangXeMay.Class
{
    internal class Functions
    {
        public static SqlConnection Con;

        public static void Connect()
        {
            Con = new SqlConnection();

           
            string duongDan = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Laptrinh.NET_WindowsForm\QuanLyCuaHangXeMay\QuanLyCuaHangXeMay\QuanLyCuaHangXeMay.mdf;Integrated Security=True";

            Con.ConnectionString = duongDan;

            try
            {
                Con.Open();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối CSDL: " + ex.Message, "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Disconnect()
        {
            if (Con != null && Con.State == ConnectionState.Open)
            {
                Con.Close();
                Con.Dispose();
                Con = null;
            }
        }

        public static void RunSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi SQL: \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmd.Dispose();
            cmd = null;
        }

        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public static string GetFieldValues(string sql)
        {
            string value = "";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                    value = reader.GetValue(0).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi GetFieldValues: " + ex.Message);
            }
            finally
            {
                if (reader != null) reader.Dispose();
                cmd.Dispose();
            }
            return value;
        }
    }
}