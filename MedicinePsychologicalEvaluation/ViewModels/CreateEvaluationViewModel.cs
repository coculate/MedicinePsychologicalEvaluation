using MedicinePsychologicalEvaluation.Models;
using MedicinePsychologicalEvaluation.Models.Enums;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class CreateEvaluationViewModel :  ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }

        public string UrlPathSegment { get; } = "/createevaluate";

        public CreateEvaluationViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _Evaluation = new Medicine_Evaluation
            {
                UserId = null == LoginUser ? 0 : LoginUser.id,
                CreateDate = DateTime.Now
            };

            EvaluationTypeItems = new ObservableCollection<SelectItems>(new List<SelectItems> {
            new SelectItems{ Value=((int)EvaluationType.焦虑自评),Text=EvaluationType.焦虑自评.ToString() },
            new SelectItems{ Value=((int)EvaluationType.抑郁自评),Text=EvaluationType.抑郁自评.ToString() },
            new SelectItems{ Value=((int)EvaluationType.焦虑他评),Text=EvaluationType.焦虑他评.ToString() },
            new SelectItems{ Value=((int)EvaluationType.抑郁他评),Text=EvaluationType.抑郁他评.ToString() }
            });

            SaveBtn = ReactiveCommand.Create(() =>
            {
                using (MyDbContext dbContext = new MyDbContext())
                {
                    dbContext.Medicine_Evaluation?.Add(Evaluation);
                    int flag = dbContext.SaveChanges();
                    if (flag > 0)
                    {
                        HostScreen.Router.Navigate.Execute(new EvaluationListViewModel(HostScreen));
                    }
                }
            });

        }

        private Medicine_Evaluation _Evaluation;

        public Medicine_Evaluation Evaluation
        {
            get => _Evaluation;
            set=> this.RaiseAndSetIfChanged(ref _Evaluation, value);
        }

        public ReactiveCommand<Unit, Unit> SaveBtn { get; }

        public ObservableCollection<SelectItems> EvaluationTypeItems { get; }

    }
}
