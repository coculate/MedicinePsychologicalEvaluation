using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MedicinePsychologicalEvaluation.ViewModels;
using ReactiveUI;

namespace MedicinePsychologicalEvaluation.Views
{
    public partial class EvaluationListView : ReactiveUserControl<EvaluationListViewModel>
    {
        public EvaluationListView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
