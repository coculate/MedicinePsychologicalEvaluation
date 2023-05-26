using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MedicinePsychologicalEvaluation.ViewModels;
using ReactiveUI;

namespace MedicinePsychologicalEvaluation.Views
{
    public partial class ShowResultView : ReactiveUserControl<ShowResultViewModel>
    {
        public ShowResultView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
