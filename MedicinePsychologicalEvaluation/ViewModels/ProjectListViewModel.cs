using MedicinePsychologicalEvaluation.Models;
using MedicinePsychologicalEvaluation.Models.Dtos;
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
    public class ProjectListViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }

        public string UrlPathSegment { get; } = "/projectlist";

        private ObservableCollection<EvaluationProject> _items;

        public ObservableCollection<EvaluationProject> Items
        {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        private string? _keyWord;

        public string? KeyWord
        {
            get => _keyWord;
            set => this.RaiseAndSetIfChanged(ref _keyWord, value);
        }

        public ProjectListViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _items = new ObservableCollection<EvaluationProject>(CreateItems());
            QueryBtn = ReactiveCommand.Create(() =>
            {

            });
        }

        private List<EvaluationProject> CreateItems()
        {
            using (MyDbContext db = new MyDbContext())
            {
                if (db.Medicine_Evaluation != null && db.Medicine_Project != null)
                {
                    var projects = db.Medicine_Project.Join(db.Medicine_Evaluation, a => a.EvaluationId, b => b.id, (a, b) => new EvaluationProject
                    {
                        EvaluationId = b.id,
                        ProjectId = a.id,
                        EvaluationName = b.EvaluationName,
                        Answer = a.Answer,
                        AnswerA = a.AnswerA,
                        AnswerB = a.AnswerB,
                        AnswerC = a.AnswerC,
                        AnswerD = a.AnswerD,
                        Score = a.Score,
                        Title = a.Title
                    }).AsNoTracking();
                    if (!string.IsNullOrEmpty(KeyWord))
                    {
                        projects = projects.Where(t => !string.IsNullOrEmpty(t.EvaluationName) && t.EvaluationName.Contains(KeyWord));
                    }
                    return projects.ToList();
                }
                return new List<EvaluationProject>();
            }
        }

        public ReactiveCommand<Unit, Unit> QueryBtn { get; }

    }
}
