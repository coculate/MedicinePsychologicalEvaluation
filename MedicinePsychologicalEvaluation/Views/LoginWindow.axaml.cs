using ReactiveUI;
using Avalonia.ReactiveUI;
using System.Threading.Tasks;
using MedicinePsychologicalEvaluation.ViewModels;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MedicinePsychologicalEvaluation.Models;
using System.Linq;
using Splat;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia;

namespace MedicinePsychologicalEvaluation.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public void Register_Click(object sender, PointerPressedEventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            register.Show();
            this.Close();
        }

        public void Super_Click(object sender, RoutedEventArgs e)
        {
            string UserAccount = this.FindControl<TextBox>("UserAccount").Text;
            string Password = this.FindControl<TextBox>("Password").Text;
            if (string.IsNullOrEmpty(UserAccount) || string.IsNullOrEmpty(Password))
            {
                DialogManage.Show(DialogType.TopCenter, "«Î ‰»Î’À∫≈ªÚ√‹¬Î");
                return;
            }
            using (MyDbContext db = new MyDbContext())
            {
                var user = db.Medicine_Users?.FirstOrDefault(t => t.UserAccount == UserAccount && t.UserPwd == Password && t.UserType == 2);
                if (user == null)
                {
                    DialogManage.Show(DialogType.TopCenter, "√ª”–¥À’À∫≈");
                    return;
                }
                //MainWindow main = new MainWindow();
                //main.Show();
                ViewModelBase.LoginUser = user;
                //new MainWindow { DataContext = Locator.Current.GetService<IScreen>() }.Show();
                var mainWindow = new MainWindow { DataContext = Locator.Current.GetService<IScreen>() };
                (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!.MainWindow = mainWindow;
                mainWindow.Show();
                this.Close();
            }
        }

        public void Normal_Click(object sender, RoutedEventArgs e)
        {
            string UserAccount = this.FindControl<TextBox>("UserAccount").Text;
            string Password = this.FindControl<TextBox>("Password").Text;
            if (string.IsNullOrEmpty(UserAccount) || string.IsNullOrEmpty(Password))
            {
                DialogManage.Show(DialogType.TopCenter, "«Î ‰»Î’À∫≈ªÚ√‹¬Î");
                return;
            }
            using (MyDbContext db = new MyDbContext())
            {
                var user = db.Medicine_Users?.FirstOrDefault(t => t.UserAccount == UserAccount && t.UserPwd == Password && t.UserType == 1);
                if (user == null)
                {
                    DialogManage.Show(DialogType.TopCenter, "√ª”–¥À’À∫≈");
                    return;
                }
                //MainWindow main = new MainWindow();
                //main.Show();
                ViewModelBase.LoginUser = user;
                //new MainWindow { DataContext = Locator.Current.GetService<IScreen>() }.Show();
                var mainWindow = new MainWindow { DataContext = Locator.Current.GetService<IScreen>() };
                (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!.MainWindow = mainWindow;
                mainWindow.Show();
                this.Close();
            }
        }

    }
}
