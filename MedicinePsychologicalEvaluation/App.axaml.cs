using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MedicinePsychologicalEvaluation.ViewModels;
using MedicinePsychologicalEvaluation.Views;
using ReactiveUI;
using Splat;

namespace MedicinePsychologicalEvaluation
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            Locator.CurrentMutable.RegisterConstant<IScreen>(new MainWindowViewModel());
            Locator.CurrentMutable.Register<IViewFor<AnxietySelfViewModel>>(() => new AnxietySelfWindow());
            Locator.CurrentMutable.Register<IViewFor<AnxietyOtherViewModel>>(() => new AnxietyOtherView());
            Locator.CurrentMutable.Register<IViewFor<DepressedSelfViewModel>>(() => new DepressedSelfView());
            Locator.CurrentMutable.Register<IViewFor<DepressedOtherViewModel>>(() => new DepressedOtherView());
            Locator.CurrentMutable.Register<IViewFor<EvaluationListViewModel>>(() => new EvaluationListView());
            Locator.CurrentMutable.Register<IViewFor<ProjectListViewModel>>(() => new ProjectListView());
            Locator.CurrentMutable.Register<IViewFor<CreateEvaluationViewModel>>(() => new AddEvaluationView());
            Locator.CurrentMutable.Register<IViewFor<CreateProjectViewModel>>(() => new AddProjectView());
            Locator.CurrentMutable.Register<IViewFor<EvaluationResultViewModel>>(() => new EvaluationResultView());
            Locator.CurrentMutable.Register<IViewFor<SelectTypeViewModel>>(() => new SelectTypeView());
            Locator.CurrentMutable.Register<IViewFor<UserInfoViewModel>>(() => new UserInfoView());
            Locator.CurrentMutable.Register<IViewFor<ProjectTestViewModel>>(() => new ProjectTestView());
            //new MainWindow { DataContext = Locator.Current.GetService<IScreen>() }.Show();
            Locator.CurrentMutable.Register<IViewFor<ShowResultViewModel>>(() => new ShowResultView());

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new LoginWindow
                {
                    DataContext = new LoginWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
