using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MedicinePsychologicalEvaluation.ViewModels;
using ReactiveUI;
using Splat;

namespace MedicinePsychologicalEvaluation.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }

        public void LoginOut_Click(object sender, PointerPressedEventArgs e)
        {
            //this.Hide();
            //LoginWindow login = new LoginWindow();
            //login.Show();
            var loginWindow = new LoginWindow { DataContext = Locator.Current.GetService<LoginWindowViewModel>() };
            (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!.MainWindow = loginWindow;
            loginWindow.Show();
            this.Close();
        }

    }
}
