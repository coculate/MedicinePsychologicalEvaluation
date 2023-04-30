using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using MedicinePsychologicalEvaluation.Models;
using System;

namespace MedicinePsychologicalEvaluation.Views
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        public void Super_Click(object sender, RoutedEventArgs e)
        {
            // Change button text when button is clicked.
            string UserAccount = this.FindControl<TextBox>("UserAccount").Text;
            string Password = this.FindControl<TextBox>("Password").Text;
            string PasswordConfirm = this.FindControl<TextBox>("PasswordConfirm").Text;
            if (string.IsNullOrEmpty(UserAccount) || string.IsNullOrEmpty(Password))
            {
                DialogManage.Show(DialogType.TopCenter, "请输入账号或密码");
                return;
            }

            if (Password != PasswordConfirm)
            {
                DialogManage.Show(DialogType.TopCenter, "前后两次输入密码不一致，请确认");
                return;
            }

            Medicine_Users user = new Medicine_Users
            {
                UserAccount = UserAccount,
                UserPwd = Password,
                UserType = 2,
                CreateDate = DateTime.Now
            };
            using (MyDbContext db = new MyDbContext())
            {
                db.Medicine_Users?.Add(user);
                int flag = db.SaveChanges();
                if (flag > 0)
                {
                    LoginWindow login = new LoginWindow();
                    login.Show();
                    this.Close();
                }
            }
        }

        public void Normal_Click(object sender, RoutedEventArgs e)
        {
            string UserAccount = this.FindControl<TextBox>("UserAccount").Text;
            string Password = this.FindControl<TextBox>("Password").Text;
            string PasswordConfirm = this.FindControl<TextBox>("PasswordConfirm").Text;
            if (string.IsNullOrEmpty(UserAccount) || string.IsNullOrEmpty(Password))
            {
                DialogManage.Show(DialogType.TopCenter, "请输入账号或密码");
                return;
            }

            if (Password != PasswordConfirm)
            {
                DialogManage.Show(DialogType.TopCenter, "前后两次输入密码不一致，请确认");
                return;
            }

            Medicine_Users user = new Medicine_Users
            {
                UserAccount = UserAccount,
                UserPwd = Password,
                UserType = 1,
                CreateDate = DateTime.Now
            };
            using (MyDbContext db = new MyDbContext())
            {
                db.Medicine_Users?.Add(user);
                int flag = db.SaveChanges();
                if (flag > 0)
                {
                    LoginWindow login = new LoginWindow();
                    login.Show();
                    this.Close();
                }
            }
        }

        public void Login_Click(object sender, PointerPressedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }

    }
}
