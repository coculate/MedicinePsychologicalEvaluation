using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MedicinePsychologicalEvaluation.ViewModels;
using ReactiveUI;
using System;

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
            this.Hide();
            LoginWindow login = new LoginWindow();
            login.Show();
        }

    }
}
