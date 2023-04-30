using ReactiveUI;
using MedicinePsychologicalEvaluation.Views;
using MedicinePsychologicalEvaluation.Models;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using System;
using System.Reactive;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        public static string PageTitle => "用户登录界面";

        private string? userAccount;

        private string? password;

        public string? UserAccount
        {
            get => userAccount;
            set => this.RaiseAndSetIfChanged(ref userAccount, value);
        }

        public string? Password
        {
            get => password;
            set => this.RaiseAndSetIfChanged(ref password, value);
        }
    }
}
