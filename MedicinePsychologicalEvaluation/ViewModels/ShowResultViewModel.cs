using MedicinePsychologicalEvaluation.ViewModels.Common;
using ReactiveUI;
using Splat;
using System.Reactive;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class ShowResultViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }

        public string? UrlPathSegment { get; } = LoginUser?.UserAccount;

        private string testResult;

        /// <summary>
        /// 检测结果
        /// </summary>
        public string TestResult
        {
            get => testResult;
            set => this.RaiseAndSetIfChanged(ref testResult, value);
        }

        public ReactiveCommand<Unit, Unit> GoBack { get; }

        public ShowResultViewModel(IScreen screen, int score)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            testResult = UtilityHelper.GetTestResult(score);

            //GoBack = ReactiveCommand.CreateFromObservable(
            //    () => Router.Navigate.Execute(new EvaluationResultViewModel(HostScreen))
            //); 

            GoBack = ReactiveCommand.Create(()=> {
                HostScreen.Router.NavigateBack.Execute();
            });

        }

    }
}
