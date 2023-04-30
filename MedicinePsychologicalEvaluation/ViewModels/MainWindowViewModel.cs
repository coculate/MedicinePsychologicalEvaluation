using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen
    {
        public static string PageTitle => "测评类型选择";

        public static string TitleSelf => "自评量表";

        public static string TitleOther => "他评量表";

        public static bool IsVisible => LoginUser?.UserType == 2;

        private RoutingState _router = new RoutingState();

        public MainWindowViewModel()
        {
            AnxietySelf = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(new AnxietySelfViewModel(this))
            );

            AnxietyOther = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(new AnxietyOtherViewModel(this))
            );

            DepressedSelf = ReactiveCommand.CreateFromObservable(
               () => Router.Navigate.Execute(new DepressedSelfViewModel(this))
           );

            DepressedOther = ReactiveCommand.CreateFromObservable(
               () => Router.Navigate.Execute(new DepressedOtherViewModel(this))
           );

            EvaluationList = ReactiveCommand.CreateFromObservable(
               () => Router.Navigate.Execute(new EvaluationListViewModel(this))
           );

            ProjectList = ReactiveCommand.CreateFromObservable(
               () => Router.Navigate.Execute(new ProjectListViewModel(this))
           );

            AddEvaluation = ReactiveCommand.CreateFromObservable(
               () => Router.Navigate.Execute(new CreateEvaluationViewModel(this))
           );

            AddProject = ReactiveCommand.CreateFromObservable(
               () => Router.Navigate.Execute(new CreateProjectViewModel(this))
           );

            RecordList = ReactiveCommand.CreateFromObservable(
               () => Router.Navigate.Execute(new EvaluationResultViewModel(this))
           );

            UserInfo = ReactiveCommand.CreateFromObservable(
              () => Router.Navigate.Execute(new UserInfoViewModel(this))
          );

            ProjectTest = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new ProjectTestViewModel(this, 0))
        ) ;
        }

        public ReactiveCommand<Unit, IRoutableViewModel> AnxietySelf { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> AnxietyOther { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> DepressedSelf { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> DepressedOther { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> EvaluationList { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> ProjectList { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> AddEvaluation { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> AddProject { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> RecordList { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> UserInfo { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> ProjectTest { get; }


        public RoutingState Router
        {
            get => _router;
            set => this.RaiseAndSetIfChanged(ref _router, value);
        }
    }
}
