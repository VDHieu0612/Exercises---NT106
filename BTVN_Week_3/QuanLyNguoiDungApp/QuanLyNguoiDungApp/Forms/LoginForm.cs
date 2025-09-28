using QuanLyNguoiDungApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNguoiDungApp.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string email = EmailField.Text.Trim();
            string password = PasswordField.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Password.");
                return;
            }

            try
            {
                // Lấy hash lưu trong DB
                string storedHash = DbHelper.GetPasswordHash(email);

                if (storedHash == null)
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                    return;
                }

                // Hash lại password nhập vào
                string enteredHash = SecurityHelper.HashPassword(password);

                if (storedHash == enteredHash)
                {
                    MessageBox.Show($"Đăng nhập thành công! Xin chào {email}");

                    // Điều hướng đến profile 
                    ProfileForm profile = new ProfileForm(email);
                    profile.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message);
            }
        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mở form Signup
            SignupForm signup = new SignupForm();
            this.Hide();
            signup.Show();
        }
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
