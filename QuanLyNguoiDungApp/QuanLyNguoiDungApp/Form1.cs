using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNguoiDungApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectToDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(
                        ConfigurationManager.ConnectionStrings["Userdb"].ConnectionString))
                {
                    connection.Open();
                    MessageBox.Show("Kết nối thành công!");
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Kiểm tra kết nối đến db
        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
        }
    }
}
