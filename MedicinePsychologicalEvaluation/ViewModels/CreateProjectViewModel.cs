using MedicinePsychologicalEvaluation.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class CreateProjectViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }

        public string UrlPathSegment { get; } = "/createproject";

        public CreateProjectViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            EvaluationItems = new ObservableCollection<SelectItems>(GetEvaluationItems());
            _Project = new Medicine_Project
            {
                UserId = null == LoginUser ? 0 : LoginUser.id,
                CreateDate = DateTime.Now
            };

            _Evaluation = new SelectItems();

            SaveBtn = ReactiveCommand.Create(() =>
            {
                using (MyDbContext dbContext = new MyDbContext())
                {
                    Project.EvaluationId = Evaluation.Value;
                    dbContext.Medicine_Project?.Add(Project);
                    int flag = dbContext.SaveChanges();
                    if (flag > 0)
                    {
                        HostScreen.Router.Navigate.Execute(new ProjectListViewModel(HostScreen));
                    }
                }
            });
        }

        private Medicine_Project _Project;

        public Medicine_Project Project
        {
            get => _Project;
            set => this.RaiseAndSetIfChanged(ref _Project, value);
        }

        private SelectItems _Evaluation;

        public SelectItems Evaluation
        {
            get => _Evaluation;
            set => this.RaiseAndSetIfChanged(ref _Evaluation, value);
        }

        public ReactiveCommand<Unit, Unit> SaveBtn { get; }

        public ObservableCollection<SelectItems> EvaluationItems { get; }

        private List<SelectItems> GetEvaluationItems()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                IQueryable<Medicine_Evaluation> evaluations = dbContext.Medicine_Evaluation.AsNoTracking();
                List<SelectItems> selectItems = evaluations.Select(t => new SelectItems
                {
                    Value = t.id,
                    Text = t.EvaluationName
                }).ToList();
                return selectItems;
            }
        }

    }
}
