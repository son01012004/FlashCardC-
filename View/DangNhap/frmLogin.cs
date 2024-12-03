﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Text.RegularExpressions;
using FlashCard.Controller;
using FlashCard.Entity;

namespace FlashCard.View.DangNhap
{
    public partial class frmLogin : Form
    {
        // private readonly LoginController _loginController;
        public User user;

        public frmLogin()
        {
            InitializeComponent();
            //    _loginController = new LoginController();
            PnLogin.BringToFront();
            this.AcceptButton = SIGNIN;
        }

        private void setNull()
        {
            txtLoginEmail.Text = null;
            txtLoginPass.Text = null;
            remember.Checked = false;
            errLgEmail.Visible = false;
            errLgPass.Visible = false;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public User getUser()
        {

            return this.user;
        }

        public static bool checkEmail(string email)
        {
            // Regular expression for email validation
            string emailRegex = @"^[a-zA-Z][a-zA-Z0-9._]*@gmail\.com$";
            return Regex.IsMatch(email, emailRegex);
        }
        private void SIGNIN_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox
            string email = txtLoginEmail.Text.Trim();
            string password = txtLoginPass.Text.Trim();



            bool error = false;
            if (string.IsNullOrEmpty(email))
            {
                errLgEmail.Visible = true;
                errLgEmail.Text = "Vui lòng nhập email";
                error = true;
            }
            else if (!checkEmail(email))
            {
                errLgEmail.Visible = true;
                errLgEmail.Text = "Email sai định dạng";
                error = true;
            }
            else
            {
                errLgEmail.Visible = false;
            }
            if (string.IsNullOrEmpty(password))
            {
                errLgPass.Visible = true;
                errLgPass.Text = "Vui lòng nhập password";
                error = true;
            }
            else
            {
                errLgPass.Visible = false;
            }
            if (error) { return; }

            setNull();

            // Gửi thông tin đến LoginController
            User user = new User(email, password);

            // Sử dụng kết quả trả về từ LoginController
            // User loggedInUser = _loginController.Login(user);
            // if (loggedInUser != null)
            if (user != null)
            {
                // this.user = loggedInUser;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                errLgPass.Text = "Đăng nhập thất bại. Sai email hoặc mật khẩu.";
                errLgPass.Visible = true;
            }
        }





        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            // Khởi tạo giao diện đăng ký
            Register registerControl = new Register();
            this.AcceptButton = registerControl.SignUp;
            registerControl.Location = PnLogin.Location;

            // Xử lý sự kiện quay lại trang đăng nhập
            registerControl.OnBackToLogin += () =>
            {
                PnLogin.BringToFront();
            };

            // Xử lý sự kiện hoàn tất đăng ký
            registerControl.OnSignUpSuccess += () =>
            {
                // Chuyển đến giao diện mã xác thực
                xacthuc xacthucForm = new xacthuc();
                xacthucForm.Show();

            };

            this.Controls.Add(registerControl);
            registerControl.BringToFront();
            setNull();
        }

        private void ForgotPass_Click(object sender, MouseEventArgs e)
        {
            ForgotPass forgotPassControl = new ForgotPass();
            this.AcceptButton = forgotPassControl.SIGNIN;
            forgotPassControl.Location = PnLogin.Location;
            forgotPassControl.OnBackToLogin += () =>
            {
                PnLogin.BringToFront();
            };

            this.Controls.Add(forgotPassControl);
            forgotPassControl.BringToFront();
            setNull();
        }

        private void hideye_Click(object sender, EventArgs e)
        {
            if(txtLoginPass.PasswordChar == '*')
            {
                eye.BringToFront();
                txtLoginPass.PasswordChar = '\0';
            }
        }

        private void eye_Click(object sender, EventArgs e)
        {
            if(txtLoginPass.PasswordChar == '\0')
            {
                hideye.BringToFront();
                txtLoginPass.PasswordChar = '*';
            }
        }
    }
}