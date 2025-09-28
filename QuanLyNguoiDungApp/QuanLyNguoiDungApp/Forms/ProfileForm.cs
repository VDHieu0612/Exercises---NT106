using QuanLyNguoiDungApp.Data;
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

namespace QuanLyNguoiDungApp.Forms
{
    public partial class ProfileForm : Form
    {
        private string _email;  // Email đăng nhập

        public ProfileForm(string email)
        {
            InitializeComponent();
            _email = email;
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(
                        ConfigurationManager.ConnectionStrings["Userdb"].ConnectionString))
                {
                    string query = "SELECT Email, UserName, SDT, NgaySinh, LoaiUser FROM USERS WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", _email);
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                EmailField.Text = reader["Email"].ToString();
                                UsernameField.Text = reader["UserName"].ToString();
                                PhonenumField.Text = reader["SDT"].ToString();
                                DoBField.Text = Convert.ToDateTime(reader["NgaySinh"]).ToString("dd/MM/yyyy");
                                RoleField.Text = reader["LoaiUser"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }
        private void ProfileForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
