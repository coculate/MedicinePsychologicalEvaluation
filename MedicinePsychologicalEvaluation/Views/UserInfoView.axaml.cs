using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MedicinePsychologicalEvaluation.ViewModels;
using ReactiveUI;

namespace MedicinePsychologicalEvaluation.Views
{
    public partial class UserInfoView : ReactiveUserControl<UserInfoViewModel>
    {
        public UserInfoView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
