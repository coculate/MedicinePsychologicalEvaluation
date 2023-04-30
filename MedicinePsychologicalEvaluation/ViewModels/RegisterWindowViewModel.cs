using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class RegisterWindowViewModel : ViewModelBase
    {
        public static string PageTitle => "用户注册界面";

        private string? userAccount;

        private string? password;

        private string? passwordConfirm;

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

        public string? PasswordConfirm
        {
            get => passwordConfirm;
            set => this.RaiseAndSetIfChanged(ref passwordConfirm, value);
        }

    }
}
